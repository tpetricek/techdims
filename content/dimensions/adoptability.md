----------------------------------------------------------------------------------------------------
- id:summary
- title: Adoptability
- class: dimensions-adoptability-anchor nobullet

# <i class="fa fa-code-fork"></i> Adoptability [Description and relations...](-> #*=.;right=dimensions/adoptability,index)

How does the system facilitate or obstruct adoption by both individuals and communities?

## Dimensions

- What is the attitude towards the learning curve and what is the target audience?  
  [!](-> #*=.;right=dimensions/adoptability,learnability!)
- What are the social and economic factors that make the system the way it is?  
  [!](-> #*=.;right=dimensions/adoptability,sociability!)

----------------------------------------------------------------------------------------------------
- id:index
- title: Adoptability

# Adoptability

**How does the system facilitate or obstruct adoption by both individuals and communities?**

We consider adoption by individuals as the dimension of *Learnability*, and adoption by communities as the dimension of *Sociability*.
For more information, refer to the two primary dimensions of this cluster.

<div class="nobullet">

- [!](-> #*=.;right=dimensions/adoptability,learnability!)
- [!](-> #*=.;right=dimensions/adoptability,sociability!)

</div>

----------------------------------------------------------------------------------------------------
- id:learnability
- title: Dimension: Learnability

# Dimension: Learnability
Mainstream software development technologies require substantial effort to learn. Systems can be made easier to learn in several ways:

<div class="narrow">

- Specializing to a specific application domain.
- Specializing to simple small-scale needs.
- Leveraging the background knowledge, skills, and terminologies of specific communities.
- Supporting learning with staged levels of complexity and assistive development tools [#](FullBrain). Better [Feedback Loops](#*=.;right=dimensions/interaction,feedback-loops) can help.
- Collapsing heterogeneous technology stacks into simpler unified systems. This relates to the dimensions under [Conceptual structure](#*=.;right=dimensions/conceptual-structure,index).

</div>

## Early programming languages

FORTRAN was a breakthrough in programming because it specialized to scientific computing and leveraged the background knowledge of scientists about mathematical formulas. COBOL instead specialized to business data processing and embraced the business community by eschewing mathematics in favor of plain English.

LOGO was the first language explicitly designed for teaching children. Later BASIC and Pascal were designed for teaching then-standard programming concepts at the University level. BASIC and Pascal had second careers on micropocessors in the 90's. These microprocessor programming systems were notable for being complete solutions integrating everything necessary, and so became home schools for a generation of programmers. More recently languages like Racket, Pyret, and Grace have supported learning by revealing progressive levels of complexity in stages. Scratch returned to Logo's vision of teaching children with a graphical programming environment emphasizing playfulness rather than generality.

## Focus on programmer-friendliness

Some programming languages have consciously prioritized the programmer's experience of learning and using them. Ruby calls itself _a programmer's best friend_ by focusing on simplicity and elegance. Elm targets the more specialized but still fairly broad domain of web applications while focusing on simplicity and programmer-friendliness. It forgoes capabilities that would lead to run-time crashes. It also tries hard to make error messages clear and actionable.

## Beyond programming languages

If we look beyond programming languages *per se*, we find programmable systems with better learnability. The best example is spreadsheets, which offer a specialized computing environment that is simpler and more intuitive. The visual metaphor of a grid leverages human perceptual skills. Moving all programming into declarative formulas and attributes greatly simplifies both creation and understanding. Research on Live Programming [#](Hancock2003) [#](BretVictor) has sought to incorporate these benefits into general purpose programming, but with limited success to date.

HyperCard and Flash were both programming systems that found widespread adoption by non-experts. Like spreadsheets they had an organizing visual metaphor (cards and timelines respectively). They both made it easy for beginners to get started. Hypercard had layers of complexity intended to facilitate gradual mastery.

## Smalltalk and Lisp machines

Smalltalk and Lisp machines were complex but unified. After overcoming the initial learning curve, their environments provided a complete solution for building entire application systems of arbitrary complexity without having to learn other technologies. Boxer [#](BoxerDesign) is notable for providing a general-purpose programming environment—albeit for small-scale applications—along with an organizing visual metaphor like that of spreadsheets.

----------------------------------------------------------------------------------------------------
- id:sociability
- title:Dimension: Sociability

# Dimension: Sociability
Over time, especially in the internet era, social issues have come to dominate programming. Much programming technology is now developed by open-source communities, and all programming technologies are now embedded in social media communities of their users. Therefore, technical decisions that impact socialibilty can be decisive [#](SocioPLT). These include:

- Compatibility: easy integration into standard technology stacks, allowing incremental adoption, and also easy exit if needed. This dynamic was discussed in the classic essay _Worse is Better_ [#](WIB) about how UNIX beat Lisp.
- Developing with an open source methodology reaps volunteer labor and fosters a user community of enthusiasts. The technical advantages of open source development were first popularized in the essay _The Cathedral and the Bazaar_ [#](Cathedral), which observed that "given enough eyeballs, all bugs are shallow". Open source has become the standard for software development tools, even those developed within large corporations.
- Easy sharing of code via package repositories or open exchanges. Prior to the open-source era, commercial marketplaces were important, like VBX components for VisualBasic. Sharing is impeded when languages lack standard libraries, leading to competing dialects, like Scheme [#](LispCurse).
- Dedicated social media communities can be fostered by using them to provide technical support. Volunteer technical support, like volunteer code contributions, can multiply the impact of core developers. In some cases, social media like Stack Exchange has even come to replace documentation.

One could argue that socialibilty is not purely a *technical* dimension, as it includes aspects of product management. Rather, we believe that sociability is a pervasive cross-cutting concern that cannot be *separated* from the technical.

## Programming system community
The tenor of the online community around a programming system can be its most public attribute. Even before social media, Flash developed a vibrant community of amateurs sharing code and tips. The Elm language invested much effort in creating a welcoming community from the outset [#](WhatIsSuccess). Attempts to reform older communities have introduced Codes of Conduct, but not without controversy.

On the other hand, a cloistered community that turns its back on the wider world can give its members strong feelings of belonging and purpose. Examples are Smalltalk, Racket, Clojure, and Haskell. These communities bear some resemblance to cults, with guru-like leaders, and fierce group cohesion.

## Economic sustainability

The economic sustainability of a programming system can be even more important than strictly social and technical issues. Adopting a technology is a costly investment in terms of time, money, and foregone opportunities. Everyone feels safer investing in a technology backed by large corporations that are not going away, or in technologies that have such widespread adoption that they are guaranteed to persist. A vibrant and mature open-source community backing a technology also makes it safer.

## Conflict with learnability

Unfortunately, sociability is often in conflict with learnability. Compatibility leads to ever increasing historical baggage for new learners to master. Large internet corporations have invested mainly in technologies relevant to their expert staff and high-end needs. Open-source communities have mainly flourished around technologies for expert programmers "scratching their own itch". While there has been a flow of venture funding into "no-code" and "low-code" programming systems, it is not clear how they can become economically and socially sustainable. By and large, the internet era has seen the ascendancy of expert programmers and the eclipsing of programming systems for "the rest of us".