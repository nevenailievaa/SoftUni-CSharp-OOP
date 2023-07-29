namespace ChristmasPastryShop.Models.Delicacies
{
    public class Gingerbread : Delicacy
    {
        //Fields
        private const double price = 4;

        //Constructor
        public Gingerbread(string name) : base(name, price) { }
    }
}
