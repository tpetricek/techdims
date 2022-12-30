----------------------------------------------------------------------------------------------------
- id:abstract
- title:Abstract

# Abstract

Programming requires much more than just writing code in a programming language. It is usually done in the context of a stateful environment, by interacting with a system through a graphical user interface. Yet, this wide space of possibilities lacks a common structure for navigation. Work on programming systems fails to form a coherent body of research, making it hard to improve on past work and advance the state of the art.
  
In computer science, much has been said and done to allow comparison of _programming languages_, yet no similar theory exists for _programming systems_; we believe that programming systems deserve a theory too. 
  
We present a framework of _technical dimensions_ which capture the underlying characteristics of programming systems and provide a means for conceptualizing and comparing them. 
  
We identify technical dimensions by examining past influential programming systems and reviewing their design principles, technical capabilities, and styles of user interaction. Technical dimensions capture characteristics that may be studied, compared and advanced independently. This makes it possible to talk about programming systems in a way that can be shared and constructively debated rather than relying solely on personal impressions.
   
Our framework is derived using a qualitative analysis of past programming systems. We outline two concrete ways of using our framework. First, we show how it can analyze a recently developed novel programming system. Then, we use it to identify an interesting unexplored point in the design space of programming systems. 
  
Much research effort focuses on building programming systems that are easier to use, accessible to non-experts, moldable and/or powerful, but such efforts are disconnected. They are informal, guided by the personal vision of their authors and thus are only evaluable and comparable on the basis of individual experience using them. By providing foundations for more systematic research, we can help programming systems researchers to stand, at last, on the shoulders of giants.

----------------------------------------------------------------------------------------------------
- id:introduction
- title:Introduction

A systematic presentation removes ideas from the ground that made them grow and arranges them in an artificial pattern.
The Tyranny of Science, Paul Feyerabend

Irony is said to allow the artist to continue his creative production while immersed in a sociocultural context of which he is critical.
Irony; or, the Self-Critical Opacity of Postmodernist Architecture, Emmanuel Petit


# Introduction

Many forms of software have been developed to enable programming. The classic form consists of a *programming language*, a text editor to enter source code, and a compiler to turn it into an executable program. Instances of this form are differentiated by the syntax and semantics of the language, along with the implementation techniques in the compiler or runtime environment. Since the advent of graphical user interfaces (GUIs), programming languages can be found embedded within graphical environments that increasingly define how programmers work with the language---for instance, by directly supporting debugging or refactoring. Beyond this, the rise of GUIs also permits diverse visual forms of programming, including visual languages and GUI-based end-user programming tools.

This paper advocates a shift of attention from *programming languages* to the more general notion of "software that enables programming"---in other words, *programming systems*.

\begin{defn}[Programming System]
A \emph{programming system} is an integrated and complete set of tools sufficient for creating, modifying, and executing programs. These will include notations for structuring programs and data, facilities for running and debugging programs, and interfaces for performing all of these tasks. Facilities for testing, analysis, packaging, or version control may also be present. Notations include programming languages and interfaces include text editors, but are not limited to these.
\end{defn}

This notion covers classic programming languages together with their editors, debuggers, compilers, and other tools. Yet it is intentionally broad enough to accommodate image-based programming environments like Smalltalk, operating systems like UNIX, and hypermedia authoring systems like Hypercard, in addition to various other examples we will mention.

## The problem: no systematic framework for systems

There is a growing interest in broader forms of *programming systems*, both in the programming research community and in industry. Researchers are studying topics such as *programming experience* and *live programming* that require considering not just the *language*, but further aspects of a given system. At the same time, commercial companies are building new programming environments like Replit\ \cite{ReplitWeb} or low-code tools like Dark\ \cite{DarkWeb} and Glide\ \cite{GlideWeb}. Yet, such topics remain at the sidelines of mainstream programming research. While *programming languages* are a well-established concept, analysed and compared in a common vocabulary, no similar foundation exists for the wider range of *programming systems*.

The academic research on programming suffers from this lack of common vocabulary. While we may thoroughly assess programming *languages*, as soon as we add interaction or graphics into the picture, evaluation beyond subjective "coolness" becomes fraught with difficulty.^[The same difficulty in the context of user interface systems has been analyzed by Olsen\ \cite{EvUISR}. Interesting future work would be a detailed analysis of publications on programming systems to understand this issue in depth. One notable characteristic is that publications tend to present (parts of) new systems. This is the case for 5/6 and 6/7 papers in the LIVE 2020 and 2021 workshops respectively\ \cite{LIVE20, LIVE21}. In contrast, publications in the field of programming *languages* often address specific issues of interest to a greater number of languages.] Moreover, when designing new systems, inspiration is often drawn from the same few standalone sources of ideas. These might be influential past systems like Smalltalk, programmable end-user applications like spreadsheets, or motivational illustrations like those of Bret Victor\ \cite{BretVictor}.

