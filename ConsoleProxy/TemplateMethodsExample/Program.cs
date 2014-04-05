using System;
using TemplateMethods;

namespace ConsoleProxy {
    /// <summary>
    /// A simple and contrived little example of a template method being used,
    /// which just serves as an example of a little console app that we can run
    /// by calling ConsoleProxy.Main with the argument "TemplateMethods"
    /// </summary>
    public class TemplateMethods {

        public static void _Main(string[] args) {
            PersonHandler.MakeItSpeak(new CabDriver("Jim", "Smith"));
            PersonHandler.MakeItSpeak(new Fireman("Sam", "the Fireman"));
        }

    }

    public class PersonHandler {

        public static void MakeItSpeak(Person p) {
            p.Speak();
        }

    }
}
