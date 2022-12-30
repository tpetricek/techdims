import { Union, Record } from "./fable_modules/fable-library.3.7.20/Types.js";
import { union_type, option_type, record_type, class_type, string_type } from "./fable_modules/fable-library.3.7.20/Reflection.js";
import { iterate, append as append_1, tryFind, singleton, map, collect, delay, toList } from "./fable_modules/fable-library.3.7.20/Seq.js";
import { FSharpMap__TryFind, FSharpMap__get_Item, ofSeq } from "./fable_modules/fable-library.3.7.20/Map.js";
import { rangeDouble } from "./fable_modules/fable-library.3.7.20/Range.js";
import { append, empty, singleton as singleton_1 } from "./fable_modules/fable-library.3.7.20/List.js";
import { replace, printf, toFail, join } from "./fable_modules/fable-library.3.7.20/String.js";
import Event$ from "./fable_modules/fable-library.3.7.20/Event.js";
import { map as map_1, equalsWith } from "./fable_modules/fable-library.3.7.20/Array.js";
import { toArray, map as map_2, defaultArg, defaultArgWith } from "./fable_modules/fable-library.3.7.20/Option.js";
import { createAtom, disposeSafe, getEnumerator } from "./fable_modules/fable-library.3.7.20/Util.js";
import { add } from "./fable_modules/fable-library.3.7.20/Observable.js";

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

export class State extends Record {
    constructor(Display1, Display2) {
        super();
        this.Display1 = Display1;
        this.Display2 = Display2;
    }
}

export function State$reflection() {
    return record_type("App.State", [], State, () => [["Display1", option_type(Section$reflection())], ["Display2", option_type(Section$reflection())]]);
}

export class PageEvent extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["LoadLink", "SetDisplays"];
    }
}

export function PageEvent$reflection() {
    return union_type("App.PageEvent", [], PageEvent, () => [[["Item", Section$reflection()]], [["Item1", option_type(Section$reflection())], ["Item2", option_type(Section$reflection())]]]);
}

export function getHashLink(state_1) {
    const getHash = (d, _arg) => {
        if (_arg != null) {
            const sec = _arg;
            return singleton_1(`${d}=${sec.File};${sec.ID}`);
        }
        else {
            return empty();
        }
    };
    return "#" + join(",", append(getHash("display1", state_1.Display1), getHash("display2", state_1.Display2)));
}

export function pushHistory(state_1) {
    window.history.pushState(null, null, getHashLink(state_1));
    return state_1;
}

export function update(evt, state_1) {
    if (evt.tag === 0) {
        const sec = evt.fields[0];
        return pushHistory(new State(state_1.Display1, sec));
    }
    else {
        const sec2 = evt.fields[1];
        const sec1 = evt.fields[0];
        return new State(sec1, sec2);
    }
}

export const triggerEvt = new Event$();

export const trigger = (arg) => {
    triggerEvt.Trigger(arg);
};

export class Transclusion extends Record {
    constructor(Content, Title, Link) {
        super();
        this.Content = Content;
        this.Title = Title;
        this.Link = Link;
    }
}

export function Transclusion$reflection() {
    return record_type("App.Transclusion", [], Transclusion, () => [["Content", option_type(Section$reflection())], ["Title", string_type], ["Link", Section$reflection()]]);
}

export function findContent(basefn, ref) {
    let patternInput;
    const matchValue = ref.split(";");
    if ((!equalsWith((x, y) => (x === y), matchValue, null)) && (matchValue.length === 1)) {
        const id = matchValue[0];
        patternInput = [basefn, id];
    }
    else if ((!equalsWith((x_1, y_1) => (x_1 === y_1), matchValue, null)) && (matchValue.length === 2)) {
        const id_1 = matchValue[1];
        const file = matchValue[0];
        patternInput = [file, id_1];
    }
    else {
        patternInput = toFail(printf("findContent: Invalid reference: %s"))(ref);
    }
    const id_2 = patternInput[1];
    const file_1 = patternInput[0];
    const sec_1 = tryFind((sec) => {
        if (sec.ID === id_2) {
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
        const tupledArg = [file_1, id_2];
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
            return toFail(printf("parseKvpList: Expected key value pair list, but got: %s"))(part);
        }
    }, list.split(",")));
}

