----------------------------------------------------------------------------------------------------
- id:dims-interaction
- shade: shade3
- characteristics: interaction-single, interaction-repl, interaction-dm, interaction-open, interaction-principles, interaction-concrete

Direct manipulation for user interface; programmatic scripting with execution feedback loop.
Abstractions on card level using shared backgrounds and transclusion.

----------------------------------------------------------------------------------------------------
- id:dims-notation
- shade: shade1
- characteristics: notations-complementing, notations, notations-nonuniform, notations-graphical

Complementing graphical notation (user interface) with source code in Hypertalk.
Variety of controls and langauge features with tight expression geography in user interface.

----------------------------------------------------------------------------------------------------
- id:dims-conceptual-structure
- shade: shade3
- characteristics: concepts-minimal, concepts-diverse, concepts-noncomposable, concepts-convenient

Limited number of domain-specific concepts (cards, user interface elements, scripts).
Partial composability at script level, but limited at card level. Convenient for the given domain.

----------------------------------------------------------------------------------------------------
- id:dims-customizability
- shade: shade1
- characteristics: concepts-large, custom-closed

Cards are editable during execution, but system itself cannot be modified.
Adding only appends new content, but cannot modify existing ones.

----------------------------------------------------------------------------------------------------
- id:dims-complexity
- shade: shade2
- characteristics: complexity-gc, complexity-domain, complexity-externalized

Basic factoring via language and card abstractions. Underlying system automates user-interface 
handling; high-level scripting language offers basic automation (garbage collection).

----------------------------------------------------------------------------------------------------
- id:dims-errors
- shade: shade3
- characteristics: errors-static, errors-dynamic, errors-code

High-level structure prevents many errors by construction. Script slips checked at runtime. 
Correction done in code based on an error message.

----------------------------------------------------------------------------------------------------
- id:dims-adoptability
- shade: shade3
- characteristics: adoptability-minimal, adoptability-nonexperts, adoptability-community

Focus on specific domain (hypermedia) and graphical interface supports learning. End-users can 
progresively become programmers. Closed from external world, but active community sharing examples.

----------------------------------------------------------------------------------------------------
- id:summary
- title:Hypercard
- class:systems-hypercard-anchor sysdet

# Hypercard

[![](img/sys/hypercard.jpg)](#image=systems/hypercard,screen)

Hypercard is a user-friendly general-purpose programming system built around the simple 
hypertext abstraction of linked cards. It combines graphical interface with scription,
allowing a smooth progression from end-user to creator.

Hypercard is interesting in how it combines programming and using in a single unified
interface that combines multiple complementing notations and how the interface and 
simple, yet flexible, programming model support adoption.

## Summary

- [Technical dimensions summary](-> #*=.;right=systems/hypercard,overview)
- [!](-> #*=.;right=systems-hypercard:paper,a-type!)

## Discussion

- [!](-> #*=.;right=systems-hypercard:dimensions/notation,complementing-notations!)
- [!](-> #*=.;right=systems-hypercard:dimensions/conceptual-structure,composability!)
- [!](-> #*=.;right=systems-hypercard:dimensions/adoptability,learnability!)

----------------------------------------------------------------------------------------------------
- id:screen
- title:Button configuration in Hypercard

> ![Hypercard screenshot](img/sys/hypercard.jpg)
> 
> **Hypercard screenshot.** User interface for specifying properties and actions associated with a button in Hypercard
> ([source](http://basalgangster.macgui.com/RetroMacComputing/The_Long_View/Entries/2010/10/23_HyperCard.html)).

----------------------------------------------------------------------------------------------------
- id:overview
- title:Technical dimensions summary
- class:dimlist

# Hypercard

### Interaction

![$](systems/hypercard,dims-interaction)

### Notation

![$](systems/hypercard,dims-notation)

### Conceptual structure

![$](systems/hypercard,dims-conceptual-structure)

### Customizability

![$](systems/hypercard,dims-customizability)

### Complexity

![$](systems/hypercard,dims-complexity)

### Errors

![$](systems/hypercard,dims-errors)

### Adoptability

![$](systems/hypercard,dims-adoptability)
