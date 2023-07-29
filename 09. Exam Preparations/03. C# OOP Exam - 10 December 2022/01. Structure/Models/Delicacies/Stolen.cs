namespace ChristmasPastryShop.Models.Delicacies
{
    public class Stolen : Delicacy
    {
        //Fields
        private const double price = 3.50;

        //Constructor
        public Stolen(string name) : base(name, price) { }
    }
}
