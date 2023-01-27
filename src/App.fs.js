import { FSharpRef, Record } from "./fable_modules/fable-library.3.7.20/Types.js";
import { option_type, record_type, class_type, string_type } from "./fable_modules/fable-library.3.7.20/Reflection.js";
import { filter, find, fold, append, tryFind, singleton, map, collect, delay, toList } from "./fable_modules/fable-library.3.7.20/Seq.js";
import { FSharpMap__TryGetValue, FSharpMap__TryFind, map as map_2, FSharpMap__Remove, FSharpMap__Add, FSharpMap__get_Keys, FSharpMap__ContainsKey, FSharpMap__get_Item, ofSeq } from "./fable_modules/fable-library.3.7.20/Map.js";
import { rangeDouble } from "./fable_modules/fable-library.3.7.20/Range.js";
import { toText, replace, printf, toFail, substring, join } from "./fable_modules/fable-library.3.7.20/String.js";
import { map as map_1, equalsWith } from "./fable_modules/fable-library.3.7.20/Array.js";
import { comparePrimitives, max, disposeSafe, getEnumerator } from "./fable_modules/fable-library.3.7.20/Util.js";
import { defaultArg } from "./fable_modules/fable-library.3.7.20/Option.js";

export class Section extends Record {
    constructor(Properties, ID, File, Element$) {
        super();
        this.Properties = Properties;
        this.ID = ID;
        this.File = File;
        this.Element = Element$;
    }
}

export function Section$reflection() {
    return record_type("App.Section", [], Section, () => [["Properties", class_type("Microsoft.FSharp.Collections.FSharpMap`2", [string_type, string_type])], ["ID", string_type], ["File", string_type], ["Element", class_type("Browser.Types.HTMLElement")]]);
}

export const content = toList(delay(() => {
    const sections = document.getElementsByTagName("section");
    return collect((i) => {
        const sec = sections[i];
        const props = ofSeq(toList(delay(() => map((k) => [k, sec.dataset[k]], Object.keys(sec.dataset)))));
        return singleton(new Section(props, FSharpMap__get_Item(props, "id"), FSharpMap__get_Item(props, "file"), sec));
    }, rangeDouble(0, 1, sections.length - 1));
}));

export class Display extends Record {
    constructor(Content, Navigation) {
        super();
        this.Content = Content;
        this.Navigation = Navigation;
    }
}

export function Display$reflection() {
    return record_type("App.Display", [], Display, () => [["Content", Section$reflection()], ["Navigation", option_type(string_type)]]);
}

export class State extends Record {
    constructor(Displays) {
        super();
        this.Displays = Displays;
    }
}

export function State$reflection() {
    return record_type("App.State", [], State, () => [["Displays", class_type("Microsoft.FSharp.Collections.FSharpMap`2", [string_type, Display$reflection()])]]);
}

export function getHashLink(state) {
    const getHash = (d, sec) => (`${d}=${sec.File};${sec.ID}`);
    return "#" + join(",", toList(delay(() => map((kvp) => getHash(kvp[0], kvp[1]), state))));
}

export class Transclusion extends Record {
    constructor(Content) {
        super();
        this.Content = Content;
    }
}

export function Transclusion$reflection() {
    return record_type("App.Transclusion", [], Transclusion, () => [["Content", Section$reflection()]]);
}

export function findContent(ref) {
    const col = ref.indexOf(":") | 0;
    const ref_1 = (col !== -1) ? substring(ref, col + 1) : ref;
    let patternInput;
    const matchValue = ref_1.split(",");
    if ((!equalsWith((x, y) => (x === y), matchValue, null)) && (matchValue.length === 2)) {
        const id = matchValue[1];
        const file = matchValue[0];
        patternInput = [file, id];
    }
    else {
        patternInput = toFail(printf("findContent: Invalid reference: \u0027%s\u0027"))(ref_1);
    }
    const id_1 = patternInput[1];
    const file_1 = patternInput[0];
    const sec_1 = tryFind((sec) => {
        if (sec.ID === id_1) {
            return sec.File === file_1;
        }
        else {
            return false;
        }
    }, content);
    if (sec_1 != null) {
        const sec_2 = sec_1;
        return sec_2;
    }
    else {
        const tupledArg = [file_1, id_1];
        return toFail(printf("findContent: Failed to find content: %A"))([tupledArg[0], tupledArg[1]]);
    }
}

