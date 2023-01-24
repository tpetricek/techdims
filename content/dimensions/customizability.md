----------------------------------------------------------------------------------------------------
- id:summary
- title: Customizability
- class: dimensions-customizability-anchor nobullet

# <i class="fa fa-hammer"></i> Customizability [Description and relations...](-> #*=.;right=dimensions/customizability,index)

Once a program exists in the system, how can it be extended and modified?

## Dimensions

- Must we customize running programs differently to inert ones? Do these changes last beyond termination?  
  [!](-> #*=.;right=dimensions/customizability,staging!)
- Which portions of the system’s state can be referenced and transferred to/from it? How far can the system’s behavior be changed by adding expressions?  
  [!](-> #*=.;right=dimensions/customizability,addressing!)
- How far can the system’s behavior be changed from within?  
  [!](-> #*=.;right=dimensions/customizability,self-sustainability!)

----------------------------------------------------------------------------------------------------
- id:index
- title:Customizability

# Customizability

**Once a program exists in the system, how can it be extended and modified?**

Programming is a gradual process. We start either from nothing, or from an existing program, and gradually extend and refine it until it serves a given purpose. Programs created using different programming systems can be refined to different extents, in different ways, at different stages of their existence.
Consider three examples:

1. First, a program in a conventional programming language like Java can be refined only by modifying its source code. However, you may be able to do so by just adding new code, such as a new interface implementation. 
2. Second, a spreadsheet can be modified at any time by modifying the formulas or data it contains. There is no separate programming phase. However, you have to modify the formulas directly in the cell---there is no way of modifying it by specifying a change in a way that is external to the cell. 
3. Third, a *self-sustaining* programming system, such as Smalltalk, does not make an explicit distinction between "programming" and "using" phases, and it can be modified and extended via itself. It gives developers the power to experiment with the system and, in principle, replace it with a better system from within.

## References

In addition to the examples discussed in text, the proceedings of self-sustaining systems workshops [#](SelfSustaining2008) [#](SelfSustaining2010) provide numerous examples of systems and languages that are able to bootstrap, implement, modify, and maintain themselves; Gabriel's analysis of programming language revolutions [#](PLrev) uses _advising_ in PILOT, related Lisp mechanisms, and "mixins" in OOP to illustrate the difference between the "languages" and "systems" paradigms.

## Relations

[Flattening and factoring](-> #*=.;right=dimensions/conceptual-structure,flattening-factoring) Related in that "customizability" is a form of creating new programs from existing ones; factoring repetitive aspects into a reusable standard component library facilitates the same thing.

[Interaction](-> #*=.;right=dimensions/interaction,index) This determines whether there are separate stages for running and writing programs and may thus influence what kind of customization is possible.

----------------------------------------------------------------------------------------------------
- id:staging
- title:Dimension: Staging of customization

# Dimension: Staging of customization
For systems that distinguish between different stages, such as writing source code versus running a program, customization methods may be different for each stage. In traditional programming languages, customization is done by modifying or adding source code at the programming stage, but there is no (automatically provided) way of customizing the created programs once they are running.

There are a number of interesting questions related to staging of customization. First, what is the notation used for customization? This may be the notation in which a program was initially created, but a system may also use a secondary notation for customization (consider Emacs using Emacs Lisp). For systems with a stage distinction, an important question is whether such changes are *persistent*.

## Smalltalk, Interlisp and similar
In image-based programming systems, there is generally no strict distinction between stages and so a program can be customized during execution in the same way as during development. The program image includes the programming environment. Users of a program can open this, navigate to a suitable object or a class (which serve as the *addressable extension points*) and modify that. Lisp-based systems such as *Interlisp* follow a similar model. Changes made directly to the image are persistent. The PILOT system for Lisp [#](Pilot) offers an interactive way of correcting errors when a program fails during execution. Such corrections are then applied to the image and are thus persistent.

## Document Object Model (DOM) and Webstrates
In the context of Web programming, there is traditionally a stage distinction between programming (writing the code and markup) and running (displaying a page). However, the DOM can also be modified by browser Developer Tools---either manually, by running scripts in a console, or by using a userscript manager such as Greasemonkey. Such changes are not persistent in the default browser state, but are made so by Webstrates [#](Webstrates) which synchronize the DOM between the server and the client. This makes the DOM collaborative, but not (automatically) _live_ because of the complexities this implies for event handling.

----------------------------------------------------------------------------------------------------
- id:addressing
- title:Dimension: Addressing and externalizability

# Dimension: Addressing and externalizability
Programs in all programming systems have a representation that may be exposed through notation such as source code. When customizing a program, an interesting question is whether a customization needs to be done by modifying the original representation, or whether it can be done by *adding* something alongside the original structure.

In order to support customization through addition, a programming system needs a number of characteristics introduced by Basman et al. [#](Externalize) [#](OpenAuthorial) First, the system needs to support *addressing*: the ability to refer to a part of the program representation from the outside. Next, *externalizability* means that a piece of addressed state can be exhaustively transferred between the system and the outside world. 

Finally, *additive authoring* requires that system behaviours can be *changed* by simply *adding* a new expression containing addresses---in other words, anything can be *overriden* without being *erased*. Of particular importance is how addresses are specified and what extension points in the program they can refer to. The system may offer an automatic mechanism that makes certain parts of a program addressable, or this task may be delegated to the programmer.

## Cascading Style Sheets (CSS)
CSS is a prime example of additive authoring within the Web programming system. It provides rich addressability mechanisms that are partly automatic (when referring to tag names) and partly manual (when using element IDs and class names). Given a web page, it is possible to modify almost any aspect of its appearance by simply *adding* additional rules to a CSS file. The Infusion project [#](Infusion) offers similar customizability mechanisms, but for behaviour rather than just styling. There is also the recent programming system Varv, [#](Varv) which embodies additive authoring as a core principle.

## Object Oriented Programming (OOP) and Aspect Oriented Programming (AOP)
In conventional programming languages, customization is done by modifying the code itself. OOP and AOP make it possible to do so by adding code independently of existing program code. In OOP, this requires manual definition of extension points, i.e. interfaces and abstract methods. Functionality can then be added to a system by defining a new class (although injecting the new class into existing code without modification requires some form of configuration such as a dependency injection container). AOP systems such as AspectJ [#](AspectJ) provides a richer addressing mechanism. In particular, it makes it possible to add functionality to the invocation of a specific method (among other options) by using the *method call pointcut*. This functionality is similar to *advising* in Pilot [#](Pilot).

----------------------------------------------------------------------------------------------------
- id:self-sustainability
- title:Dimension: Self-sustainability

# Dimension: Self-sustainability
For most programming languages, programming systems, and ordinary software applications, if one wants to customize beyond a certain point, one must go beyond the facilities provided in the system itself. Most programming systems maintain a clear distinction between the *user level*, where the system is used, and *implementation level*, where the source code of the system itself resides. If the user level does not expose control over some property or feature, then one is forced to go to the implementation level. In the common case this will be a completely different language or system, with an associated learning cost. It is also likely to be lower-level---lacking expressive functions, features or abstractions of the user level---which makes for a more tedious programming experience.

## Progressively evolvable systems
It is possible, however, to carefully design systems to expose deeper aspects of their implementation *at the user level*, relaxing the formerly strict division between these levels. For example, in the research system *3-Lisp*, [#](PRinPLs) ordinarily built-in functions like the conditional `if` and error handling `catch` are implemented in 3-Lisp code at the user level.

The degree to which a system's inner workings are accessible to the user level, we call *self-sustainability*. At the maximal degree of this dimension would reside "stem cell"-like systems: those which can be progressively evolved to arbitrary behavior without having to "step outside" of the system to a lower implementation level. In a sense, any difference between these systems would be merely a difference in initial state, since any could be turned into any other.

## Minimal customizability
The other end, of minimal self-sustainability, corresponds to minimal customizability: beyond the transient run-time state changes that make up the user level of any piece of software, the user cannot change anything without dropping down to the means of implementation of the system. This would resemble a traditional end-user "application" focused on a narrow domain with no means to do anything else.

## Self-describing systems
The terms "self-describing" or "self-implementing" have been used for this property, but they can invite confusion: how can a thing describe itself? Instead, a system that can *sustain itself* is an easier concept to grasp. The examples that we see of high self-sustainability all tend to be *Operating System-like*. UNIX is widely established as an operating system, while Smalltalk and Lisp have been branded differently. Nevertheless, all three have shipped as the operating systems of custom hardware, and have similar responsibilities. Specifically: they support the execution of "programs"; they define an interface for accessing and modifying state; they provide standard libraries of common functionality; they define how programs can communicate with each other; they provide a user interface.

## UNIX
Self-sustainability of UNIX is owed to the combination of two factors. First, the system is implemented in binary files (via ELF, Executable and Linkable Format) and text files (for configuration). Second, these files are part of the user-facing filesystem, so users can replace and modify parts of the system using UNIX file interfaces.

## Smalltalk and Combined Object Lambda Architectures
Self-sustainability in Smalltalk is similar to UNIX, but at a finer granularity and with less emphasis on whether things reside in volatile (process) or non-volatile (file) storage. The analogous points are that (1) the system is implemented as objects with methods containing Smalltalk code, and (2) these are modifiable using the class browser and code editor. Combined Object Lambda Architectures, or COLAs, [#](COLAs) are a theoretical system design to improve on the self-sustainability of Smalltalk. This is achieved by generalizing the object model to support relationships beyond classes.

