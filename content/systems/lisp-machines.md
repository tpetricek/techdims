----------------------------------------------------------------------------------------------------
- id:dims-interaction
- shade: shade1
- characteristics: interaction-single, interaction-repl, interaction-open, interaction-principles

Integrated execution and editing mode, giving feedback at runtime. 
Abstractions constructed using functions are accessible as data.

----------------------------------------------------------------------------------------------------
- id:dims-notation
- shade: shade4
- characteristics: notations-primary, notations, notations-uniform

Very uniform notation with code and data represented as S-expressions 
and edited either as text or using structure editor. Use of domain-specific languages.

----------------------------------------------------------------------------------------------------
- id:dims-conceptual
- shade: shade2
- characteristics: concepts-interface, concepts-minimal, concepts-composable, concepts-nonconvenient

Small number of unified concepts ("everything is a list") at odds with outside world.
Allows for composability, but lacks convenience ("Lisp curse").

----------------------------------------------------------------------------------------------------
- id:dims-customizability
- shade: shade3
- characteristics: concepts-large, custom-runtime, custom-addressing, custom-additive, custom-sustainable

System can be customized at runtime. Much of the system is written in itself and can be
modified from within itself. Addressing can be done via "advising".

----------------------------------------------------------------------------------------------------
- id:dims-complexity
- shade: shade3
- characteristics: complexity-gc, complexity-rich

Optional but common factoring mechanisms include functions, CLOS and domain-specific languages.
Basic automation (garbage collection) with more in the context of AI research.

----------------------------------------------------------------------------------------------------
- id:dims-errors
- shade: shade1
- characteristics: errors-dynamic, errors-recovery, errors-interactive

Errors detected at runtime and can be corrected immediately in interactive editor/debugger.
More checking can be done via reflection and code analysis.

----------------------------------------------------------------------------------------------------
- id:dims-adoptability
- shade: shade1
- characteristics: adoptability-unified, adoptability-community

Steep learning curve, but uniform design makes understanding reusable. Designed for programmers.
Active community, but closed from the external world and limited packages available.

----------------------------------------------------------------------------------------------------
- id:summary
- title:Lisp machines
- class:systems-lisp-machines-anchor sysdet

# Lisp machines

[![Lisp machines screenshot](img/sys/lisp-genera.gif)](#image=systems/lisp-machines,screen)

Lisp machines are general-purpose computers designed to run Lisp. They generally run a version of
operating-system like Lisp that evolved from MacLisp and Interlisp. 

Lisp machines use a persistent image-based model with all data and code existing in memory
(in theory, at least) in the form of addressable and uniform S-expressions.
This allows self-sustainability and interactive error-response. 

## Summary

- [Technical dimensions summary](-> #*=.;right=systems/lisp-machines,overview)
- [!](-> #*=.;right=systems-lisp-machines:paper,o-type!)

## Discussion

- [!](-> #*=.;right=systems-lisp-machines:dimensions/interaction,modes-of-interaction!)
- [!](-> #*=.;right=systems-lisp-machines:dimensions/notation,uniformity-of-notations!)
- [!](-> #*=.;right=systems-lisp-machines:dimensions/conceptual-structure,example-integrity!)
- [!](-> #*=.;right=systems-lisp-machines:dimensions/conceptual-structure,example-openness!)
- [!](-> #*=.;right=systems-lisp-machines:dimensions/customizability,staging!)
- [!](-> #*=.;right=systems-lisp-machines:dimensions/errors,error-response!)
- [!](-> #*=.;right=systems-lisp-machines:dimensions/adoptability,learnability!)
- [!](-> #*=.;right=systems-lisp-machines:dimensions/adoptability,sociability!)

----------------------------------------------------------------------------------------------------
- id:screen
- title:Source-oriented debugging in the Genera system for Lisp machines 

> ![Lisp machines screenshot](img/sys/lisp-genera.gif)
> 
> **Lisp machines screenshot.** Source-oriented debugging in the Genera system for Lisp machines
> ([source](https://www.ifis.uni-luebeck.de/~moeller/symbolics-info/index.html)).

----------------------------------------------------------------------------------------------------
- id:overview
- title:Technical dimensions summary
- class:dimlist

# Lisp machines

### Interaction

![$](systems/lisp-machines,dims-interaction)

### Notation

![$](systems/lisp-machines,dims-notation)

### Conceptual structure

![$](systems/lisp-machines,dims-conceptual)

### Customizability

![$](systems/lisp-machines,dims-customizability)

### Complexity

![$](systems/lisp-machines,dims-complexity)

### Errors

![$](systems/lisp-machines,dims-errors)

### Adoptability

![$](systems/lisp-machines,dims-adoptability)
