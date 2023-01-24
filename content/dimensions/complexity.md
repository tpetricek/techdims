----------------------------------------------------------------------------------------------------
- id:summary
- title: Complexity
- class: dimensions-complexity-anchor nobullet

# <i class="fa fa-sitemap"></i> Complexity [Description and relations...](-> #*=.;right=dimensions/complexity,index)

How does the system structure complexity and what level of detail is required?

## Dimensions

- What programming details are hidden in reusable components and how?  
  [!](-> #*=.;right=dimensions/complexity,factoring!)
- What part of program logic does not need to be explicitly specified?  
  [!](-> #*=.;right=dimensions/complexity,automation!)

## Examples and remarks

- [!](-> #*=.;right=dimensions/complexity,notations!)
- [!](-> #*=.;right=dimensions/complexity,dsls!)
- [!](-> #*=.;right=dimensions/complexity,pbe!)
- [!](-> #*=.;right=dimensions/complexity,next-level!)

----------------------------------------------------------------------------------------------------
- id:index
- title:Complexity

# Complexity

**How does the system structure complexity and what level of detail is required?**

There is a massive gap between the level of detail required by a computer, which executes a sequence of low-level instructions, and the human description of a program in higher-level terms. To bridge this gap, a programming system needs to deal with the complexity inherent in going from a high-level description to low-level instructions.

Ever since the 1940s, programmers have envisioned that "automatic programming" will allow higher-level programming. This did not necessarily mean full automation. In fact, the first "automatic programming" systems referred to higher-level programming languages with a compiler (or an interpreter) that expanded the high-level code into detailed instructions.

Most programming systems use _factoring of complexity_ and encapsulate some of the details that need to be specified into components that can be reused by the programmer. The details may be encapsulated in a library, or filled in by a compiler or interpreter. Such factoring may also be reflected in the conceptual structure of the system (See [flattening and factoring](#*=.;right=dimensions/conceptual-structure,flattening-factoring)). However, a system may also fully _automate_ some aspects of programming. In those cases, a general-purpose algorithm solves a whole class of problems, which then do not need to be coded explicitly. Think of planning the execution of SQL queries, or of the inference engine supporting a logic programming language like Prolog.


## Relations

[Conceptual structure](-> #*=.;right=dimensions/conceptual-structure,index) In many cases, the factoring of complexity follows the conceptual structure of the programming system.

[Flattening and factoring](-> #*=.;right=dimensions/conceptual-structure,flattening-factoring) One typically automates the thing at the lowest level in one's factoring (by making the lowest level a thing that exists outside of the program---in a system or a library)

----------------------------------------------------------------------------------------------------
- id:notations
- title:Remark: Notations

# Remark: Notations
Even when working at a high level, programming involves manipulating some program notation. In high-level functional or imperative programming languages, the programmer writes code that typically has clear operational meaning, even when some of the complexity is relegated to a library implementation or a runtime. 

When using declarative programming systems like SQL, Prolog or Datalog, the meaning of a program is still unambiguous, but it is not defined operationally---there is a (more or less deterministic) inference engine that solves the problem based on the provided description. 

Finally, systems based on *programming by example* step even further away from having clear operational meaning---the program may be simply a collection of sample inputs and outputs, from which a (possibly non-deterministic) engine infers the concrete steps of execution.

----------------------------------------------------------------------------------------------------
- id:factoring
- title:Dimension: Factoring of complexity

# Dimension: Factoring of complexity
The basic mechanism for dealing with complexity is _factoring_ it. Given a program, the more domain-specific aspects of the logic are specified explicitly, whereas the more mundane and technical aspects of the logic are left to a reusable component. 

Often, this reusable component is just a library. Yet in the case of higher-level programming languages, the reusable component may include a part of a language runtime such as a memory allocator or a garbage collector. In case of declarative languages or programming by example, the reusable component is a general purpose inference engine.

## Related examples

<div class="nobullet">

- [!](-> #*=.;right=dimensions/complexity,dsls!)

</div>


----------------------------------------------------------------------------------------------------
- id:automation
- title:Dimension: Level of automation

# Dimension: Level of automation
Factoring of complexity shields the programmer from some details, but those details still need to be explicitly programmed. Depending on the customizability of the system, this programming may or may not be accessible, but it is always there. For example, a function used in a spreadsheet formula is implemented in the spreadsheet system.

A programming system with higher _level of automation_ requires more than simply factoring code into reusable components. It uses a mechanism where some details of the operational meaning of a program are never explicitly specified, but are inferred automatically by the system. This is the approach of _programming by example_ and _machine learning_, where behaviour is specified through examples. In some cases, deciding whether a feature is _automation_ or merely _factoring of complexity_ is less clear: garbage collection can be seen as either a simple case of automation, or a sophisticated case of factoring complexity.

There is also an interesting (and perhaps inevitable) trade-off. The higher the level of automation, the less explicit the operational meaning of a program. This has a wide range of implications. Smaragdakis [#](NextGen) notes, for example, that this means the implementation can significantly change the performance of a program.

## Related examples

<div class="nobullet">

- [!](-> #*=.;right=dimensions/complexity,pbe!)
- [!](-> #*=.;right=dimensions/complexity,next-level!)

</div>

----------------------------------------------------------------------------------------------------
- id:dsls
- title:Example: Domain-specific languages

# Example: Domain-specific languages

Domain-specific languages [#](DSLs) provide an example of factoring of complexity that does not involve automation. In this case, programming is done at two levels. At the lower level, an (often more experienced) programmer develops a domain-specific language, which lets a (typically less experienced) programmer easily solve problems in a particular domain: say, modelling of financial contracts, or specifying interactive user interfaces.

The domain-specific language provides primitives that can be composed, but each primitive and each form of composition has explicitly programmed and unambiguous operational meaning. The user of the domain-specific language can think in the higher-level concepts it provides, and this conceptual structure can be analysed using the dimensions in [Conceptual structure](#*=.;right=dimensions/conceptual-structure,index). As long as these concepts are clear, the user does not need to be concerned with the details of how exactly the resulting programs run.

----------------------------------------------------------------------------------------------------
- id:pbe
- title:Example: Programming by example

# Example: Programming by example

An interesting case of automation is _programming by example_. [#](PBE) In this case, the user does not provide even a declarative specification of the program behavior, but instead specifies sample inputs and outputs. A more or less sophisticated algorithm then attempts to infer the relationship between the inputs and the outputs. This may, for example, be done through program synthesis where an algorithm composes a transformation using a (small) number of pre-defined operations. Programming by example is often very accessible and has been used in spreadsheet applications. [#](PBEExcel)

----------------------------------------------------------------------------------------------------
- id:next-level
- title:Example: Next level automation

# Example: Next-level automation

Throughout history, programmers have always hoped for the next level of "automatic programming". As observed by Parnas, [#](Euphemism) "automatic programming has always been a euphemism for programming in a higher-level language than was then available to the programmer".

We may speculate whether Deep Learning will enable the next step of automation. However, this would not be different in principle from existing developments. We can see any level of automation as using *artificial intelligence* methods. This is the case for declarative languages or constraint-based languages---where the inference engine implements a traditional AI method (GOFAI, i.e., Good Old Fashioned AI).
