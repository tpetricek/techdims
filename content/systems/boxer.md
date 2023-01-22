----------------------------------------------------------------------------------------------------
- id:dims-interaction
- shade: shade3
- characteristics: interaction-single, interaction-repl, interaction-dm, interaction-open, interaction-principles, interaction-concrete

Direct manipulation for graphical elements with REPL-like code execution.
Abstraction via messages sent to boxes and using ports to reuse concrete boxes.

----------------------------------------------------------------------------------------------------
- id:dims-notation
- shade: shade2
- characteristics: notations-complementing, notations, notations-uniform, notations-graphical

Complementing graphical notation (boxes) with source code in LISP.
Everything is a box (graphical) or a list (code). Tree-based document model.

----------------------------------------------------------------------------------------------------
- id:dims-conceptual
- shade: shade3
- characteristics: concepts-minimal, concepts-domain, concepts-noncomposable

Limited number of domain-specific concepts (box, graphical output).
Composability at code level, but not at a higher level (only via ports). 

----------------------------------------------------------------------------------------------------
- id:dims-customizability
- shade: shade1
- characteristics: custom-closed, concepts-large

Image-based system, editable during execution, but system itself cannot be modified.
Adding only appends boxes and cannot modify existing ones.

----------------------------------------------------------------------------------------------------
- id:dims-complexity
- shade: shade2
- characteristics: complexity-gc, complexity-domain, complexity-externalized

Basic factoring via language and box abstractions (ports). System automates user-interface 
handling; high-level language and DSLs offer basic automation (garbage collection, turtle graphics).

----------------------------------------------------------------------------------------------------
- id:dims-errors
- shade: shade2
- characteristics: errors-dynamic, errors-immediate

Slips detected at runtime, no support for checking lapses and mistakes.
Evaluation offers immediate feedback, making quick error correction possible.

----------------------------------------------------------------------------------------------------
- id:dims-adoptability
- shade: shade3
- characteristics: adoptability-minimal, adoptability-nonexperts, adoptability-unified

Simple and minimal design supports learnability. Unified design makes knowledge reusable.
System is closed from external world and has only limited community and available packages or examples.

----------------------------------------------------------------------------------------------------
- id:summary
- title:Boxer

yadda

![](img/sys/boxer.gif)


----------------------------------------------------------------------------------------------------
- id:index
- class:systems

# Boxer

![$](content=summary,link=index)

more here

