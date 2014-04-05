namespace TemplateMethods {

    public class CabDriver : Person {

        public CabDriver(string firstName, string surname) : base(firstName, surname) { }

        public override string GetOccupation() {
            return "Cab Driver";
        }
    }
}