export function parseTransclusion(basefn, info) {
    const kvps = parseKvpList(info);
    const matchValue = [FSharpMap__TryFind(kvps, "content"), FSharpMap__TryFind(kvps, "link"), FSharpMap__TryFind(kvps, "title")];
    if (matchValue[0] == null) {
        if (matchValue[1] != null) {
            const lref_1 = matchValue[1];
            const title_2 = matchValue[2];
            const link = findContent(basefn, lref_1);
            return new Transclusion(void 0, defaultArgWith(title_2, () => defaultArg(FSharpMap__TryFind(link.Properties, "title"), "")), link);
        }
        else {
            return toFail(printf("parseTransclusion: Missing title and content: %s"))(info);
        }
    }
    else if (matchValue[1] == null) {
        const cref_1 = matchValue[0];
        const title_1 = matchValue[2];
        const content_2 = findContent(basefn, cref_1);
        return new Transclusion(content_2, defaultArgWith(title_1, () => defaultArg(FSharpMap__TryFind(content_2.Properties, "title"), "")), content_2);
    }
    else {
        const cref = matchValue[0];
        const lref = matchValue[1];
        const title = matchValue[2];
        const content_1 = findContent(basefn, cref);
        const Link = findContent(basefn, lref);
        return new Transclusion(content_1, defaultArgWith(title, () => defaultArg(FSharpMap__TryFind(content_1.Properties, "title"), "")), Link);
    }
}

export function allChildren(el) {
    return toList(delay(() => collect((i) => append_1(singleton(el.children[i]), delay(() => allChildren(el.children[i]))), rangeDouble(0, 1, el.children.length - 1))));
}

export function renderTransclusion(state_1, basefn, trans) {
    const patternInput = (trans.Content != null) ? [document.createElement("div"), "transclusion-content-template"] : [document.createElement("span"), "transclusion-ref-template"];
    const templ = patternInput[1];
    const nc = patternInput[0];
    const patternInput_1 = [defaultArg(map_2((cont) => cont.Element.innerHTML, trans.Content), ""), defaultArg(map_2((cont_1) => cont_1.File, trans.Content), basefn)];
    const body = patternInput_1[0];
    const basefn_1 = patternInput_1[1];
    const hash1 = getHashLink(new State(trans.Link, void 0));
    const hash2 = getHashLink(new State(state_1.Display1, trans.Link));
    nc.innerHTML = replace(replace(replace(replace(document.getElementById(templ).innerHTML, "[TITLE]", trans.Title), "[CONTENT]", body), "[HASH1]", hash1), "[HASH2]", hash2);
    renderTransclusions(state_1, basefn_1, nc);
    return nc;
}

export function renderTransclusions(state_1, basefn, out) {
    const enumerator = getEnumerator(allChildren(out));
    try {
        while (enumerator["System.Collections.IEnumerator.MoveNext"]()) {
            const child = enumerator["System.Collections.Generic.IEnumerator`1.get_Current"]();
            if (child.tagName === "EMBED") {
                const embed = child;
                const nc = renderTransclusion(state_1, basefn, parseTransclusion(basefn, (embed.attributes["src"]).value));
                child.parentElement.replaceChild(nc, child);
            }
        }
    }
    finally {
        disposeSafe(enumerator);
    }
}

export function renderDisplay(state_1, display, sec) {
    const out = document.getElementById(display);
    out.style.display = ((sec != null) ? "block" : "none");
    iterate((sec_1) => {
        const key = (sec_1.File + ";") + sec_1.ID;
        if ((out.dataset["displayed"]) !== key) {
            out.dataset["displayed"]=key;
            const html = document.getElementById("display-template").innerHTML;
            const close = getHashLink(new State(state_1.Display1, void 0));
            const nhtml = replace(replace(html, "[CONTENT]", sec_1.Element.innerHTML), "[CLOSE]", close);
            out.innerHTML = nhtml;
            renderTransclusions(state_1, sec_1.File, out);
        }
    }, toArray(sec));
}

export function render(state_1) {
    renderDisplay(state_1, "display1", state_1.Display1);
    renderDisplay(state_1, "display2", state_1.Display2);
}

export let state = createAtom(new State(findContent("index", "main"), void 0));

add((evt) => {
    state(update(evt, state()), true);
    render(state());
}, triggerEvt.Publish);

window.onhashchange = ((e) => {
    const hash = (window.location.hash === "") ? "display1=index;main" : replace(window.location.hash, "#", "");
    const locs = parseKvpList(hash);
    const d1 = map_2((ref) => findContent("index", ref), FSharpMap__TryFind(locs, "display1"));
    const d2 = map_2((ref_1) => findContent("index", ref_1), FSharpMap__TryFind(locs, "display2"));
    trigger(new PageEvent(1, d1, d2));
});

window.onhashchange(null);

