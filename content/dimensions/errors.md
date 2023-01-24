----------------------------------------------------------------------------------------------------
- id:summary
- title: Errors
- class: dimensions-errors-anchor nobullet

# <i class="fa fa-bug"></i> Errors [Description and relations...](-> #*=.;right=dimensions/errors,index)

What does the system consider to be an error? How are they prevented and handled?

## Dimensions

- What errors can be detected in which feedback loops, and how?  
  [!](-> #*=.;right=dimensions/errors,error-detection!)
- How does the system respond when an error is detected?  
  [!](-> #*=.;right=dimensions/errors,error-response!)

## Examples and remarks

- [!](-> #*=.;right=dimensions/errors,static-typing!)
- [!](-> #*=.;right=dimensions/errors,tdd-repl-live!)
- [!](-> #*=.;right=dimensions/errors,latent-errors!)


----------------------------------------------------------------------------------------------------
- id:index
- title: Interaction

# Errors

**What does the system consider to be an error? How are they prevented and handled?**

A computer system is not aware of human intentions. There will always be human mistakes that the system cannot recognize as errors. Despite this, there are many that it *can* recognize, and its design will determine *which* human mistakes can become detectable program errors. This revolves around several questions: What can cause an error? Which ones can be prevented from happening? How should the system react to errors?

Following the standard literature on errors, [#](HumanError) we distinguish four kinds of errors: slips, lapses, mistakes and failures. A *slip* is an error caused by transient human attention failure, such as a typo in the source code. A *lapse* is similar but caused by memory failure, such as an incorrectly remembered method name. A *mistake* is a logical error such as bad design of an algorithm. Finally, a *failure* is a system error caused by the system itself that the programmer has no control over, e.g. a hardware or a virtual machine failure.

## References
The most common error handling mechanism in conventional programming languages is exception handling. The modern form of exception handling has been described by Goodenough; [#](ExceptionHandling) Ryder et al. [#](SweImpact) documents the history and influences of Software Engineering on exception handling. The concept of _antifragile software_ [#](Antifragile) goes further by suggesting that software could improve in response to errors. Work on Chaos Engineering [#](ChaosMonkey) is a step in this direction.

Reason [#](HumanError) analyses errors in the context of human errors and develops a classification of errors that we adopt. In the context of computing, errors or _miscomputation_ has been analysed from a philosophical perspective. [#](Miscomputation) [#](MalfunctioningSW) Notably, attitudes and approaches to errors also differ for different programming subcultures. [#](LivingWithErrors)

## Relations

[Feedback loops](-> #*=.;right=dimensions/interaction,feedback-loops) Error detection always happens as part of an individual feedback loop. The feedback loops thus determine the structure at which error detection can happen.

[Levels of automation](-> #*=.;right=dimensions/complexity,automation) A semi-automatic error recovery system (such as DWIM) implements a form of automation. The concept of antifragile software [#](Antifragile) is a more sophisticated example of error recovery through automation.

[Expression geography](-> #*=.;right=dimensions/notation,expression-geography) In an expression geography where small changes in notation lead to valid but differently behaved programs, a slip or lapse is more likely to lead to an error that is difficult to detect through standard mechanisms.

----------------------------------------------------------------------------------------------------
- id:error-detection
- title:Dimension: Error detection

# Dimensions: Error detection

Errors can be identified in any of the *feedback loops* that the system implements. This can be done either by a human or the system itself, depending on the nature of the feedback loop. 

Consider three examples: 

1. First, in live programming systems, the programmer immediately sees the result of their code changes. Error detection is done by a human and the system can assist this by visualizing as many consequences of a code change as possible. 

2. Second, in a system with a static checking feedback loop (such as syntax checks, static type systems), potential errors are reported as the result of the analysis. 

3. Third, errors can be detected when the developed software is run, either when it is tested by the programmer (manually or through automated testing) or when it is run by a user.

Error detection in different feedback loops is suitable for detecting different kinds of errors. Many slips and lapses can be detected by the static checking feedback loop, although this is not always the case. For example, consider a "compact" *expression geography* where small changes in code may result in large changes of behaviour. This makes it easier for slips and lapses to produce hard to detect errors. Mistakes are easier to detect through a live feedback loop, but they can also be partly detected by more advanced static checking.

## Related examples

<div class="nobullet">

- [!](-> #*=.;right=dimensions/errors,static-typing!)
- [!](-> #*=.;right=dimensions/errors,tdd-repl-live!)

</div>

----------------------------------------------------------------------------------------------------
- id:static-typing
- title:Example: Static typing

# Example: Static typing

In statically typed programming languages like Haskell and Java, types are used to capture some information about the intent of the programmer. The type checker ensures code matches the lightweight specification given using types. In such systems, types and implementation serve as two descriptions of programmer's intent that need to align; what varies is the extent to which types can capture intent and the way in which the two are constructed; that is, which of the two comes first.

----------------------------------------------------------------------------------------------------
- id:tdd-repl-live
- title:Examples: TDD, REPL and live coding

# Examples: TDD, REPL and live coding

Whereas static typing aims to detect errors without executing code, approaches based on immediate feedback typically aim to execute (a portion of) the code and let the programmer see the error immediately. This can be done in a variety of ways.

In case of *test-driven development*, tests play the role of specification (much like types) against which the implementation is checked. Such systems may provide more or less immediate feedback, depending on when tests are executed (automatically in the background, or manually). 

Systems equipped with a read-eval-print loop (REPL) let programmers run code on-the-fly and inspect results. For successful error detection, the results need to be easily observable: a printed output is more helpful than a hidden change of system state. 

Finally, in live coding systems, code is executed immediately and the programmer's ability to recognize errors depends on the extent to which the system state is observable. In live coded music, for example, you _hear_ that your code is not what you wanted, providing an easy-to-use immediate error detection mechanism.

----------------------------------------------------------------------------------------------------
- id:latent-errors
- title:Remark: Eliminating latent errors

# Remark: Eliminating latent errors

A common aim of error detection is to prevent *latent errors*, i.e. errors that occured at some *earlier* point during execution, but only manifest themselves through an unexpected behaviour later on. For example, we might dereference the wrong memory address and store a junk value to a database; we will only find out upon accessing the database. 

Latent errors can be prevented differently in different feedback loops. In a live feedback loop, this can be done by visualizing effects that would normally remain hidden. When running software, latent errors can be prevented through a mechanism that detects errors as early as possible (e.g. initializing pointers to `null` and stopping if they are dereferenced.)

## Elm and time-travel debugging

One notable mechanism for identifying latent errors is the concept of *time-travel debugging* popularized by the Elm programming language. In time-travel debugging, the programmer is able to step back through time and see what execution steps were taken prior to a certain point. This makes it possible to break execution when a latent error manifests, but then retrace the execution back to the actual source of the error.

----------------------------------------------------------------------------------------------------
- id:error-response
- title:Dimension: Error response

# Dimension: Error response

When an error is detected, there are a number of typical ways in which the system can respond. The following applies to systems that provide some kind of error detection during execution.

- It may attempt to automatically recover from the error as best as possible. This may be feasible for simpler errors (slips and lapses), but also for certain mistakes (a mistake in an algorithm's concurrency logic may often be resolved by restarting the code.)
- It may proceed as if the error did not happen. This can eliminate expensive checks, but may lead to latent errors later.
- It may ask a human how to resolve the issue. This can be done interactively, by entering into a mode where the code can be corrected, or non-interactively by stopping the system.

Orthogonally to the above options, a system may also have a way to recover from latent errors by tracing back through the execution in order to find the root cause. It may also have a mechanism for undoing all actions that occurred in the meantime, e.g. through transactional processing.

## Interlisp and Do What I Mean (DWIM)

Interlisp's [#](Interlisp) DWIM facility attempts to automatically correct slips and lapses, especially misspellings and unbalanced parentheses. When Interlisp encounters an error, such as a reference to an undefined symbol, it invokes DWIM. In this case, DWIM then searches for similarly named symbols frequently used by the current user. If it finds one, it invokes the symbol automatically, corrects the source code and notifies the user. In more complex cases where DWIM cannot correct the error automatically, it starts an interaction with the user and lets them correct it manually.
