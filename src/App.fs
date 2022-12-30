module App
open Browser.Dom
open Browser.Types
open Fable.Core
open Fable.Core.JsInterop

type Section = 
  { Properties : Map<string, string> 
    ID : string
    File : string
    Element : HTMLElement }

let content = 
  [ let sections = document.getElementsByTagName("section")
    for i in 0 .. sections.length-1 do
      let sec = sections.[i] :?> HTMLElement
      let props = [ for k in JS.Constructors.Object.keys(sec.dataset) -> k, sec.dataset.[k] ] |> Map.ofSeq
      { Element = sec
        ID = props.["id"]
        File = props.["file"]
        Properties = props } ]

type State = 
  { Display1 : Section option
    Display2 : Section option }

type PageEvent = 
  | LoadLink of Section
  | SetDisplays of Section option * Section option 

let getHashLink state = 
  let getHash d = function Some sec -> [$"{d}={sec.File};{sec.ID}"] | _ -> []
  "#" + String.concat "," ((getHash "display1" state.Display1) @ (getHash "display2" state.Display2))

let pushHistory state = 
  window.history.pushState(null, null, getHashLink state)
  state

let update evt state = 
  match evt with 
  | SetDisplays(sec1, sec2) ->
      { state with Display1 = sec1; Display2 = sec2 }
  | LoadLink sec ->       
      { state with Display2 = Some sec } |> pushHistory

let triggerEvt = Event<PageEvent>()
let trigger = triggerEvt.Trigger

type Transclusion = 
  { Content : Section option
    Title : string
    Link : Section }

let findContent basefn (ref:string) = 
  let file, id = 
    match ref.Split(';') with 
    | [| id |] -> basefn, id 
    | [| file; id |] -> file, id 
    | _ -> failwithf "findContent: Invalid reference: %s" ref 
  let sec = content |> Seq.tryFind (fun sec -> sec.ID = id && sec.File = file)
  match sec with
  | Some sec -> sec 
  | _ -> failwithf "findContent: Failed to find content: %A" (file, id)

let parseKvpList (list:string) = 
  list.Split(',') |> Array.map (fun part -> 
    match part.Trim().Split('=') with
    | [| k; v |] -> k.Trim(), v.Trim()
    | _ -> failwithf "parseKvpList: Expected key value pair list, but got: %s" part) |> Map.ofSeq

let parseTransclusion basefn (info:string) = 
  let kvps = parseKvpList info
  match kvps.TryFind("content"), kvps.TryFind("link"), kvps.TryFind("title") with
  | Some cref, Some lref, title -> 
      let content = findContent basefn cref
      { Content = Some content; Link = findContent basefn lref 
        Title = title |> Option.defaultWith (fun () -> content.Properties.TryFind("title") |> Option.defaultValue "") }
  | Some cref, None, title -> 
      let content = findContent basefn cref
      { Content = Some content; Link = content 
        Title = title |> Option.defaultWith (fun () -> content.Properties.TryFind("title") |> Option.defaultValue "") }
  | None, Some lref, title -> 
      let link = findContent basefn lref
      { Content = None; Link = link; 
        Title = title |> Option.defaultWith (fun () -> link.Properties.TryFind("title") |> Option.defaultValue "") }
  | _ -> failwithf "parseTransclusion: Missing title and content: %s" info

let rec allChildren (el:HTMLElement) = 
  [ for i in 0 .. el.children.length-1 do 
      yield el.children.[i]
      yield! allChildren (unbox el.children.[i]) ]

let rec renderTransclusion state basefn trans = 
  let nc, templ = 
    if trans.Content.IsSome then 
      document.createElement("div"), "transclusion-content-template" 
    else document.createElement("span"), "transclusion-ref-template"
  let body, basefn =
    trans.Content |> Option.map (fun cont -> cont.Element.innerHTML) |> Option.defaultValue "",
    trans.Content |> Option.map (fun cont -> cont.File) |> Option.defaultValue basefn
  let hash1 = getHashLink { state with Display1 = Some trans.Link; Display2 = None }
  let hash2 = getHashLink { state with Display2 = Some trans.Link }
  nc.innerHTML <- 
    document.getElementById(templ).innerHTML
      .Replace("[TITLE]", trans.Title).Replace("[CONTENT]", body)
        .Replace("[HASH1]", hash1).Replace("[HASH2]", hash2)
  renderTransclusions state basefn nc
  nc

and renderTransclusions state basefn out = 
  for child in allChildren out do 
    if child.tagName = "EMBED" then
      let embed = child :?> HTMLEmbedElement
      let nc = renderTransclusion state basefn (parseTransclusion basefn embed.attributes.[unbox "src"].value)
      child.parentElement.replaceChild(nc, child) |> ignore

let renderDisplay state display sec = 
  let out = document.getElementById(display) :?> HTMLDivElement
  out?style?display <- if Option.isSome sec then "block" else "none"
  sec |> Option.iter (fun sec ->
    let key = sec.File + ";" + sec.ID
    if out.dataset.["displayed"] <> key then
      out.dataset.["displayed"] <- key
      let html = document.getElementById("display-template").innerHTML
      let close = { state with Display2 = None } |> getHashLink
      let nhtml = html.Replace("[CONTENT]", sec.Element.innerHTML).Replace("[CLOSE]", close)
      out.innerHTML <- nhtml
      renderTransclusions state sec.File out )


let render state = 
  state.Display1 |> renderDisplay state "display1"
  state.Display2 |> renderDisplay state "display2"

let mutable state = 
  { Display1 = Some(findContent "index" "main")
    Display2 = None }

triggerEvt.Publish.Add(fun evt -> 
  state <- update evt state
  render state )

window.onhashchange <- fun e -> 
  let hash = if window.location.hash = "" then "display1=index;main" else window.location.hash.Replace("#", "")
  let locs = parseKvpList hash
  let d1 = locs.TryFind("display1") |> Option.map (fun ref -> findContent "index" ref)
  let d2 = locs.TryFind("display2") |> Option.map (fun ref -> findContent "index" ref)
  trigger(SetDisplays(d1, d2))

window.onhashchange null
(*

let rec load basefn (reference:string) (out:HTMLElement) =   
  let file, id = match reference.Split(';') with [| id |] -> basefn, id | [| file; id |] -> file, id | _ -> failwithf "load: Invalid reference: %s" reference
  let id, attr = match id.Split('@') with [| id |] -> id, None | [| ""; attr |] -> "index", Some attr | [| id; attr |] -> id, Some attr | _ -> failwithf "load: Invalid reference: %s" reference
  let sec = content |> Seq.tryFind (fun sec -> sec.ID = id && sec.File = file)
  let sec = match sec with Some sec -> sec | _ -> failwithf "load: Failed to find content: %A" (file, id)
  match attr with 
  | Some attr -> 
      out.className <- "transclusion attr"
      out.innerHTML <- sec.Properties.[attr]
  | None ->
      out.className <- "transclusion body"
      out.innerHTML <- sec.Element.innerHTML
      for child in allChildren out do 
        if child.tagName = "EMBED" then
          let embed = child :?> HTMLEmbedElement
          let nc = document.createElement("div")
          load file embed.attributes.[unbox "src"].value nc
          child.parentElement.replaceChild(nc, child) |> ignore
  out?style?display <- "block"

let display1 = document.getElementById("display1-body") :?> HTMLDivElement
load "index" "index;main" display1

let display2 = document.getElementById("display2-body") :?> HTMLDivElement
load "index" "index;main" display1
load "dimensions/interaction" "index" display2
*)