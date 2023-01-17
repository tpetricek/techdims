#r "nuget:FSharp.Formatting"
open System
open System.IO
open System.Text.RegularExpressions
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
  
let characteristics = 
  let reg = Regex("\s*\(([a-z\-]*)\)\s-\s(.*)")
  let doc = Markdown.Parse(File.ReadAllText(Path.Combine(__SOURCE_DIRECTORY__, "data/characteristics.md")))
  [ for p in doc.Paragraphs do
      match p with 
      | MarkdownParagraph.ListBlock(_, its, _) ->
          for it in its do 
            match it with 
            | [ MarkdownParagraph.Span
                  ( [ MarkdownSpan.Strong([ MarkdownSpan.Literal(key, _) ], _); 
                      MarkdownSpan.Literal(info, _) ], _) ] -> 
                      let m = reg.Match(info)
                      yield key, (m.Groups.[1].Value, m.Groups.[2].Value)
            | _ -> failwith "characteristics: Failed parsing the data file"
      | _ -> () ] |> dict

let genreateSummaryTableAndChecks () = 
  let systems = 
    List.zip [ "LISP machines"; "Smalltalk"; "UNIX"; "Spreadsheets"; "Web platform"; "Hypercard"; "Boxer"; "Notebooks"; "Haskell" ]
             [ "lisp-machines"; "smalltalk"; "unix"; "spreadsheets"; "web"; "hypercard"; "boxer"; "notebooks"; "haskell" ]
  let dims = 
    List.zip [ "Interaction"; "Notation"; "Conceptual structure"; "Customizability"; "Complexity"; "Errors"; "Adoptability" ]
             [ "interaction"; "notation"; "conceptual"; "customizability"; "complexity"; "errors"; "adoptability" ]
  let header = "<th></th>" + String.concat "" [ for n, id in systems -> $"<th class='s{id}'>{n}</th>" ]
  let rows = [
    for dimName, dimId in dims -> dimId, $"<th>{dimName}</th>" + String.concat "" [
      for sysName, sysId in systems -> 
        $"<td class='s{sysId}'><embed type=\"application/transclusion\" src=\"systems/{sysId},dims-{dimId}\" data-links=\"#left=index,matrix;right=systems/{sysId},index\" /></td>"
    ]
  ]
  let body = String.concat "" [ for id, r in rows -> $"<tr class='d{id}'>{r}</tr>" ]
  let systems = String.concat "" [ 
    for n, id in systems -> $"""<label><input type="checkbox" class="csys" id="cs{id}" name="cs{id}" checked>{n}</label>""" ]
  let dims = String.concat "" [
    for n, id in dims -> $"""<label><input type="checkbox" class="cdim" id="cd{id}" name="cd{id}" checked>{n}</label>""" ]
  {| Table = $"""<div class="table-wrapper"><table><tr>{header}</tr>{body}</table></div>""";
     SysChecks = systems; DimChecks = dims |}

let rec replaceTransclusions = function
  | MarkdownPatterns.ParagraphNested(p, ps) -> 
      MarkdownPatterns.ParagraphNested(p, List.map (List.map replaceTransclusions) ps)
  | MarkdownPatterns.ParagraphSpans(s, ss) -> 
      let ss = ss |> List.collect (function
        | DirectLink(body, link, title, range) when link.StartsWith("->") -> 
            [ yield Literal($"<a class=\"tlink\" href=\"{link.Substring(3)}\"><i class=\"fa fa-arrow-right\"></i>", None)
              yield! body
              yield Literal("</a>", None) ]
        | DirectImage("$$", "matrix-table", _, _) ->
            [ Literal(genreateSummaryTableAndChecks().Table, None) ]
        | DirectImage("$$", "matrix-dimchecks", _, _) ->
            [ Literal(genreateSummaryTableAndChecks().DimChecks, None) ]
        | DirectImage("$$", "matrix-syschecks", _, _) ->
            [ Literal(genreateSummaryTableAndChecks().SysChecks, None) ]
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
        let opts = 
          if opts.ContainsKey "shade" && opts.ContainsKey "characteristics" && not (opts.ContainsKey "title") then
            let icons = 
              String.concat "" [ 
                for c in opts.["characteristics"].Split(",") -> 
                  let fa, info = characteristics.[c.Trim()] 
                  $"<i class='fa {fa}' title='{info}'></i>" ]
            let title = $"""<div class='{opts.["shade"]}'>{icons}</div>"""
            opts.Add("title", title)
          else opts
        let data = String.concat "" [ for kvp in opts -> $" data-{kvp.Key}=\"{kvp.Value}\"" ]
        yield InlineHtmlBlock($"<section{data}>", None, None)
        yield! section
        yield InlineHtmlBlock($"</section>", None, None) ]

let doc = MarkdownDocument(sections, links)
let html = Markdown.ToHtml(doc)
let out = File.ReadAllText("content/template.html").Replace("[BODY]", html)
File.WriteAllText("public/index.html", out)



