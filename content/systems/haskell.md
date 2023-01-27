----------------------------------------------------------------------------------------------------
- id:dims-interaction
- shade: shade2
- characteristics: interaction-multi, interaction-closed, interaction-principles

Separate editing, compilation and execution modes with feedback at each level.
Abstractions from first-principles (functions, type classes) are opaque during execution.

----------------------------------------------------------------------------------------------------
- id:dims-notation
- shade: shade3
- characteristics: notations-primary, notations-complementing

Primary source code notation with secondary infrastructure notations, edited as text.
Rich mostly explicit language with variety of extensions.


----------------------------------------------------------------------------------------------------
- id:dims-conceptual
- shade: shade2
- characteristics: concepts-interface, concepts-minimal, concepts-composable, concepts-nonconvenient

Small number of unified concepts (functions, expressions) at odds with outside world.
Composability at expression and type level. Limited set of convenience tools. Type classes for commonality.

----------------------------------------------------------------------------------------------------
- id:dims-customizability
- shade: shade2
- characteristics: custom-oss, custom-stages, custom-additive

Language is fixed, but can theoretically be modified as open-source project with community.
Programs cannot modify themselves nor the system. Type classes allow extensibility at compile-time.

----------------------------------------------------------------------------------------------------
- id:dims-complexity
- shade: shade3
- characteristics: complexity-gc, complexity-rich

Complexity factored using math-inspired type class hierarchies with type system support.
Automates memory management (GC) and evaluation order (laziness).

----------------------------------------------------------------------------------------------------
- id:dims-errors
- shade: shade3
- characteristics: errors-static, errors-code

Strict error checking eliminates lapes and slips and some mistakes at compile time.
Error correction done in text editor, based on non-trivial error messages.

----------------------------------------------------------------------------------------------------
- id:dims-adoptability
- shade: shade1
- characteristics: adoptability-background, adoptability-unified, adoptability-community, adoptability-packages

Learning requires background knowledge (mathematics), but is supported by community and uniform design.
Closed ecosystem, but with community and diversity of packages.

----------------------------------------------------------------------------------------------------
- id:summary
- title:Haskell
- class:systems-haskell-anchor sysdet

# Haskell

[![](img/sys/haskell.png)](#image=systems/haskell,screen)

yadda yadda

## Summary

- [Technical dimensions summary](-> #*=.;right=systems/haskell,overview)
- [!](-> #*=.;right=systems-haskell:paper,l-type!)

## Discussion

- [!](-> #*=.;right=systems-haskell:dimensions/interaction,feedback-loops!)
- [!](-> #*=.;right=systems-haskell:dimensions/interaction,modes-of-interaction!)
- [!](-> #*=.;right=systems-haskell:dimensions/notation,primary-secondary-notations!)
- [!](-> #*=.;right=systems-haskell:dimensions/conceptual-structure,composability!)
- [!](-> #*=.;right=systems-haskell:dimensions/errors,error-detection!)
- [!](-> #*=.;right=systems-haskell:dimensions/adoptability,sociability!)

----------------------------------------------------------------------------------------------------
- id:screen
- title:Haskell setup based on the xmonad interface

> ![Haskell screenshot](img/sys/haskell.png)
> 
> **Haskell screenshot.** A sample setup leveraging the (Haskell-implemented) xmonad desktop manager for Linux showing text editor and a command line interface for access to tools
> ([source](https://github.com/liskin/dotfiles/tree/home/.xmonad)).

----------------------------------------------------------------------------------------------------
- id:overview
- title:Technical dimensions summary
- class:dimlist

# Haskell

### Interaction

![$](systems/haskell,dims-interaction)

### Notation

![$](systems/haskell,dims-notation)

### Conceptual structure

![$](systems/haskell,dims-conceptual)

### Customizability

![$](systems/haskell,dims-customizability)

### Complexity

![$](systems/haskell,dims-complexity)

### Errors

![$](systems/haskell,dims-errors)

### Adoptability

![$](systems/haskell,dims-adoptability)
