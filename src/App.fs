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
  { Displays : Map<string, Section> }

let getHashLink (state:Map<_, _>) = 
  let getHash d sec = $"{d}={sec.File};{sec.ID}"
  "#" + String.concat "," [ for kvp in state -> getHash kvp.Key kvp.Value ]

type Transclusion = 
  { Content : Section }

let findContent (ref:string) = 
  let file, id = 
    match ref.Split(',') with 
    | [| file; id |] -> file, id 
    | _ -> failwithf "findContent: Invalid reference: '%s'" ref 
  let sec = content |> Seq.tryFind (fun sec -> sec.ID = id && sec.File = file)
  match sec with
  | Some sec -> sec 
  | _ -> failwithf "findContent: Failed to find content: %A" (file, id)

let parseKvpList (list:string) = 
  list.Split(';') |> Array.map (fun part -> 
    match part.Trim().Split('=') with
    | [| k; v |] -> k.Trim(), v.Trim()
    | _ -> failwithf "parseKvpList: Expected key value pair list, but got: %s" list) |> Map.ofSeq

let rec getAllChildren (el:HTMLElement) = 
  [ yield el 
    for i in 0 .. el.children.length - 1 do  
      yield! getAllChildren (unbox el.children.[i]) ]

let expandLinks state (el:HTMLElement) = 
  for c in getAllChildren el do
    if c.tagName = "A" then 
      let a = c :?> HTMLAnchorElement
      if a.attributes.[unbox "href"].value.StartsWith("#") then
        let links = a.attributes.[unbox "href"].value.Substring(1) |> parseKvpList |> Map.map (fun k v ->
          if v = "." then state.Displays.[k].File + "," + state.Displays.[k].ID else v)
        let href = "#" + String.concat ";" [ for kvp in links -> $"""{kvp.Key}={kvp.Value.Replace("!", "")}""" ]
        a.attributes.[unbox "href"].value <- href
        if a.text = "!" then
          let title = links |> Seq.find (fun kvp -> kvp.Value.Contains("!"))
          let sec = title.Value.Replace("!", "") |> findContent
          a.innerHTML <- a.innerHTML.Replace("!", sec.Properties.["title"])

let rec renderTransclusion trans = 
  let nc = document.createElement("div")
  match trans.Content.Properties.TryFind "class" with 
  | Some cls -> nc.className <- cls
  | _ -> ()
  let body = trans.Content.Element.innerHTML
  let title = 
    match trans.Content.Properties.TryFind "title" with 
    | Some t -> t 
    | _ -> failwithf "renderTransclusion: Missing title for: %s" trans.Content.ID
  nc.innerHTML <- 
    document.getElementById("transclusion-content-template").innerHTML
      .Replace("[TITLE]", title).Replace("[CONTENT]", body)
  renderTransclusions nc
  nc

and renderTransclusions out = 
  for child in getAllChildren out do 
    if child.tagName = "EMBED" then
      let embed = child :?> HTMLEmbedElement
      let ts = { Content = findContent embed.attributes.[unbox "src"].value }
      let nc = renderTransclusion ts
      child.parentElement.replaceChild(nc, child) |> ignore

let renderWindow state (win:HTMLDivElement) sec = 
  let key = sec.File + ";" + sec.ID
  if win.dataset.["displayed"] <> key then
    win.dataset.["displayed"] <- key
    let html = document.getElementById("display-template").innerHTML
    let title = 
      match sec.Properties.TryFind "title" with 
      | Some t -> t 
      | _ -> failwithf "renderWindow: Missing title for: %s,%s" sec.File sec.ID
    let nhtml = 
      html.Replace("[CONTENT]", sec.Element.innerHTML).Replace("[TITLE]", title)
        .Replace("[CLASS]", Option.defaultValue "" (sec.Properties.TryFind("class")))
    win.innerHTML <- nhtml
    renderTransclusions win
    expandLinks state win

let render state = 
  let ce = document.getElementById("display").children
  for i in 0 .. ce.length-1 do
    let found, sec = state.Displays.TryGetValue ce.[i].id 
    let displ = ce.[i] :?> HTMLDivElement
    displ.classList.remove("hidden")
    displ.classList.remove("visible")
    displ.classList.add(if found then "visible" else "hidden")
    if found then renderWindow state displ sec
    if found then 
      let inputs = getAllChildren displ |> Seq.filter (fun el -> el.tagName = "INPUT" && (el.id.StartsWith("cd") || el.id.StartsWith("cs")))
      for inp in inputs do 
        let inp = inp :?> HTMLInputElement
        inp.onchange <- fun _ -> 
          let els = document.getElementsByClassName(inp.id.Substring(1)) 
          for i in 0 .. els.length-1 do els.[i]?style?display <- if inp.``checked`` then "" else "none"

    if found && displ.id = "image" then
      let img = getAllChildren displ |> Seq.find (fun el -> el.tagName = "IMG") 
      img.onload <- fun _ ->
        let w = int img.clientWidth+200
        let l = max 0 (int window.document.body.clientWidth - w) / 2
        displ?style <- sprintf "max-width:100vw;width:%dpx;left:%dpx;" w l

  if state.Displays.ContainsKey "right" then
    let anch = document.getElementsByClassName(state.Displays.["right"].File.Replace("/","-") + "-anchor")
    let right = document.getElementById("right")
    right?style?paddingTop <- ""
    if anch.length > 0 then
      right?style?paddingTop <- $"{anch.[0]?offsetTop - right?offsetTop}px"

let initial = "splash=index,welcome"

let parseLinks link = 
  parseKvpList link |> Map.map (fun _ link -> findContent link)

window.onhashchange <- fun e -> 
  let links = if window.location.hash = "" then initial else window.location.hash.Replace("#", "")
  render { Displays = parseLinks links }

window.onhashchange null
