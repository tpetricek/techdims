----------------------------------------------------------------------------------------------------
- id:summary
- title: Notation
- class: dimensions-notation-anchor nobullet

# <i class="fa fa-code"></i> Notation [Description and relations...](-> #*=.;right=dimensions/notation,index)

How are the different textual and visual programming notations related?  

## Dimensions

- What notations are used to program the system and how are they related?  
  [!](-> #*=.;right=dimensions/notation,notational-structure!)
- What is the connection between what a user sees and what a computer program sees?  
  [!](-> #*=.;right=dimensions/notation,surface-internal-notation!)
- Is one notation more important than others?  
  [!](-> #*=.;right=dimensions/notation,primary-secondary-notations!)
- Do similar expressions encode similar programs?  
  [!](-> #*=.;right=dimensions/notation,expression-geography!)
- Does the notation use a small or a large number of basic concepts?  
  [!](-> #*=.;right=dimensions/notation,uniformity-of-notations!)

## Examples

- [!](-> #*=.;right=dimensions/notation,overlapping-notations!)
- [!](-> #*=.;right=dimensions/notation,complementing-notations!)
- [!](-> #*=.;right=dimensions/notation,explicit-implicit-structure!)

----------------------------------------------------------------------------------------------------
- id:index
- title:Notation

# Notation

**How are the different textual and visual programming notations related?**

Programming is always done through some form of notation. We consider notations in the most general sense and include any structured gesture using textual or visual notation. Textual notations primarily include  programming languages, but also things like configuration files. Visual notations include graphical programming languages. Other kinds of structured gestures include user interfaces for constructing visual elements used in the system.

## References
*Cognitive Dimensions of Notation* [#](CogDims) provide a comprehensive framework for analysing individual notations, while our focus here is on how multiple notations are related and how they are structured. It is worth noting that the Cognitive Dimensions also define _secondary notation_, but in a different sense to ours. For them, secondary notation refers to whether a notation allows including redundant information such as color or comments for readability purposes.

The importance of notations in the practice of science, more generally, has been studied as "paper tools". [#](PaperTools) These are formula-like entities which can be manipulated by humans in lieu of experimentation, such as the aforementioned mathematical notation in Haskell: a "paper tool" for experimentation on a whiteboard. Programming notations are similar, but they are a way of communicating with a machine; the experimentation does not happen on paper alone.

## Relations

[Interaction](-> #*=.;right=dimensions/interaction,index) The feedback loops that exist in a programming system are typically associated with individual notations. Different notations may also have different feedback loops.

[Adoptability](-> #*=.;right=dimensions/adoptability,index) Notational structure can affect learnability. In particular, complementing notations may require (possibly different) users to master multiple notations. Overlapping notations may improve learnability by allowing the user to edit the program in one way (perhaps visually) and see the effect in the other notation (such as code.)

[Errors](-> #*=.;right=dimensions/errors,index) A process that merely records user actions in a sequence (such as text editing) will, in particular, record any *errors* the user makes and defer their handling to later use of the data, keeping the errors *latent*. A process which instead treats user actions as edits to a structure, with constraints and correctness rules, will be able to catch errors at the moment they are introduced and ensure the data coming out is error-free.


----------------------------------------------------------------------------------------------------
- id:notational-structure
- title:Dimension: Notational structure

# Dimension: Notational structure

In practice, most programming systems use multiple notations. Different notations can play different roles in the system. 

On the one hand, multiple [overlapping notations](#*=.;right=dimensions/notation,overlapping-notations) can be provided as different ways of programming the same aspects of the system. In this case, each notation may be more suitable to different kinds of users, but may have certain limitations (for example, a visual notation may have a limited expressive power). 

On the other hand, multiple [complementing notations](#*=.;right=dimensions/notation,complementing-notation) may be used as the means for programming different aspects of the system. In this case, programming the system requires using multiple notations, but each notation may be more suitable for the task at hand; think of how HTML describes document structure while JavaScript specifies its behavior.

## Related examples

<div class="nobullet">

- [!](-> #*=.;right=dimensions/notation,overlapping-notations!)
- [!](-> #*=.;right=dimensions/notation,complementing-notations!)

</div>

----------------------------------------------------------------------------------------------------
- id:overlapping-notations
- title:Example: Overlapping notations

# Example: Overlapping notations
A programming system may provide multiple notations for programming the same aspect of the system. This is typically motivated by an attempt to offer easy ways of completing different tasks: say, a textual notation for defining abstractions and a visual notation for specifying concrete structures. The crucial issue in this kind of arrangement is *synchronizing* the different notations; if they have different characteristics, this may not be a straightforward mapping. 

For example, source code may allow more elaborate abstraction mechanisms like  loops, which will appear as visible repetition in the visual notation. What should such a system do when the user edits a single object that resulted from such repetition? Similarly, textual notation may allow incomplete expressions that do not have an equivalent in the visual notation. For programming systems that use *overlapping notations*, we need to describe how the notations are synchronized.

## Sketch-n-Sketch 
Sketch-n-Sketch [#](SnS) employs overlapping notations for creating and editing SVG and HTML documents. The user edits documents in an interface with a split-screen structure that shows source code on the left and displayed visual output on the right. They can edit both of these and changes are propagated to the other view. The code can use abstraction mechanisms (such as functions) which are not completely visible in the visual editor (an issue we return to in [expression geography](#*=.;right=dimensions/notation,expression-geography)). Sketch-n-Sketch can be seen as an example of a *projectional editor*. (Technically, traditional projectional editors usually work more directly with the abstract syntax tree of a programming language.)

## UML Round-tripping
Another example of a programming system that utilizes the *overlapping notations* structure are UML design tools that display the program both as source code and as a UML diagram. Edits in one result in automatic update of the other. An example is the [Together/J system](https://www.mindprod.com/jgloss/togetherj.html). To solve the issue of notation synchronization, such systems often need to store additional information in the textual notation, typically using a special kind of code comment. In this example, after the user re-arranges classes in UML diagrams, the new locations need to be updated in the code.

----------------------------------------------------------------------------------------------------
- id:complementing-notations
- title:Example: Complementing notations

# Example: Complementing notations
A programming system may also provide multiple complementing notations for programming different aspects of its world. Again, this is typically  motivated by the aim to make specifying certain aspects of programming easier, but it is more suitable when the different aspects can be more clearly separated. 

The key issue for systems with complementing notations is how the different notations are connected. The user may need to use both notations at the same time, or they may need to progress from one to the next level when solving increasingly complex problems. In the latter case, the learnability of progressing from one level to the next is a major concern.

## Spreadsheets and HyperCard
In Excel, there are three different complementing notations that allow users to specify aspects of increasing complexity: (i) the visual grid, (ii) formula language and (iii) a macro language such as Visual Basic for Applications. The notations are largely independent and have different degrees of expressive power. Entering values in a grid cannot be used for specifying new computations, but it can be used to adapt or run a computation, for example when entering different alternatives in What-If Scenario Analysis. More complex tasks can be achieved using formulas and macros. 

A user gradually learns more advanced notations, but experience with a previous notation does not help with mastering the next one. The approach optimizes for easy learnability at one level, but introduces a hurdle for users to surmount in order to get to the second level. The notational structure of *HyperCard* is similar and consists of (i) visual design of cards, (ii) visual programming (via the GUI) with a limited number of operations and (iii) HyperTalk for arbitrary scripting.

## Boxer and Jupyter
Boxer [#](Boxer) uses *complementing notations* in that it combines a visual notation (the layout of the document and the boxes of which it consists) with textual notation (the code in the boxes). Here, the textual notation is always nested within the visual. The case of Jupyter notebooks is similar. The document structure is graphical; code and visual outputs are nested as editable cells in the document. This arrangement is common in many other systems such as Flash or Visual Basic, which both combine visual notation with textual code, although one is not nested in the other.

----------------------------------------------------------------------------------------------------
- id:surface-internal-notation
- title:Dimension: Surface and internal notation

# Dimensions: Surface and internal notation
All programming systems build up structures in memory, which we can consider as an *internal notation* not usually visible to the user. Even though such structures might be revealed in a debugger, they are hidden during normal operation. What the user interacts with instead is the *surface notation*, typically one of text or shapes on a screen. Every interaction with the surface notation alters the internal notation in some way, and the nature of this connection is worth examining in more detail. To do this, we illustrate with a simplified binary choice for the form of these notations.

## Related examples

<div class="nobullet">

- [!](-> #*=.;right=dimensions/notation,explicit-implicit-structure!)
- [!](-> #*=.;right=dimensions/notation,one-string-in-memory!)
- [!](-> #*=.;right=dimensions/notation,two-strings-in-memory!)

</div>

----------------------------------------------------------------------------------------------------
- id:explicit-implicit-structure
- title:Example: Explicit versus implicit structure

# Examples: Explicit versus implicit structure
Let us partition notations into two families. Notations with *implicit structure* present as a sequence of items, such as textual characters or audio signal amplitudes. Those with *explicit structure* present as a tree or graph without an obvious order, such as shapes in a vector graphics editor. These two types of notations can be transformed into each other: the implicit structure contained in a string can be *parsed* into an explicit syntax tree, and an explicit document structure might be *rendered* into a sequence of characters with the same implicit structure.

Now consider an interface to enter a personal name made up of a forename and a surname. For the surface notation, there could be a single text field to hold the names separated with a space; here, the sub-structure is implicit in the string. Alternatively, there could be two fields where the names are entered separately, and their separation is explicit. A similar choice exists for the internal notation built up in memory: is it a single string, or two separate strings?

We can see that these choices give four combinations. More interestingly, they exhibit unique characters owing to two key asymmetries. Firstly, surface notation is mostly used by humans, while the internal notation is mostly used by the computer. Secondly, and most significantly, computer programs can only work with explicit structure, while humans can understand both explicit and implicit structure. Because of the practical consequences of this asymmetry, we will examine the combinations with emphasis on the *internal* notation first.

## Related examples

<div class="nobullet">

- [!](-> #*=.;right=dimensions/notation,one-string-in-memory!)
- [!](-> #*=.;right=dimensions/notation,two-strings-in-memory!)

</div>


----------------------------------------------------------------------------------------------------
- id:one-string-in-memory
- title:Examples: One string in memory

# Examples: One string in memory (implicitly structured internal notation)
The simplest case here would be with implicit structure in the surface notation, i.e. a single text box for the full name. Edits to the surface are straightforwardly mirrored interally and persisted to disk. This corresponds to *text editing*. We can generalize this to an idea of *sequence editing* if we view the fundamental act as *recording* events to a list over time. For text, these are key presses; for an audio editing interface they would be samples of sound amplitude.

In the other case, with two text boxes, we have *sequence rendering*. The information about the separation of the two strings, present in the interface, is not quite "thrown away" but is made *implicit* as a space character in the string. This combination corresponds to Visual Basic generating code from GUI forms, video editors combining multiple clips and effects into a single stream, and 3D renderers turning scene graphs into pixels. Another example is line-based diff tools, which provide side-by-side views and related interfaces, yet must ultimately forward the user's changes to the underlying text file.

Critically, in both of these cases, a computer program can only manipulate the stored sequences *as* sequences; that is, by inserting, removing, or serially reading. The appealing feature here is that these operations are simple to implement and may be re-usable across many types of sequences. However, any further structure is implicit and, to work with it programmatically, a user must write a program to *parse* it into something explicit. Furthermore, errors introduced at this stage may simply be *recorded* into the sequence, only to be discovered much later in an attempt to use the data.

----------------------------------------------------------------------------------------------------
- id:two-strings-in-memory
- title:Examples: Two strings in memory

# Examples: two strings in memory (explicitly structured internal notation)
With two text boxes, both notations match, so there is not much work to do. As with sequence editing, edits on the surface can be mirrored to the internal notation. This corresponds to vector graphics editors and 3D modelling tools, as well as *structure editors* for programming languages. For this reason we call this combination *structure editing*.

With a single text field, we have *structure recovery.* Parsing needs to happen each time the input changes. This style is found in the DOM inspector in browser developer tools, where HTML can be edited as text to make changes to the document tree structure. More generally, this is the mode found in compilers and interpreters which accept program source text yet internally work on tree and graph structures. It is also possible to do a sort of structure editing this way, where the experience is made to resemble text editing but the output is explicitly structured.

In both of these cases, in order to write programs to transform, analyze, or otherwise work with the digital artefact the user has created, one can trivially navigate the stored structure instead of parsing it for every use. Parsing is either done away with altogether or is reduced to a transient process that happens during editing; this means errors can be caught at the moment they are introduced instead of remaining latent.

----------------------------------------------------------------------------------------------------
- id:primary-secondary-notations
- title:Dimension: Primary and secondary notations

# Dimension: Primary and secondary notations
In practice, most programming systems use multiple notations. Even in systems based on traditional programming languages, the *primary notation* of the language is often supported by *secondary notations* such as annotations encoded in comments and build tool configuration files. However, it is possible for multiple notations to be primary, especially if they are *overlapping* as defined earlier.

## Programming languages
Programming systems built around traditional programming languages typically have further notations or structured gestures associated with them. The primary notation in UNIX is the C programming language. Yet this is enclosed in a programming *system* providing a multi-step mechanism for running C code via the terminal, assisted by secondary notations such as shell scripts. 

Some programming systems attempt to integrate tools that normally rely on secondary notations into the system itself, reducing the number of secondary notations that the programmer needs to master. For example, in the Smalltalk descendant Pharo, versioning and package management is done from within Pharo, removing the need for secondary notation such as `git` commands and dependency configuration files. (The tool for versioning and package management in Pharo can still be seen as an *internal* domain-specific language and thus as a secondary notation, but its basic structure is *shared* with other notations in the Pharo system.)

## Haskell
In Haskell, the primary notation is the programming language, but there are also a number of secondary notations. Those include package managers (e.g. the `cabal.project` file) or configuration files for Haskell build tools. More interestingly, there is also an informal mathematical notation associated with Haskell that is used when programmers discuss programs on a whiteboard or in academic publications. The idea of having such a mathematical notation dates back to the *Report on Algol 58* \cite{Alg58}, which explicitly defined a "publication language" for "stating and communicating problems" using Greek letters and subscripts.

----------------------------------------------------------------------------------------------------
- id:expression-geography
- title:Dimension: Expression geography

# Dimension: Expression geography
A crucial feature of a notation is the relationship between the structure of the notation and the structure of the behavior it encodes. Most importantly, do *similar expressions* in a particular notation represent *similar behavior*? (See Basman's [#](NotYetCraft) similar discussion of "density".) Visual notations may provide a more or less direct mapping. On the one hand, similar-looking code in a block language may mean very different things. On the other hand, similar looking design of two HyperCard cards will result in similar looking cards—the mapping between the notation and the logic is much more direct.

## C/C++ expression language
In textual notations, this may easily not be the case. Consider the two C conditionals:

- `if (x==1) { ... }` evaluates the Boolean expression `x==1` to determine whether `x` equals `1`, running the code block if the condition holds.
- `if (x=1) { ... }` *assigns* `1` to the variable `x`. In C, assignment is an expression *returning* the assigned value, so the result `1` is interpreted as `true` and the block of code is *always* executed.

A notation can be designed to map better to the logic behind it, for example, by requiring the user to write `1==x`. This solves the above problem as `1` is a literal rather than a variable, so it cannot be assigned to (`1=x` is a compile error).

----------------------------------------------------------------------------------------------------
- id:uniformity-of-notations
- title:Dimension: Uniformity of notations

# Dimension: Uniformity of notations
One common concern with notations is the extent to which they are uniform. A uniform notation can express a wide range of things using just a small number of concepts. 

The primary example here is S-expressions from Lisp. An S-expression is either an atom or a pair of S-expressions written `(s1 . s2)`. By convention, an S-expression `(s1 . (s2 . (s3 . nil)))` represents a list, written as `(s1 s2 s3)`. In Lisp, uniformity of notations is closely linked to uniformity of representation. (Notations generally are closely linked to representation in that the notation may mirror the structures used for program representation. Basman et al. [#](Externalize) refer to this as a distinction between "dead" notation and "live" representation forms.) In the idealized model of LISP 1.5, the data structures represented by an S-expression are what exists in memory. In real-world Lisp systems, the representation in memory is more complex. A programming system can also take a very different approach and fully separate the notation from the in-memory representation.

## Lisp systems
In Lisp, source code is represented in memory as S-expressions, which can be manipulated by Lisp primitives. In addition, Lisp systems have robust macro processing as part of their semantics: expanding a macro revises the list structure of the code that uses the macro. Combining these makes it possible to define extensions to the system in Lisp, with syntax indistinguishable from Lisp. Moreover, it is possible to write a program that constructs another Lisp program and not only run it interpretively (using the `eval` function) but compile it at runtime (using the `compile` function) and execute it. Many domain-specific languages, as well as prototypes of new programming languages (such as Scheme), were implemented this way. Lisp the language is, in this sense, a "programmable programming language". [#](LispIntro) [#](ProgProgLang)

