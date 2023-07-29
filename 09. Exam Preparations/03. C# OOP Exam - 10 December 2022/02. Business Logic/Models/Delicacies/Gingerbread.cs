using ChristmasPastryShop.Models.Delicacies;

namespace ChristmasPastryShop.Models.Delicacies
{
    public class Gingerbread : Delicacy
    {
        //Fields
        private const double basePrice = 4;

        //Constructor
        public Gingerbread(string name) : base(name, basePrice) { }
    }
}