export function parseKvpList(list) {
    return ofSeq(map_1((part) => {
        const matchValue = part.trim().split("=");
        if ((!equalsWith((x, y) => (x === y), matchValue, null)) && (matchValue.length === 2)) {
            const v = matchValue[1];
            const k = matchValue[0];
            return [k.trim(), v.trim()];
        }
        else {
            return toFail(printf("parseKvpList: Expected key value pair list, but got: %s"))(list);
        }
    }, list.split(";")));
}

export function getAllChildren(el) {
    return toList(delay(() => append(singleton(el), delay(() => collect((i) => getAllChildren(el.children[i]), rangeDouble(0, 1, el.children.length - 1))))));
}

export function expandLinks(state, el) {
    const enumerator = getEnumerator(getAllChildren(el));
    try {
        while (enumerator["System.Collections.IEnumerator.MoveNext"]()) {
            const c = enumerator["System.Collections.Generic.IEnumerator`1.get_Current"]();
            if (c.tagName === "A") {
                const a = c;
                if ((a.attributes["href"]).value.indexOf("#") === 0) {
                    const links = parseKvpList(substring((a.attributes["href"]).value, 1));
                    let links_2;
                    if (FSharpMap__ContainsKey(links, "*")) {
                        const source = FSharpMap__get_Keys(state.Displays);
                        links_2 = fold((links_1, k) => {
                            if (FSharpMap__ContainsKey(links_1, k)) {
                                return links_1;
                            }
                            else {
                                return FSharpMap__Add(links_1, k, ".");
                            }
                        }, FSharpMap__Remove(links, "*"), source);
                    }
                    else {
                        links_2 = links;
                    }
                    const links_3 = map_2((k_1, v) => {
                        if (v === ".") {
                            return (FSharpMap__get_Item(state.Displays, k_1).Content.File + ",") + FSharpMap__get_Item(state.Displays, k_1).Content.ID;
                        }
                        else {
                            return v;
                        }
                    }, links_2);
                    const href = "#" + join(";", toList(delay(() => map((kvp) => (`${kvp[0]}=${replace(kvp[1], "!", "")}`), links_3))));
                    (a.attributes["href"]).value = href;
                    if (a.text === "!") {
                        const title = find((kvp_1) => (kvp_1[1].indexOf("!") >= 0), links_3);
                        const sec = findContent(replace(title[1], "!", ""));
                        a.innerHTML = replace(a.innerHTML, "!", FSharpMap__get_Item(sec.Properties, "title"));
                    }
                }
            }
        }
    }
    finally {
        disposeSafe(enumerator);
    }
}

export function renderTransclusion(trans) {
    const nc = document.createElement("div");
    const matchValue = FSharpMap__TryFind(trans.Content.Properties, "class");
    if (matchValue != null) {
        const cls = matchValue;
        nc.className = cls;
    }
    const body = trans.Content.Element.innerHTML;
    let title;
    const matchValue_1 = FSharpMap__TryFind(trans.Content.Properties, "title");
    if (matchValue_1 != null) {
        const t = matchValue_1;
        title = t;
    }
    else {
        title = toFail(printf("renderTransclusion: Missing title for: %s"))(trans.Content.ID);
    }
    nc.innerHTML = replace(replace(document.getElementById("transclusion-content-template").innerHTML, "[TITLE]", title), "[CONTENT]", body);
    renderTransclusions(nc);
    return nc;
}

export function renderTransclusions(out) {
    const enumerator = getEnumerator(getAllChildren(out));
    try {
        while (enumerator["System.Collections.IEnumerator.MoveNext"]()) {
            const child = enumerator["System.Collections.Generic.IEnumerator`1.get_Current"]();
            if (child.tagName === "EMBED") {
                const embed = child;
                const ts = new Transclusion(findContent((embed.attributes["src"]).value));
                const nc = renderTransclusion(ts);
                child.parentElement.replaceChild(nc, child);
            }
        }
    }
    finally {
        disposeSafe(enumerator);
    }
}

