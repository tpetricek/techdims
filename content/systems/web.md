----------------------------------------------------------------------------------------------------
- id:dims-interaction
- shade: shade4
- characteristics: interaction-multi, interaction-repl, interaction-live, interaction-closed, interaction-open, interaction-principles

Edit and refresh mode with state visible in DOM browser and live developer tools.
Code abstractions are closed, but style abstractions more transparent.

----------------------------------------------------------------------------------------------------
- id:dims-notation
- shade: shade3
- characteristics: notations-complementing, notations-nonuniform

Diversity of text-based highly non-uniform notations (HTML, JavaScript, CSS) with limited structure editing for debugging (DOM).

----------------------------------------------------------------------------------------------------
- id:dims-conceptual
- shade: shade1
- characteristics: concepts-large, concepts-diverse, concepts-domain, concepts-convenient

Improvised mix of open "large" concepts (HTTP) and specific ones (DOM).
Many convenient libraries and tools with low commonality and varying composability.

----------------------------------------------------------------------------------------------------
- id:dims-customizability
- shade: shade4
- characteristics: custom-runtime, custom-closed, custom-addressing, custom-additive

Basic infrastructure (browser, protocols) are fixed. Individual applications can have
a large degree of modifiability (via dynamic scripting). CSS provides powerful addressing.

----------------------------------------------------------------------------------------------------
- id:dims-complexity
- shade: shade4
- characteristics: complexity-gc, complexity-rich, complexity-lowlevel, complexity-domain

Factoring via high-level languages (JavaScript), rule-based systems (CSS) and standard interfaces
(W3C specifications). Automation at basic level (garbage collection) and in declarative domains (CSS).

----------------------------------------------------------------------------------------------------
- id:dims-errors
- shade: shade4
- characteristics: errors-custom, errors-recovery, errors-code, errors-interactive

Generally aims to do the best thing possible (automatic recovery) on errors.
Direct error correction can be done in browser tools, but not permanent.

----------------------------------------------------------------------------------------------------
- id:dims-adoptability
- shade: shade4
- characteristics: adoptability-worse, adoptability-packages, adoptability-community

Web has a diversity of technologies; learnability is mainly achieved through community.
The diversified web ecosystem allows for the integration with external systems.

----------------------------------------------------------------------------------------------------
- id:summary
- title:Web platform
- class:systems-web-anchor sysdet

# Web platform

[![](img/sys/web-ie5.png)](#image=systems/web,screen)

yadda yadda

## Summary

- [Technical dimensions summary](-> #*=.;right=systems/web,overview)
- [!](-> #*=.;right=systems-web:paper,o-type!)

## Discussion

- [!](-> #*=.;right=systems-web:dimensions/notation,explicit-implicit-structure!)
- [!](-> #*=.;right=systems-web:dimensions/conceptual-structure,example-openness!)
- [!](-> #*=.;right=systems-web:dimensions/customizability,staging!)
- [!](-> #*=.;right=systems-web:dimensions/customizability,addressing!)

----------------------------------------------------------------------------------------------------
- id:screen
- title:A web page opening a pop-up window in Internet Explorer 5

> ![Web platform screenshot](img/sys/web-ie5.png)
> 
> **Web platform screenshot.** A simple page that opens a pop-up window and contains a JavaScript coding error, running in Internet Explorer 5 on Windows 98.
> ([source](https://tomasp.net/blog/2021/popup-from-hell/)).

----------------------------------------------------------------------------------------------------
- id:overview
- title:Technical dimensions summary
- class:dimlist

# Web platform

### Interaction

![$](systems/web,dims-interaction)

### Notation

![$](systems/web,dims-notation)

### Conceptual structure

![$](systems/web,dims-conceptual)

### Customizability

![$](systems/web,dims-customizability)

### Complexity

![$](systems/web,dims-complexity)

### Errors

![$](systems/web,dims-errors)

### Adoptability

![$](systems/web,dims-adoptability)
