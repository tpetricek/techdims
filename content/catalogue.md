----------------------------------------------------------------------------------------------------
- id:index
- title:Catalogue of technical dimensions
- class:catalogue nobullet

# Catalogue of technical dimensions

Technical dimensions break down discussion about
programming systems along various specific "axes". The dimensions identify
a range of possible design choices, characterized by two extreme points
in the design space.

[![A diagram showing programming systems with two dimensions](img/nest.png)](#image=catalogue,nest)

The dimensions are not quantitative, but they allow comparison.
The extreme points do not represent "good" and "bad" designs, merely different trade-offs.
The set of dimensions provides a map of the design space of programming systems (see diagram).
Past and present systems serve as landmarks, but the map also reveals unexplored
or overlooked possibilities.

The 23 technical dimensions are grouped into 7 clusters or topics of interest. 
Each cluster consists of individual dimensions, examples that capture a particular
well-known value (or a combination of values), remarks and relations to other dimensions. 
We do not expect the catalogue to be exhaustive for all aspects of programming systems, 
past and future, and welcome follow-up work expanding the list.

<div class="hide-sm">

- [<i class="fa fa-hand-pointer"></i> Interaction](-> #*=.;right=dimensions/interaction,index)
- [<i class="fa fa-code"></i> Notation](-> #*=.;right=dimensions/notation,index)
- [<i class="fa fa-cubes"></i> Conceptual structure](-> #*=.;right=dimensions/conceptual-structure,index)
- [<i class="fa fa-hammer"></i> Customizability](-> #*=.;right=dimensions/customizability,index)
- [<i class="fa fa-sitemap"></i> Complexity](-> #*=.;right=dimensions/complexity,index)
- [<i class="fa fa-bug"></i> Errors](-> #*=.;right=dimensions/errors,index)
- [<i class="fa fa-code-fork"></i> Adoptability](-> #*=.;right=dimensions/adoptability,index)

</div>

----------------------------------------------------------------------------------------------------
- id:list
- title:Catalogue of technical dimensions
- class:frameset catalogue

![$](dimensions/interaction,summary)

![$](dimensions/notation,summary)

![$](dimensions/conceptual-structure,summary)

![$](dimensions/customizability,summary)

![$](dimensions/complexity,summary)

![$](dimensions/errors,summary)

![$](dimensions/adoptability,summary)

----------------------------------------------------------------------------------------------------
- id:nest
- title:An illustration of the technical dimensions framework
- class:noborder

> ![A diagram showing programming systems with two dimensions](img/nest.png)
> 
> **Illustration of technical dimensions.** The diagram shows a number of sample programming
> systems, positioned according to two hypothetical dimensions. Viewed as programming systems,
> text-based programming languages with debugger, editor and build tools are grouped
> in one region.