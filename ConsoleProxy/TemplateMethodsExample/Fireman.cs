namespace TemplateMethods {

    public class Fireman : Person {

        public Fireman(string firstName, string surname) : base(firstName, surname) { }

        public override string GetOccupation() {
            return "Fireman";
        }
    }
}