Instead of forming a solid body of work, the ideas that emerge are difficult to relate to each other. The research methods used to study programming systems lack the rigorous structure of programming language research methods. They tend to rely on singleton examples, which demonstrate their author's ideas, but are inadequate methods for comparing new ideas with the work of others. This makes it hard to build on top and thereby advance the state of the art.

Studying *programming systems* is not merely about taking a programming language and looking at the tools that surround it. It presents a *paradigm shift* to a perspective that is, at least partly, *incommensurable* with that of languages. When studying programming languages, everything that matters is in the program code; when studying programming systems, everything that matters is in the *interaction* between the programmer and the system. As documented by Gabriel\ \cite{PLrev}, looking at a *system* from a *language* perspective makes it impossible to think about concepts that arise from interaction with a system, but are not reflected in the language. Thus, we must proceed with some caution. As we will see, when we talk about Lisp as a programming system, we mean something very different from a parenthesis-heavy programming language!

## Contributions
We propose a common language as an initial step towards a more progressive research on programming systems. Our set of *technical dimensions* seeks to break down the holistic view of systems along various specific "axes". The dimensions identify a range of possible design choices, characterized by two extreme points in the design space. They are not quantitative, but they allow comparison by locating systems on a common axis. We do not intend for the extreme points to represent "good" or "bad" designs; we expect any position to be a result of design trade-offs. At this early stage in the life of such a framework, we encourage agreement on descriptions of systems first in order to settle any normative judgements later.

The set of dimensions can be understood as a map of the design space of programming systems (Figure\ \ref{fig:tech-dims-diagram}). Past and present systems will serve as landmarks, and with enough of them, we may reveal unexplored or overlooked possibilities. So far, the field has not been able to establish a virtuous cycle of feedback; it is hard for practitioners to situate their work in the context of others' so that subsequent work can improve on it. Our aim is to provide foundations for the study of programming systems that would allow such development.

This paper is intended as a reference on the current state of the technical dimensions framework and it is meant to be _used_ rather than _read_. We present the dimensions in detail, but encourage the reader to skim through the details on the first read. Subsequently, we suggest revisiting dimensions which seem relevant to a concrete system known to the reader. The main contributions of this paper are organized as follows:

1. In Section\ \ref{programming-systems}, we characterize what a programming system is and review landmark programming systems of the past that are used as examples throughout this paper, as well as to delineate our notion of a programming system.
2. We present the technical dimensions in detail, organised into related clusters: *interaction*, *notation*, *conceptual structure*, *customizability*, *complexity*, *errors*, and *adoptability*. For each dimension, we give examples that illustrate the range of values along its axis. We intend this as a reference to be used as needed rather than something to be read from start to finish, so we recommend skimming the catalogue on the first reading.
2. In Section\ \ref{evaluation}, we sketch two ways of using the technical dimensions framework. In Section\ \ref{evaluating-the-dark-programming-system}, we use it to evaluate a recent interesting programming system; in Section\ \ref{exploring-the-design-space}, we use it to identify an unexplored point in the design space and envision a potential novel programming system.

\begin{figure}
  \centering
  \includegraphics[width=0.6\linewidth]{plot-figure0.pdf}
  \caption{One 2-dimensional slice of the space of possible systems, to be examined in more detail in Section\ \ref{exploring-the-design-space}.\label{fig:tech-dims-diagram}}
\end{figure}

----------------------------------------------------------------------------------------------------
- id:definition
- title:What is a Programming System?

A _programming system_ is an integrated and complete set of tools sufficient for creating, modifying, and executing programs. These will include notations for structuring programs and data, facilities for running and debugging programs, and interfaces for performing all of these tasks. Facilities for testing, analysis, packaging, or version control may also be present. Notations include programming languages and interfaces include text editors, but are not limited to these.

----------------------------------------------------------------------------------------------------
- id:programming-systems

![$](content=paper;definition,link=paper;programming-systems)

We introduce the notion of a _programming system_ through a number of example systems. We draw them from three broad reference classes:

- Software ecosystems built around a text-based programming _language_. They consist of a set of tools such as compilers, debuggers, and profilers. These tools may exist as separate command-line programs, or within an Integrated Development Environment.

- Those that resemble an _operating system_ (OS) in that they structure the execution environment and encompass the resources of an entire machine (physical or virtual). They provide a common interface for communication, both between the user and the computer, and between programs themselves.

- Programmable _applications_, typically optimized for a specific domain, offering a limited degree of programmability which may be increased with newer versions.

We will proceed to detail some systems under this grouping. This will provide an intuition for the notion of a programming system and establish a collection of go-to examples for the rest of the paper.

## Systems based around languages

