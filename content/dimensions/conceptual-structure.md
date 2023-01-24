----------------------------------------------------------------------------------------------------
- id:summary
- title: Conceptual structure
- class: dimensions-conceptual-structure-anchor nobullet

# <i class="fa fa-cubes"></i> Conceptual structure [Description and relations...](-> #*=.;right=dimensions/conceptual-structure,index)

How is meaning constructed? How are internal and external incentives balanced?

## Dimensions

- Does the system present as elegantly designed or pragmatically improvised?  
  [!](-> #*=.;right=dimensions/conceptual-structure,integrity-openness!)
- What are the primitives? How can they be combined to achieve novel behaviors?  
  [!](-> #*=.;right=dimensions/conceptual-structure,composability!)
- Which wheels do users not need to reinvent?  
  [!](-> #*=.;right=dimensions/conceptual-structure,convenience!)
- How much is common structure explicitly marked as such?  
  [!](-> #*=.;right=dimensions/conceptual-structure,commonality!)

## Examples & remarks

- [!](-> #*=.;right=dimensions/conceptual-structure,example-integrity!)
- [!](-> #*=.;right=dimensions/conceptual-structure,example-openness!)
- [!](-> #*=.;right=dimensions/conceptual-structure,flattening-factoring!)
- [!](-> #*=.;right=dimensions/conceptual-structure,end-of-history!)


----------------------------------------------------------------------------------------------------
- id:index
- title: Conceptual structure

# Conceptual structure

**How is meaning constructed? How are internal and external incentives balanced?**

For more information, refer to the primary technical dimension of this cluster and its two extreme ends:

<div class="nobullet">

- [!](-> #*=.;right=dimensions/conceptual-structure,integrity-openness!)
- [!](-> #*=.;right=dimensions/conceptual-structure,example-integrity!)
- [!](-> #*=.;right=dimensions/conceptual-structure,example-openness!)

</div>

## References
- How to Design a Good API and Why it Matters [#](APIdesign) 

----------------------------------------------------------------------------------------------------
- id:integrity-openness
- title:Dimension: Conceptual integrity versus openness

# Dimension: Conceptual integrity versus openness

The evolution of programming systems has led away from *conceptual integrity* towards an intricate ecosystem of specialized technologies and industry standards. Any attempt to unify parts of this ecosystem into a coherent whole will create *incompatibility* with the remaining parts, which becomes a major barrier to adoption. Designers seeking adoption are pushed to focus on localized incremental improvements that stay within the boundaries established by existing practice. This creates a tension between how highly they can afford to value conceptual elegance, and how open they are to the pressures imposed by society. We will turn to both of these opposite ends---*integrity* and *openness*---in more detail.

## Related examples

<div class="nobullet">

- [!](-> #*=.;right=dimensions/conceptual-structure,example-integrity!)
- [!](-> #*=.;right=dimensions/conceptual-structure,example-openness!)

</div>

----------------------------------------------------------------------------------------------------
- id:example-integrity
- title:Example: Conceptual integrity
- class:doc

# Example: Conceptual integrity

> I will contend that Conceptual Integrity is the most important consideration in system design. It is better to have a system omit certain anomalous features and improvements, but to reflect one set of design ideas, than to have one that contains many good but independent and uncoordinated ideas. 
> 
> Fred Brooks, *Aristocracy, Democracy and System Design* [#](brooks95aristo)

<div></div>

> Conceptual integrity arises not (simply) from one mind or from a small number of agreeing resonant minds, but from sometimes hidden co-authors and the thing designed itself. 
>
> Richard Gabriel, *Designed As Designer* [#](DesignedAsDesigner)

Conceptual integrity strives to reduce complexity at the source; it employs *unified concepts* that may *compose orthogonally* to generate diversity. Perhaps the apotheosis of this approach can be found in early Smalltalk and Lisp machines, which were complete programming systems built around a single language. They incorporated capabilities commonly provided *outside* the programming language by operating systems and databases. Everything was done in one language, and so everything was represented with the datatypes of that language. Likewise the libraries and idioms of the language were applicable in all contexts. Having a *lingua franca* avoided much of the friction and impedance mismatches inherent to multi-language systems. A similar drive exists in the Python programming language, which follows the principle that “There should be one---and preferably only one---obvious way to do it” in order to promote community consensus on a single coherent style.

## Memory models of programming langauges

In addition to Smalltalk and Lisp, many programming languages focus on one kind of data structure. As pointed out by Kragen Javier Sitaker: [#](MemMod)

<div class="narrow">

- In COBOL, data consists of nested records as in a business form.
- In Fortran, data consists of parallel arrays.
- In SQL, data is a set of relations with key constraints.
- In scripting languages like Python, Ruby, and Lua, much data takes the form of string-indexed hash tables.

</div>

Finally, many languages are _imperative_, staying close to the hardware model of addressable memory, lightly abstracted into primitive values and references into mutable arrays and structures. On the other hand, _functional_ languages hide references and treat everything as immutable structured values. This conceptual simplification benefits certain kinds of programming, but can be counterproductive when an imperative approach is more natural, such as in external input/output.

----------------------------------------------------------------------------------------------------
- id:example-openness
- title:Example: Conceptual openness

# Example: Conceptual openness

## Perl, contra Python
In contrast to Python's outlook, Perl proclaims “There is more than one way to do it” and considers itself “the first postmodern programming language”. [#](Perl) “Perl doesn't have any agenda at all, other than to be maximally useful to the maximal number of people. To be the duct tape of the Internet, and of everything else.” The Perl way is to accept the status quo of evolved chaos and build upon it using duct tape and ingenuity. Taken to the extreme, a programming system becomes no longer a *system*, properly speaking, but rather a *toolkit for improvising* assemblages of *found* software. Perl can be seen as championing the values of *pluralism*, *compatibility*, or *conceptual openness* over conceptual integrity. This philosophy has been called _Postmodern Programming_. [#](PoMoProNotes)

## C\++, contra Smalltalk
Another case is that of C\++, which added to C the Object-Oriented concepts developed by Smalltalk while remaining 100% compatible with C, down to the level of ABI and performance. This strategy was enormously successful for adoption, but came with the tradeoff of enormous complexity compared to languages designed from scratch for OO, like Smalltalk, Ruby, and Java.

## Worse, contra Better
Richard Gabriel first described this dilemma in his influential 1991 essay *Worse is Better* [#](WIB) analyzing the defeat of Lisp by UNIX and C. Because UNIX and C were so easy to port to new hardware, they were “the ultimate computer viruses” despite providing only “about 50%--80% of what you want from an operating system and programming language”. Their conceptual openness meant that they adapted easily to the evolving conditions of the external world. The tradeoff was decreased conceptual integrity, such as the undefined behaviours of C, the junkyard of working directories, and the proliferation of special purpose programming languages to provide a complete development environment.


## UNIX and Files
Many programming languages and systems impose structure at a "fine granularity": that of individual variables and other data and code structures. Conversely, systems like UNIX and the Web impose fewer restrictions on how programmers represent things. UNIX insists only on a basic infrastructure of "large objects", [#](KellOS) delegating all fine-grained structure to client programs. This scores many points for conceptual openness. *Files* provide a universal API for reading and writing byte streams, a low-level construct containing so many degrees of freedom that it can support a wide variety of formats and ecosystems. *Processes* similarly provide a thin abstraction over machine-level memory and processors.

Concepual integrity is necessarily sacrificed for such openness; while "everything is a file" gestures at integrity, in the vein of Smalltalk's "everything is an object", exceptions proliferate. Directories are special kinds of files with special operations, hardware device files require special `ioctl` operations, and many commands expect files containing newline separators. Additionally, because client programs must supply their *own* structure for fine-grained data and code, they are given little in the way of mutual compatibility. As a result, they tend to evolve into competing silos of duplicated infrastructure. [#](KellOS) [#](Mythical)

## The Web
Web HTTP endpoints, meanwhile, have proven to be an even more adaptable and viral abstraction than UNIX files. They operate at a similar level of abstraction as files, but support richer content and encompass internet-wide interactions between autonomous systems. In a sense, HTTP GET and PUT have become the "subroutine calls" of an internet-scale programming system. Perhaps the most salient thing about the Web is that its usefulness came as such a surprise to everyone involved in designing or competing with it. It is likely that, by staying close to the existing practice of transferring files, the Web gained a competitive edge over more ambitious and less familiar hypertext projects like Xanadu. [#](TedNelson)

The choice between compatibility and integrity correlates with the personality traits of *pragmatism* and *idealism*. It is pragmatic to accept the status quo of technology and make the best of it. Conversely, idealists are willing to fight convention and risk rejection in order to attain higher goals. We can wonder which came first: the design decision or the personality trait? Do Lisp and Haskell teach people to think more abstractly and coherently, or do they filter for those with a pre-existing condition? Likewise, perhaps  introverted developers prefer the cloisters of Smalltalk or Lisp to the adventurous "Wild West" of the Web.

----------------------------------------------------------------------------------------------------
- id:composability
- title:Dimension: Composability

# Dimension: Composability
In short, *you can get anywhere by putting together a number of smaller steps.* There exist building blocks which span a range of useful combinations.
Composability is, in a sense, key to the notion of "programmability" and every programmable system will have some level of composability (e.g. in the scripting language.)

## UNIX
UNIX shell commands are a standard example of composability. The base set of primitive commands can be augmented by programming command executables in other languages. Given some primitives, one can "pipe" one's output to another's input (`|`), sequence (`;` or `&&`), select via conditions, and repeat with loop constructs, enabling full imperative programming. Furthermore, command compositions can be packaged into a named "script" which follows the same interface as primitive commands, and named subprograms within a script can also be defined.

## HyperCard
In *HyperCard*, the *Authoring Environment* is *non*-composable for programming buttons: there is simply a set of predefined behaviors to choose from. Full scriptability is available only in the *Programming Environment*.

## Haskell
The *Haskell type system*, as well as that of other functional programming languages, exhibits high composability. New types can be defined in terms of existing ones in several ways. These include records, discriminated unions, function types and recursive constructs (e.g. to define a `List` as either a `Nil` or a combination of element plus other list.) The C programming language also has some means of composing types that are analogous in some ways, such as structs, unions, enums and indeed even function pointers. For every type, there is also a corresponding "pointer" type. It lacks, however, the recursive constructs permitted in Haskell types.

----------------------------------------------------------------------------------------------------
- id:convenience
- title:Dimension: Convenience

# Dimension: Convenience
In short, *you can get to X, Y or Z via one single step.* There are ready-made solutions to specific problems, not necessarily generalizable or composable. Convenience often manifests as "canonical" solutions and utilities in the form of an expansive standard library.

## Composability and convenience

Composability without convenience is a set of atoms or gears; theoretically, anything one wants could be built out of them, but one must do that work. This situation has been criticized as the *Lisp Curse*. [#](LispCurse)

Composability *with* convenience is a set of convenient specific tools *along with* enough components to construct new ones. The specific tools themselves could be transparently composed of these building blocks, but this is not essential. They save users the time and effort it would take to "roll their own" solutions to common tasks.

## UNIX shell

For example, let us turn to a convenience factor of *UNIX* shell commands, having already discussed their composability above. Observe that it would be possible, in principle, to pass all information to a program via standard input. Yet in actual practice, for convenience, there is a standard interface of *command-line arguments* instead, separate from anything the program takes through standard input. Most programming systems similarly exhibit both composability and convenience, providing templates, standard libraries, or otherwise pre-packaged solutions, which can nevertheless be used programmatially as part of larger operations.

----------------------------------------------------------------------------------------------------
- id:commonality
- title:Dimension: Commonality

# Dimension: Commonality

Humans can see Arrays, Strings, Dicts and Sets all have a “size”, but the software needs to be *told* that they are the “same”. Commonality like this can be factored out into an explicit structure (a “Collection” class), analogous to database *normalization*. This way, an entity's size can be queried without reference to its particular details: if `c` is declared to be a Collection, then one can straightforwardly access `c.size`.

Alternatively, it can be left implicit. This is less upfront work, but permits instances to *diverge*, analogous to *redundancy* in databases. For example, Arrays and Strings might end up with “length”, while Dict and Set call it “size”. This means that, to query the size of an entity, it is necessary to perform a case split according to its concrete type, solely to funnel the diverging paths back to the commonality they represent:

```
if (entity is Array or String)  size := entity.length
else if (entity is Dict or Set) size := entity.size
```

## Related examples

<div class="nobullet">

- [!](-> #*=.;right=dimensions/conceptual-structure,flattening-factoring!)

</div>

----------------------------------------------------------------------------------------------------
- id:flattening-factoring
- title:Examples: Flattening and factoring

# Examples: Flattening and factoring

Data structures usually have several "moving parts" that can vary independently. For example, a simple pair of “vehicle type” and “color” might have all combinations of (Car, Van, Train) and (Red, Blue). In this *factored* representation, we can programmatically change the color directly: `pair.second = Red` or `vehicle.colour = Red`.

In some contexts, such as class names, a system might only permit such multi-dimensional structure as an *exhaustive enumeration*: RedCar, BlueCar, RedVan, BlueVan, RedTrain, BlueTrain, etc. The system sees a flat list of atoms, even though a human can see the sub-structure encoded in the string. In this world, we cannot simply “change the color to Red” programmatically; we would need to case-split as follows:

```
if (type is BlueCar) type := RedCar
else if (type is BlueVan) type := RedVan
else if (type is BlueTrain) type := RedTrain
```

The *commonality* between RedCar, RedVan, BlueCar, and so on has been *flattened*. There is implicit structure here that remains *un-factored*, similar to how numbers can be expressed as singular expressions (16) or as factor products (2,2,2,2). *Factoring* this commonality gives us the original design, where there is a pair of values from different sets.

In *relational databases*, there is an opposition between *normalization* and *redundancy*. In order to fit multi-table data into a *flat* table structure, data needs to be duplicated into redundant copies. When data is *factored* into small tables as much as possible, such that there is only one place each piece of data "lives", the database is in *normal form* or *normalized*. Redundancy is useful for read-only processes, because there is no need to join different tables together based on common keys. Writing, however, becomes risky; in order to modify one thing, it must be synchronized to the multiple places it is stored. This makes highly normalized databases optimized for writes over reads.

----------------------------------------------------------------------------------------------------
- id:end-of-history
- title:Remark: The end of history?

# Remark: The end of history?

Today we live in a highly developed world of software technology. It is estimated that 41,000 person years have been invested into Linux. We describe software development technologies in terms of *stacks* of specialized tools, each of which might capitalize over 100 person-years of development. Programming systems have become programming ecosystems: not designed, but evolved. How can we noticeably improve programming in the face of the overwhelming edifice of existing technology? There are strong incentives to focus on localized incremental improvements that don’t cross the established boundaries.

The history of computing is one of cycles of evolution and revolution. Successive cycles were dominated in turn by mainframes, minicomputers, workstations, personal computers, and the Web. Each transition built a whole new technology ecosystem replacing or on top of the previous. The last revolution, the Web, was 25 years ago, with the result that many people have never experienced a disruptive platform transition. Has history stopped, or are we just stuck in a long cycle, with increasingly pent-up pressures for change? If it is the latter, then incompatible ideas now spurned may yet flourish.
