#r "nuget:FSharp.Formatting"
open System
open System.IO
open FSharp.Formatting
open FSharp.Formatting.Markdown

Environment.CurrentDirectory <- __SOURCE_DIRECTORY__

let parseOptions pars = 
  pars 
  |> List.map (function 
    | [Span([Literal(lit, _)], _)] ->
        let col = lit.IndexOf(':')
        lit.Substring(0, col).Trim(), 
        lit.Substring(col+1).Trim()
    | li ->
        failwithf "Option is not a simple literal")
  |> Map.ofSeq

let (|LongHorizontalRule|_|) = function
  | HorizontalRule(c, Some r) when r.EndColumn > 40 -> Some(c)
  | _ -> None

let (|As|) v x = v, x

let extractSections pars = 
  let rec loop opts section acc pars = 
    match pars with
    | LongHorizontalRule _ :: 
      ListBlock(_, items, _) :: pars 
    | LongHorizontalRule _ :: As [] (items, pars) ->
        let acc = if section <> [] then (parseOptions opts, List.rev section)::acc else acc
        loop items [] acc pars
    | par :: pars ->
        loop opts (par::section) acc pars 
    | [] ->
        let acc = if section <> [] then (parseOptions opts, List.rev section)::acc else acc
        List.rev acc
  loop [] [] [] pars
  
let genreateSummaryTable () = 
  let systems = 
    List.zip [ "LISP machines"; "Smalltalk"; "UNIX"; "Spreadsheets"; "Web platform"; "Hypercard"; "Boxer"; "Notebooks"; "Haskell" ]
             [ "lisp-machines"; "smalltalk"; "unix"; "spreadsheets"; "web"; "hypercard"; "boxer"; "notebooks"; "haskell" ]
  let dims = 
    List.zip [ "Interaction"; "Notation"; "Conceptual structure"; "Customizability"; "Complexity"; "Errors"; "Adoptability" ]
             [ "interaction"; "notation"; "conceptual"; "customizability"; "complexity"; "errors"; "adoptability" ]
  let header = "<th></th>" + String.concat "" [ for n, _ in systems -> $"<th>{n}" ]
  let rows = [
    for dimName, dimId in dims -> $"<th>{dimName}</th>" + String.concat "" [
      for sysName, sysId in systems -> 
        $"<td><embed type=\"application/transclusion\" src=\"systems/{sysId},dims-{dimId}\" data-links=\"#left=systems/{sysId}],index\" /></td>"
    ]
  ]
  let body = String.concat "" [ for r in rows -> $"<tr>{r}</tr>" ]
  $"<div class=\"table-wrapper\"><table><tr>{header}</tr>{body}</table></div>"

let rec replaceTransclusions = function
  | MarkdownPatterns.ParagraphNested(p, ps) -> 
      MarkdownPatterns.ParagraphNested(p, List.map (List.map replaceTransclusions) ps)
  | MarkdownPatterns.ParagraphSpans(s, ss) -> 
      let ss = ss |> List.collect (function
        | DirectLink(body, link, title, range) when link.StartsWith("->") -> 
            [ yield Literal($"<a class=\"tlink\" href=\"{link.Substring(3)}\"><i class=\"fa fa-arrow-right\"></i>", None)
              yield! body
              yield Literal("</a>", None) ]
        | DirectImage("$$", "summary-table", _, _) ->
            [ Literal(genreateSummaryTable(), None) ]
        | DirectImage(cnt, links, _, _) when cnt.StartsWith("$") ->
            [ Literal($"<embed type=\"application/transclusion\" src=\"{cnt.Substring(1)}\" data-links=\"{links}\" />", None) ]
        | s -> [ s ])
      MarkdownPatterns.ParagraphSpans(s, ss)
  | p -> p

let readDocument fn =
  let doc = Markdown.Parse(File.ReadAllText(fn))
  let pars = doc.Paragraphs |> List.map replaceTransclusions
  doc.DefinedLinks,
  [ for opts, section in extractSections pars do
      let fn = fn.Replace("content\\", "").Replace('\\', '/').Replace(".md", "")
      yield opts.Add("file", fn), section ]

let mds = Directory.GetFiles("content", "*.md", EnumerationOptions(RecurseSubdirectories=true))
let links = Collections.Generic.Dictionary<_, _>()
let sections = 
  [ for fn in mds do 
      let flinks, sections = readDocument fn
      for kvp in flinks do links.Add(kvp.Key, kvp.Value)
      for opts, section in sections do
        let data = String.concat "" [ for kvp in opts -> $" data-{kvp.Key}=\"{kvp.Value}\"" ]
        yield InlineHtmlBlock($"<section{data}>", None, None)
        yield! section
        yield InlineHtmlBlock($"</section>", None, None) ]

let doc = MarkdownDocument(sections, links)
let html = Markdown.ToHtml(doc)
let out = File.ReadAllText("content/template.html").Replace("[BODY]", html)
File.WriteAllText("public/index.html", out)



