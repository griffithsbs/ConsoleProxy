ConsoleProxy is a quick and dirty solution to the problem of accommodating multiple console applications into a single Visual Studio project/solution.

It may occasionally prove useful as a little harness in which to build multiple little 'test/play/throwaway' applications inside Visual Studio without the overhead of having to create a new project for each new idea.
This is particularly convenient if you add the location of the ConsoleProxy binary to your path environment variable, allowing you to play/build/run little console apps with the minimum of fuss.

ConsoleProxy uses a few conventions:
(1) The name _Main is used instead of Main for the entry point into each application that you wish to run via ConsoleProxy's Main method
(2) All types used as an entry point reside in the namespace 'ConsoleProxy'
(3) All types used as an entry point must be marked as public and their (static) _Main method must also be marked public
(4) The first argument passed into ConsoleProxy specifies the name of the type whose _Main method is to be invoked. Any subsequent arguments are passed on to that _Main method.

e.g.
To run a 'console application' called TemplateMethods from the command line, we can enter:
> ConsoleProxy "TemplateMethods"