Text-based programming languages sit within programming systems whose boundaries are not explicitly defined. To speak of a programming system, we need to consider a language with, at minimum, an editor and a compiler or interpreter. However, the exact boundaries are a design choice that significantly affects our analysis.

\paragraph{Java with the Eclipse ecosystem.}
Java\ \cite{Java} cannot be viewed as a programming system on its own, but it is one if we consider it as embedded in an ecosystem of tools. There are multiple ways to delineate this, resulting in different analyses. A minimalistic programming system would consist of a text editor to write Java code and a command line compiler. A more realistic system is Java as embedded in the Eclipse IDE\ \cite{Eclipse}. The programming systems view allows us to see all there is beyond the textual code. In the case of Eclipse, this includes the debugger, refactoring tools, testing and modelling tools, GUI designers, and so on. This delineation yields a programming system that is powerful and convenient, but has a large number of concepts and secondary notations.

\paragraph{Haskell tools ecosystem.}
Haskell is an even more language-focused programming system. It is used through the command-line *GHC*  compiler\ \cite{GHC} and *GHCi* REPL, alongside a text editor that provides features like syntax highlighting and auto-completion. Any editor that supports the Language Server Protocol\ \cite{LSP} will suffice to complete the programming system.

Haskell is mathematically rooted and relies on mathematical intuition for understanding many of its concepts. This background is also reflected in the notations it uses. In addition to the concrete language syntax for writing code, the ecosystem also uses an informal mathematical notation for writing about Haskell (e.g. in academic papers or on the whiteboard). This provides an additional tool for manipulating Haskell programs. Experiments on paper can provide a kind of rapid feedback that other systems may provide through live programming.

\paragraph{From REPLs to notebooks.}
A different kind of developer ecosystem that evolved around a programming language is the Jupyter notebook platform\ \cite{Jupyter}. In Jupyter, data scientists write scripts divided into notebook cells, execute them interactively and see the resulting data and visualizations directly in the notebook itself. This brings together the REPL, which dates back to conversational implementations of Lisp in the 1960s, with literate programming\ \cite{LiterateProg} used in the late 1980s in Mathematica 1.0\ \cite{Mathematica}.

As a programming system, Jupyter has a number of interesting characteristics. The primary outcome of programming is the notebook itself, rather than a separate application to be compiled and run. The code lives in a document format, interleaved with other notations. Code is written in small parts that are executed quickly, offering the user more rapid feedback than in conventional programming. A notebook can be seen as a trace of how the result has been obtained, yet one often problematic feature of notebooks is that some allow the user to run code blocks out-of-order. The code manipulates mutable state that exists in a "kernel" running in the background. Thus, retracing one's steps in a notebook is more subtle than in, say, Common Lisp\ \cite{CommonLisp}, where the `dribble` function would directly record the user's session to a file.

## OS-like programming systems

"OS-likes" begin from the 1960s when it became possible to interact one-on-one with a computer. First, time-sharing systems enabled interactive shared use of a computer via a teletype; smaller computers such as the PDP-1 and PDP-8 provided similar direct interaction, while 1970s workstations such as the Alto and Lisp Machines added graphical displays and mouse input. These *OS-like* systems stand out as having the totalising scope of *operating systems*, whether or not they are ordinarily seen as taking this role.

\paragraph{MacLisp and Interlisp.}
LISP 1.5\ \cite{LISP15} arrived before the rise of interactive computers, but the existence of an interpreter and the absence of declarations made it natural to use Lisp interactively, with the first such implementations appearing in the early 1960s. Two branches of the Lisp family\ \cite{LispEvolve}, MacLisp and the later Interlisp, embraced the interactive "conversational" way of working, first through a teletype and later using the screen and keyboard.

Both MacLisp and Interlisp adopted the idea of *persistent address space*. Both program code and program state were preserved when powering off the system, and could be accessed and modified interactively as well as programmatically using the *same means*. Lisp Machines embraced the idea that the machine runs continually and saves the state to disk when needed. Today, this is widely seen in cloud-based services like Google Docs and online IDEs. Another idea pioneered in MacLisp and Interlisp was the use of *structure editors*. These let programmers work with Lisp data structures not as sequences of characters, but as nested lists. In Interlisp, the programmer would use commands such as `*P` to print the current expression, or `*(2 (X Y))` to replace its second element with the argument `(X Y)`. The PILOT system\ \cite{Pilot} offered even more sophisticated conversational features. For typographical errors and other slips, it would offer an automatic fix for the user to interactively accept, modifying the program in memory and resuming execution.

\paragraph{Smalltalk.}
Smalltalk appeared in the 1970s with a distinct ambition of providing "dynamic media which can be used by human beings of all ages"\ \cite{PersonalDynMedia}. The authors saw computers as *meta-media* that could become a range of other media for education, discourse, creative arts, simulation and other applications not yet invented. Smalltalk was designed for single-user workstations with a graphical display, and pioneered this display not just for applications but also for programming itself. In Smalltalk 72, one wrote code in the bottom half of the screen using a structure editor controlled by a mouse, and menus to edit definitions. In Smalltalk-76 and later, this had switched to text editing embedded in a *class browser* for navigating through classes and their methods.

