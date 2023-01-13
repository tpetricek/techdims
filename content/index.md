----------------------------------------------------------------------------------------------------
- id:welcome
- title:Technical dimensions of programming systems
- class:welcome

# Technical dimensions of programming systems

> by [Joel Jakubovic](https://programmingmadecomplicated.wordpress.com/), [Jonathan Edwards](https://alarmingdevelopment.org/) and [Tomas Petricek](https://tomasp.net)

[![A screenshot of the Smalltalk 76 programming environment](img/smalltalk-76.png)](#image=index,smalltalk-76)

Programming is done in a stateful environment, by interacting with a system through a
graphical user interface. The stateful, interactive and graphical environment is more
important than the programming language(s) used through it. Yet, most research focuses on comparing and 
studying _programming languages_ and only little has been said about _programming systems_.

Technical dimensions is a framework that captures the characteristics of programming
systems. It makes it possible to compare programming systems, better understand them, 
and to find interesting new points in the design space of programming systems.
We created technical dimensions to help designers of programming systems to evaluate,
compare and guide their work and, ultimately, stand on the shoulders of giants.

## Where to start to learn more

- Want to delve into the details and analyse your system?  
  [Start from the catalogue of technical dimensions](-> #left=index,catalogue;footer=index,navigation)
- Want to explore our framework by example?  
  [Start from good old programming systems](-> #left=index,systems)
- Want to see how this helps us understand programming systems?  
  [Start from a summary matrix of system and dimensions](-> #left=index,matrix-intro;big=index,matrix-body;footer=index,navigation)
- Want to understand our motivation and methodology?  
  [Start from our paper about technical dimensions](-> #left=paper,main)

----------------------------------------------------------------------------------------------------
- id:smalltalk-76
- title:Smalltalk 76 programming environment

> ![A screenshot of the Smalltalk 76 programming environment](img/smalltalk-76.png)
> 
> **Smalltalk 76 programming environment.** An example of a stateful programming environment with 
> rich graphical user interface. In Smalltalk, the developer environment is a part of an executing 
> program and the state of the program can be edited through object browser. 

----------------------------------------------------------------------------------------------------
- id:navigation
- title:Where to start to learn more

<div>

- Want to delve into the details and analyse your system?  
  [Start from the catalogue of technical dimensions](-> #left=index,catalogue;footer=index,navigation)
- Want to explore our framework by example?  
  [Start from good old programming systems](-> #left=index,systems)
- Want to see how this helps us understand programming systems?  
  [Start from a summary matrix of system and dimensions](-> #left=index,matrix-intro;big=index,matrix-body;footer=index,navigation)
- Want to understand our motivation and methodology?  
  [Start from our paper about technical dimensions](-> #left=paper,main)

</div>

----------------------------------------------------------------------------------------------------
- id:catalogue
- title:Ya

# Catalogue of technical dimensions

![$dimensions/interaction,summary](#left=.;right=dimensions/interaction,index)

----------------------------------------------------------------------------------------------------
- id:matrix-intro
- title:Summary matrix of systems and dimensions

# Matrix of systems and dimensions

The matrix shows the differences between [good old programming systems](#left=index,systems) 
along the dimensions identified by our framework. For conciseness, the table shows only one 
row for each cluster of dimensions, which consists of multiple separate dimensions each.

The header colors are used to mark systems that are similar (in an informal sense) 
for a given dimension. Icons indicate a speficic characteristics and should help you
find connections between systems. You can click on the header to go to a relevant 
paper section, but note that not all cases are discussed in the paper. 

----------------------------------------------------------------------------------------------------
- id:matrix-body
- title:Detailed matrix of systems and dimensions
- class:matrix

![$$](matrix-table)

## Select systems and dimensions to compare in the table

<div class="checksgroup">
<div class="checks">

<p>
<button onclick="[...document.getElementsByClassName('csys')].forEach(function(e) { e.checked=true; if (e.onchange) e.onchange(); });">Select all</button> 
<button onclick="[...document.getElementsByClassName('csys')].forEach(function(e) { e.checked=false; if (e.onchange) e.onchange(); });">Select none</button> 
</p>

![$$](matrix-syschecks)

</div>
<div class="checks">

<p>
<button onclick="[...document.getElementsByClassName('cdim')].forEach(function(e) { e.checked=true; if (e.onchange) e.onchange(); });">Select all</button> 
<button onclick="[...document.getElementsByClassName('cdim')].forEach(function(e) { e.checked=false; if (e.onchange) e.onchange(); });">Select none</button> 
</p>

![$$](matrix-dimchecks)

</div>
</div>

----------------------------------------------------------------------------------------------------
- id:systems
- title:Systems
- class:systems

# Programming systems

![$paper,definition](#left=.;right=paper,programming-systems)

![$systems/lisp-machines,summary](#left=.;right=systems/lisp-machines,index)

![$systems/smalltalk,summary](#left=.;right=systems/smalltalk,index)

![$systems/unix,summary](#left=.;right=systems/unix,index)

![$systems/spreadsheets,summary](#left=.;right=systems/spreadsheets,index)

![$systems/web,summary](#left=.;right=systems/web,index)

![$systems/hypercard,summary](#left=.;right=systems/hypercard,index)

![$systems/boxer,summary](#left=.;right=systems/boxer,index)

![$systems/notebooks,summary](#left=.;right=systems/notebooks,index)

![$systems/haskell,summary](#left=.;right=systems/haskell,index)
