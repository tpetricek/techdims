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

let rec toPlainText = function
  | MarkdownSpan.Literal(s, _) -> s
  | MarkdownPatterns.SpanNode(_, ss) -> String.concat "" (List.map toPlainText ss)
  | MarkdownPatterns.SpanLeaf _ -> ""

let citations = 
  let doc = Markdown.Parse(File.ReadAllText(Path.Combine(__SOURCE_DIRECTORY__, "data/bibliography.md")))
  let items = 
    match doc.Paragraphs with 
    | [ MarkdownParagraph.ListBlock(_, items, _) ] -> 
        let sorted = 
          [ for item in items do    
              match item with 
              | [ MarkdownParagraph.Span(MarkdownSpan.Literal(lit, _)::tl, _)] -> 
                  let i = lit.IndexOf(':')
                  let key = lit.Substring(0, i)
                  let body = MarkdownSpan.Literal(lit.Substring(i+1), None)::tl
                  let text = (String.concat "" (List.map toPlainText body)).Replace("\"", "'")
                  let body = [
                    yield MarkdownSpan.Literal($"""<a name="{key}" id="{key}">""",None)
                    yield! body 
                    yield MarkdownSpan.Literal($"</a>",None) ] 
                  lit.Substring(i+1), (key, body, text) 
              | _ -> failwith "citations: Incorrect item format" ] |> List.sortBy fst 
        [ for i, (_, (k, b, t)) in Seq.indexed sorted do
            k, i, MarkdownSpan.Literal($"""<span class="citationwrapper"><span class="citation">{i+1}</span></span>""", None)::b, t ]
    | _ -> failwith "citations: Unexpected document format"
  
  let lis = [ for k, i, its, t in items -> [ MarkdownParagraph.Span(its, None) ] ]
  let lookup = [ for k, i, its, t in items -> k, (i, t) ] |> dict
  let refs = MarkdownParagraph.ListBlock(MarkdownListKind.Ordered, lis, None)
  {| References = refs; Lookup = lookup |}

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
             [ "interaction"; "notation"; "conceptual-structure"; "customizability"; "complexity"; "errors"; "adoptability" ]
  let header = "<th></th>" + String.concat "" [ for n, id in systems -> $"<th class='s{id}'><a href='#footer=index,navigation;left=systems,index;right=systems/{id},overview;top=systems,intro'><i class=\"fa fa-arrow-right\"></i>  {n}</a></th>" ]
  let rows = [
    for dimName, dimId in dims -> dimId, $"<th><a href='#top=catalogue,index;left=catalogue,list;footer=index,navigation;right=dimensions/{dimId},index'><i class=\"fa fa-arrow-right\"></i> {dimName}</a></th>" + String.concat "" [
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

let (|SpecialLink|_|) = function
  | DirectLink([Literal("#", _)], cite, _, _) when citations.Lookup.ContainsKey cite ->
      let i, t = citations.Lookup.[cite]
      [ Literal($"""<a class="citation" href="#*=.;right=paper,references" title="{t}">{i+1}</a>""", None) ] |> Some
  | DirectLink(body, link, _, _) when link.StartsWith("->") -> 
      [ yield Literal($"<a class=\"tlink\" href=\"{link.Substring(3)}\"><i class=\"fa fa-arrow-right\"></i>", None)
        yield! body
        yield Literal("</a>", None) ] |> Some
  | DirectImage("$$", "matrix-table", _, _) ->
      [ Literal(genreateSummaryTableAndChecks().Table, None) ] |> Some
  | DirectImage("$$", "matrix-dimchecks", _, _) ->
      [ Literal(genreateSummaryTableAndChecks().DimChecks, None) ] |> Some
  | DirectImage("$$", "matrix-syschecks", _, _) ->
      [ Literal(genreateSummaryTableAndChecks().SysChecks, None) ] |> Some
  | DirectImage("$", cnt, _, _) ->
      [ Literal($"<embed type=\"application/transclusion\" src=\"{cnt}\" />", None) ] |> Some
  | _ -> None

let rec replaceTransclusions = function
  | MarkdownPatterns.ParagraphNested(p, ps) -> 
      MarkdownPatterns.ParagraphNested(p, List.map (List.map replaceTransclusions) ps)
  | MarkdownParagraph.Paragraph([ SpecialLink ss ], _) -> 
      MarkdownParagraph.Span(ss, None)
  | MarkdownParagraph.Paragraph([ DirectImage("$$", "references", _, _) ], _) ->
      citations.References
  | MarkdownPatterns.ParagraphSpans(s, ss) -> 
      let ss = ss |> List.collect (function SpecialLink ss -> ss | s -> [s])
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
        let opts, extras = 
          if opts.ContainsKey "shade" && opts.ContainsKey "characteristics" && not (opts.ContainsKey "title") then
            let chars = opts.["characteristics"].Split(",") |> Seq.map (fun c -> characteristics.[c.Trim()])
            let icons = String.concat "" [ for fa, info in chars -> $"<i class='fa {fa}' title='{info}'></i>" ]
            let list = String.concat "" [ for fa, info in chars -> $"<li><i class='fa {fa}'></i>{info}</li>" ]
            let title = $"""<div class='{opts.["shade"]}'>{icons}</div>"""
            opts.Add("title", title), Some($"<ul class='details'>{list}</ul>")
          else opts, None
        let data = String.concat "" [ for kvp in opts -> $" data-{kvp.Key}=\"{kvp.Value}\"" ]
        yield InlineHtmlBlock($"<section{data}>", None, None)
        yield! section
        if extras.IsSome then yield InlineHtmlBlock(extras.Value, None, None)
        yield InlineHtmlBlock($"</section>", None, None) ]

let doc = MarkdownDocument(sections, links)
let html = Markdown.ToHtml(doc)
let out = File.ReadAllText("content/template.html").Replace("[BODY]", html)
File.WriteAllText("public/index.html", out)



