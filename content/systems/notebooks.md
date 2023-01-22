----------------------------------------------------------------------------------------------------
- id:dims-interaction
- shade: shade3
- characteristics: interaction-single, interaction-repl, interaction-open, interaction-principles, interaction-concrete

Feedback and execution at cell level.
Programmatic abstractions are possible, but manual approach by copying or modifying code is common.

----------------------------------------------------------------------------------------------------
- id:dims-notation
- shade: shade2
- characteristics: notations-complementing, notations, notations-nonuniform, notations-graphical

Literate programming with code, text and outputs, embedded in a notebook as complementing notations.
Document model where notebook is a list of cells.

----------------------------------------------------------------------------------------------------
- id:dims-conceptual
- shade: shade4
- characteristics: concepts-large, concepts-diverse, concepts-noncomposable, concepts-convenient

Notebook and cells as "large" concepts with code notions (Python) as "small" concepts.
Composability primarily at code level, but not notebook level. Convenient libraries and tools.

----------------------------------------------------------------------------------------------------
- id:dims-customizability
- shade: shade2
- characteristics: custom-oss, custom-closed

System is fixed, but can theoretically be modified as open-source project with community.
Programs cannot modify themselves, notebook or system at runtime.

----------------------------------------------------------------------------------------------------
- id:dims-complexity
- shade: shade1
- characteristics: complexity-gc, complexity-domain, complexity-externalized

Complexity relegated to complex libraries (pandas, ML libraries, etc.) created outside the system.
Basic language automation (GC) but no automatic recomputation in standard Jupyter setup.

----------------------------------------------------------------------------------------------------
- id:dims-errors
- shade: shade2
- characteristics: errors-dynamic, errors-immediate

Slips caught at runtime. Limited checking of lapses or domain-specific mistakes.
REPL-evaluation provides quick feedback, making quick error correction possible.

----------------------------------------------------------------------------------------------------
- id:dims-adoptability
- shade: shade4
- characteristics: adoptability-domain, adoptability-nonexperts, adoptability-worse, adoptability-packages, adoptability-community

Learnability is supported by focus on a specific domain, graphical interface and community.
Notebooks can import a range of community packages and integrate with external systems.

----------------------------------------------------------------------------------------------------
- id:summary
- title:Notebooks

yadda

![](img/sys/ipython.png)


----------------------------------------------------------------------------------------------------
- id:index
- class:systems

# Notebooks

![$](content=summary,link=index)

more here

