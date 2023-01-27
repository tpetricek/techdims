----------------------------------------------------------------------------------------------------
- id:dims-interaction
- shade: shade2
- characteristics: interaction-multi, interaction-repl, interaction-closed, interaction-principles, interaction-concrete

Edit, build and execution modes with feedback in each step.
Abstractions include files, memory and processes. Shell allows going from concrete to abstract.

----------------------------------------------------------------------------------------------------
- id:dims-notation
- shade: shade3
- characteristics: notations-primary, notations-complementing, notations-nonuniform, notations-concise

Primary notation (the C language) with variety of secondary (file system, shell scripts), 
all edited via text editor. Admits concise but error-prone notations.

----------------------------------------------------------------------------------------------------
- id:dims-conceptual
- shade: shade1
- characteristics: concepts-large, concepts-composable, concepts-convenient

Files provide "large" common concepts, but details are open. 
Scripting based on small composable tools. Standard libraries and tools offer convenience.

----------------------------------------------------------------------------------------------------
- id:dims-customizability
- shade: shade3
- characteristics: custom-stages, custom-additive, custom-sustainable

Explicit stage distinction between execution and building, but system is written using its
own notation (C language) and can be modified and rebuilt from within itself. Limited
modifiability at runtime.

----------------------------------------------------------------------------------------------------
- id:dims-complexity
- shade: shade4
- characteristics: complexity-manual, complexity-lowlevel

Defines low-level infrastructure (hardware abstractions) and large object structure (files, processes);
small-scale factoring and automation left to the user and/or application.

----------------------------------------------------------------------------------------------------
- id:dims-errors
- shade: shade4
- characteristics: errors-shootfoot, errors-custom

Error detection left to the system user. Low-level primitives make it possible to 
automate detection and response via custom mechanisms.

----------------------------------------------------------------------------------------------------
- id:dims-adoptability
- shade: shade2
- characteristics: adoptability-background, adoptability-worse, adoptability-community

Requires background knowledge (system-level), but supported by active community.
Openness allows integration with the external world; diversity of packages available.

----------------------------------------------------------------------------------------------------
- id:summary
- title:UNIX
- class:systems-unix-anchor sysdet

# UNIX

[![](img/sys/unix-6.png)](#image=systems/unix,screen)

yadda yadda

## Summary

- [Technical dimensions summary](-> #*=.;right=systems/unix,overview)
- [!](-> #*=.;right=systems-unix:paper,o-type!)

## Discussion

- [!](-> #*=.;right=systems-unix:dimensions/notation,primary-secondary-notations!)
- [!](-> #*=.;right=systems-unix:dimensions/notation,expression-geography!)
- [!](-> #*=.;right=systems-unix:dimensions/conceptual-structure,composability!)
- [!](-> #*=.;right=systems-unix:dimensions/conceptual-structure,convenience!)
- [!](-> #*=.;right=systems-unix:dimensions/conceptual-structure,example-openness!)
- [!](-> #*=.;right=systems-unix:dimensions/customizability,self-sustainability!)
- [!](-> #*=.;right=systems-unix:dimensions/adoptability,sociability!)

----------------------------------------------------------------------------------------------------
- id:screen
- title:Version 6 UNIX running in a PDP-11 emulator

> ![UNIX 6 screenshot](img/sys/unix-6.png)
> 
> **UNIX screenshot.** Version 6 Unix running in the SIMH PDP-11 emulator. This was the first widely distributed version of UNIX, released in 1975
> ([source](https://en.wikipedia.org/wiki/Version_6_Unix)).

----------------------------------------------------------------------------------------------------
- id:overview
- title:Technical dimensions summary
- class:dimlist

# UNIX

### Interaction

![$](systems/unix,dims-interaction)

### Notation

![$](systems/unix,dims-notation)

### Conceptual structure

![$](systems/unix,dims-conceptual)

### Customizability

![$](systems/unix,dims-customizability)

### Complexity

![$](systems/unix,dims-complexity)

### Errors

![$](systems/unix,dims-errors)

### Adoptability

![$](systems/unix,dims-adoptability)