export function renderWindow(state, win, sec) {
    const key = (sec.File + ";") + sec.ID;
    if ((win.dataset["displayed"]) !== key) {
        win.dataset["displayed"]=key;
        const html = document.getElementById("display-template").innerHTML;
        let title;
        const matchValue = FSharpMap__TryFind(sec.Properties, "title");
        if (matchValue != null) {
            const t = matchValue;
            title = t;
        }
        else {
            title = toFail(printf("renderWindow: Missing title for: %s,%s"))(sec.File)(sec.ID);
        }
        const nhtml = replace(replace(replace(html, "[CONTENT]", sec.Element.innerHTML), "[TITLE]", title), "[CLASS]", defaultArg(FSharpMap__TryFind(sec.Properties, "class"), ""));
        win.innerHTML = nhtml;
        renderTransclusions(win);
        expandLinks(state, win);
    }
}

export function render(state) {
    const ce = document.getElementById("display").children;
    for (let i = 0; i <= (ce.length - 1); i++) {
        let patternInput;
        let outArg = null;
        patternInput = [FSharpMap__TryGetValue(state.Displays, (ce[i]).id, new FSharpRef(() => outArg, (v) => {
            outArg = v;
        })), outArg];
        const sec = patternInput[1];
        const found = patternInput[0];
        const displ = ce[i];
        displ.classList.remove("hidden");
        displ.classList.remove("visible");
        displ.classList.add(found ? "visible" : "hidden");
        if (found) {
            renderWindow(state, displ, sec.Content);
        }
        if (found) {
            const inputs = filter((el) => {
                if (el.tagName === "INPUT") {
                    if (el.id.indexOf("cd") === 0) {
                        return true;
                    }
                    else {
                        return el.id.indexOf("cs") === 0;
                    }
                }
                else {
                    return false;
                }
            }, getAllChildren(displ));
            const enumerator = getEnumerator(inputs);
            try {
                while (enumerator["System.Collections.IEnumerator.MoveNext"]()) {
                    const inp = enumerator["System.Collections.Generic.IEnumerator`1.get_Current"]();
                    const inp_1 = inp;
                    inp_1.onchange = ((_arg) => {
                        const els = document.getElementsByClassName(substring(inp_1.id, 1));
                        for (let i_1 = 0; i_1 <= (els.length - 1); i_1++) {
                            (els[i_1]).style.display = (inp_1.checked ? "" : "none");
                        }
                    });
                }
            }
            finally {
                disposeSafe(enumerator);
            }
        }
        if (found && (displ.id === "image")) {
            const img = find((el_1) => (el_1.tagName === "IMG"), getAllChildren(displ));
            img.onload = ((_arg_1) => {
                const w = ((~(~img.clientWidth)) + 200) | 0;
                const l = (~(~(max(comparePrimitives, 0, (~(~window.document.body.clientWidth)) - w) / 2))) | 0;
                displ.style = toText(printf("max-width:100vw;width:%dpx;left:%dpx;"))(w)(l);
            });
        }
    }
    const scrollTo = (y_1) => {
        window.setTimeout((_arg_2) => {
            window.scrollTo(0, y_1);
        }, 1);
    };
    if (FSharpMap__ContainsKey(state.Displays, "right")) {
        let anch_2;
        const right = FSharpMap__get_Item(state.Displays, "right");
        let anch_1;
        const matchValue = right.Navigation;
        if (matchValue != null) {
            const anch = matchValue;
            anch_1 = (anch + "-anchor");
        }
        else {
            anch_1 = (replace(right.Content.File, "/", "-") + "-anchor");
        }
        anch_2 = document.getElementsByClassName(anch_1);
        const right_1 = document.getElementById("right");
        right_1.style.paddingTop = "";
        if (anch_2.length > 0) {
            right_1.style.paddingTop = (`${((anch_2[0]).offsetTop - right_1.offsetTop)}px`);
            scrollTo((anch_2[0]).offsetTop);
        }
        else {
            scrollTo(0);
        }
    }
    else {
        scrollTo(0);
    }
}

export const initial = "top=index,welcome";

export function parseLinks(link) {
    return map_2((_arg, link_1) => {
        const col = link_1.indexOf(":") | 0;
        const Navigation = (col !== -1) ? substring(link_1, 0, col) : (void 0);
        return new Display(findContent(link_1), Navigation);
    }, parseKvpList(link));
}

window.onhashchange = ((e) => {
    const links = (window.location.hash === "") ? initial : replace(window.location.hash, "#", "");
    render(new State(parseLinks(links)));
});

window.onhashchange(null);

