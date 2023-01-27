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

type Display = 
  { Content : Section   
    Navigation : string option }

type State = 
  { Displays : Map<string, Display> }

let getHashLink (state:Map<_, _>) = 
  let getHash d sec = $"{d}={sec.File};{sec.ID}"
  "#" + String.concat "," [ for kvp in state -> getHash kvp.Key kvp.Value ]

type Transclusion = 
  { Content : Section }

let findContent (ref:string) = 
  let col = ref.IndexOf(':')
  let ref = if col <> -1 then ref.Substring(col+1) else ref
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
        let links = a.attributes.[unbox "href"].value.Substring(1) |> parseKvpList 
        let links = 
          if links.ContainsKey "*" then state.Displays.Keys |> Seq.fold (fun (links:Map<_, _>) k -> 
            if links.ContainsKey k then links else links.Add(k, ".")) (links.Remove("*"))
          else links
        let links = links |> Map.map (fun k v ->
          if v = "." then state.Displays.[k].Content.File + "," + state.Displays.[k].Content.ID else v)
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

let titlePreferences = [ "right"; "left"; "image" ]

let render state = 
  let ce = document.getElementById("display").children
  for i in 0 .. ce.length-1 do
    let found, sec = state.Displays.TryGetValue ce.[i].id 
    let displ = ce.[i] :?> HTMLDivElement
    displ.classList.remove("hidden")
    displ.classList.remove("visible")
    displ.classList.add(if found then "visible" else "hidden")
    if found then renderWindow state displ sec.Content
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
  
  let scrollTo y =
    window.setTimeout((fun _ -> window.scrollTo(0, y)), 1) |> ignore

  let right = document.getElementById("right")
  let anch = 
    if state.Displays.ContainsKey "right" then    
      let anch = 
        let rdispl = state.Displays.["right"]
        let anch = 
          match rdispl.Navigation with 
          | Some anch -> anch + "-anchor"
          | _ -> rdispl.Content.File.Replace("/","-") + "-anchor"
        document.getElementsByClassName(anch)
      right?style?paddingTop <- ""
      if anch.length > 0 then Some(anch.[0])
      else None
    else None

  if anch.IsSome then
    right?style?paddingTop <- $"{anch.Value?offsetTop - right?offsetTop}px"
    scrollTo (anch.Value?offsetTop)
  else scrollTo 0

  let anchPart = anch |> Option.bind (fun el -> try Some(el?firstElementChild?firstElementChild?innerText) with _ -> None) |> Option.toList
  let titleOpt = titlePreferences |> List.tryPick(fun display -> 
    state.Displays.TryFind(display) |> Option.map (fun displ -> displ.Content.Properties.["title"]))
  let title = Option.toList titleOpt @ anchPart @ [ "Technical dimensions of programming systems" ] |> String.concat " | "
  document.title <- title



let initial = "top=index,welcome"

let parseLinks link = 
  parseKvpList link |> Map.map (fun _ (link:string) -> 
    let col = link.IndexOf(':') 
    { Navigation = if col <> -1 then Some(link.Substring(0, col)) else None
      Content = findContent link })

window.onhashchange <- fun e -> 
  let links = if window.location.hash = "" then initial else window.location.hash.Replace("#", "")
  render { Displays = parseLinks links }

window.onhashchange null
