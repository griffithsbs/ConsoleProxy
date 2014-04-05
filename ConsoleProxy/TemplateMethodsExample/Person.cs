using System;
namespace TemplateMethods {

    public abstract class Person {
        private string firstName;
        private string surname;

        public Person(string firstName, string surname) {
            this.firstName = firstName;
            this.surname = surname;
        }

        public void Speak() {
            Console.WriteLine("I am a {0} and my name is {1} {2}", this.GetOccupation(), this.firstName, this.surname);
        }

        public abstract string GetOccupation();

    }
}
