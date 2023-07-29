namespace ChristmasPastryShop.Models.Cocktails
{
    public class Hibernation : Cocktail
    {
        //Fields
        private const double basePrice = 10.50;

        //Constructor
        public Hibernation(string name, string size) : base(name, size, basePrice) { }
    }
}
