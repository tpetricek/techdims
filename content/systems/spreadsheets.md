----------------------------------------------------------------------------------------------------
- id:dims-interaction
- shade: shade3
- characteristics: interaction-single, interaction-live, interaction-dm, interaction-open, interaction-concrete

Live update when editing. Formulas are always accessible.
Abstraction by generalizing from concrete computation (drag down) or using macros.

----------------------------------------------------------------------------------------------------
- id:dims-notation
- shade: shade1
- characteristics: notations-complementing, notations, notations-nonuniform, notations-graphical

Complementing notations with graphical grid, formulas and macros, allowing gradually richer interactions.
Different non-uniform notation at each level.

----------------------------------------------------------------------------------------------------
- id:dims-conceptual-structure
- shade: shade3
- characteristics: concepts-minimal, concepts-composable, concepts-convenient

Limited number of domain-specific concepts (sheet, formula, macro).
Computation can be composed and formulas constructed using many convenient built-ins. Structural commonality.

----------------------------------------------------------------------------------------------------
- id:dims-customizability
- shade: shade1
- characteristics: custom-closed, concepts-large

Documents are editable during execution, but system itself cannot be modified.
Adding only appends computations, but cannot modify existing ones.

----------------------------------------------------------------------------------------------------
- id:dims-complexity
- shade: shade1
- characteristics: complexity-fancy, complexity-domain

Fixed structure of formulas and grid. High-level language for formulas with automated re-computation.
Programming-by-example provides next-step automation.

----------------------------------------------------------------------------------------------------
- id:dims-errors
- shade: shade2
- characteristics: errors-dynamic, errors-immediate

Slips caught at runtime, but no support for checking lapses or mistakes.
Provides immediate feedback, making quick error correction possible.

----------------------------------------------------------------------------------------------------
- id:dims-adoptability
- shade: shade3
- characteristics: adoptability-domain, adoptability-nonexperts, adoptability-minimal

Domain-focus on specific needs and graphical interface supports learning. End-users can progressively become programmers.
No packaging mechanism, but wide range of samples and community available.

----------------------------------------------------------------------------------------------------
- id:summary
- title:Spreadsheets
- class:systems-spreadsheets-anchor sysdet

# Spreadsheets

[![](img/sys/visicalc.png)](#image=systems/spreadsheets,screen)

Spreadsheets are focused on working with tabular data, but allow a great degree of programmability
in this context. 

As programming systems, spreadsheets feature a unique programming substrate (two-dimensional grid)
and evaluation model with automatic (live) recomputation. They allow construction of abstractions 
from concrete computations and have been extended with plurality of notations and novel styles of
programming, such as programming by example.

## Summary

- [Technical dimensions summary](-> #*=.;right=systems/spreadsheets,overview)
- [!](-> #*=.;right=systems-spreadsheets:paper,a-type!)

## Discussion

- [!](-> #*=.;right=systems-spreadsheets:dimensions/interaction,abstraction-construction!)
- [!](-> #*=.;right=systems-spreadsheets:dimensions/interaction,direct-manipulation!)
- [!](-> #*=.;right=systems-spreadsheets:dimensions/notation,complementing-notations!)
- [!](-> #*=.;right=systems-spreadsheets:dimensions/complexity,pbe!)

----------------------------------------------------------------------------------------------------
- id:screen
- title:A screenshot of VisiCalc

> ![VisiCalc screenshot](img/sys/visicalc.png)
> 
> **VisiCalc screenshot.** VisiCalc was the first spreadsheet computer program, developed for Apple II in 1979. The screenshot shows a spreadsheet performing a simple computation
> ([source](https://en.wikipedia.org/wiki/VisiCalc)).

----------------------------------------------------------------------------------------------------
- id:overview
- title:Technical dimensions summary
- class:dimlist

# Spreadsheets

### Interaction

![$](systems/spreadsheets,dims-interaction)

### Notation

![$](systems/spreadsheets,dims-notation)

### Conceptual structure

![$](systems/spreadsheets,dims-conceptual-structure)

### Customizability

![$](systems/spreadsheets,dims-customizability)

### Complexity

![$](systems/spreadsheets,dims-complexity)

### Errors

![$](systems/spreadsheets,dims-errors)

### Adoptability

![$](systems/spreadsheets,dims-adoptability)