Similarly to Lisp systems, Smalltalk adopts the persistent address space model of programming where all objects remain in memory, but based on _objects_ and _message passing_ rather than _lists_. Any changes made to the system state by programming or execution are preserved when the computer is turned off. Lastly, the fact that much of the Smalltalk environment is implemented in itself makes it possible to extensively modify the system from within.

We include Lisp and Smalltalk in the OS-likes because they function as operating systems in many ways. On specialized machines, like the Xerox Alto and Lisp machines, the user started their machine directly in the Lisp or Smalltalk environment and was able to do everything they needed from *within* the system. Nowadays, however, this experience is associated with UNIX and its descendants on a vast range of commodity machines.

\paragraph{UNIX.}
UNIX illustrates the fact that many aspects of programming systems are shaped by their intended target audience. Built for computer hackers\ \cite{Hackers}, its abstractions and interface are close to the machine. Although historically linked to the C language, UNIX developed a language-agnostic set of abstractions that make it possible to use multiple programming languages in a single system. While everything is an object in Smalltalk, the ontology of the UNIX system consists of files, memory, executable programs, and running processes. Note the explicit "stage" distinction here: UNIX distinguishes between volatile *memory* structures, which are lost when the system is shut down, and non-volatile *disk* structures that are preserved. This distinction between types of memory is considered, by Lisp and Smalltalk, to be an implementation detail to be abstracted over by their persistent address space. Still, this did not prevent the UNIX ontology from supporting a pluralistic ecosystem of different languages and tools.

\paragraph{Early and modern Web.}
The Web evolved\ \cite{DotCom} from a system for sharing and organizing information to a *programming system*. Today, it consists of a wide range of server-side programming tools, JavaScript and languages that compile to it, and notations like HTML and CSS. As a programming system, the "modern 2020s web" is reasonably distinct from the "early 1990s web". In the early web, JavaScript code was distributed in a form that made it easy to copy and re-use existing scripts, which led to enthusiastic adoption by non-experts---recalling the birth of microcomputers like Commodore 64 with BASIC a decade earlier.

In the "modern web", multiple programming languages treat JavaScript as a compilation target, and JavaScript is also used as a language on the server-side. This web is no longer simple enough to encourage copy-and-paste remixing of code from different sites. However, it does come with advanced developer tools that provide functionality resembling early interactive programming systems like Lisp and Smalltalk. The *Document Object Model (DOM)* structure created by a web page is transparent, accessible to the user and modifiable through the built-in browser inspector tools. Third-party code to modify the DOM can be injected via extensions. The DOM almost resembles the tree/graph model of Smalltalk and Lisp images, lacking the key persistence property. This limitation, however, is being addressed by Webstrates\ \cite{Webstrates}.

## Application-focused systems
The previously discussed programming systems were either universal, not focusing on any particular kind of application, or targeted at broad fields, such as Artificial Intelligence and symbolic data manipulation in Lisp's case. In contrast, the following examples focus on more narrow kinds of applications that need to be built. Many support programming based on rich interactions with specialized visual and textual notations.

\paragraph{Spreadsheets.}
The first spreadsheets became available in 1979 in VisiCalc\ \cite{VisiCalc, VisiCalc2} and helped analysts perform budget calculations. As programming systems, spreadsheets are notable for their programming substrate (a two-dimensional grid) and evaluation model (automatic re-evaluation). The programmability of spreadsheets developed over time, acquiring features that made them into powerful programming systems in a way VisiCalc was not. The final step was the 1993 inclusion of *macros* in Excel, later further extended with *Visual Basic for Applications*.

\paragraph{Graphical "languages".}
Efforts to support programming without relying on textual code can only be called "languages" in a metaphorical sense. In these programming systems, programs are made out of graphical structures as in LabView\ \cite{LabView} or Programming-By-Example\ \cite{PBE}.

\paragraph{HyperCard.}
While spreadsheets were designed to solve problems in a specific application area, HyperCard\ \cite{HyperCard} was designed around a particular application format. Programs are "stacks of cards" containing multimedia components and controls such as buttons. These controls can be programmed with pre-defined operations like "navigate to another card", or via the HyperTalk scripting language for anything more sophisticated.

As a programming system, HyperCard is interesting for a couple of reasons. It effectively combines visual and textual notation. Programs appear the same way during editing as they do during execution. Most notably, HyperCard supports gradual progression from the "user" role to "developer": a user may first use stacks, then go on to edit the visual aspects or choose pre-defined logic until, eventually, they learn to program in HyperTalk.
