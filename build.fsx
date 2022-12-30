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
  
let rec replaceTransclusions = function
  | MarkdownPatterns.ParagraphNested(p, ps) -> 
      MarkdownPatterns.ParagraphNested(p, List.map (List.map replaceTransclusions) ps)
  | MarkdownPatterns.ParagraphSpans(s, ss) -> 
      let ss = ss |> List.map (function
        | DirectImage("$", ref, _, _) ->
            Literal($"<embed type=\"application/transclusion\" src=\"{ref}\" />", None)
        | s -> s)
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



