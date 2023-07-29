using System.Reflection.PortableExecutable;

namespace ChristmasPastryShop.Models.Delicacies
{
    public class Stolen : Delicacy
    {
        //Fields
        private const double basePrice = 3.50;

        //Constructor
        public Stolen(string name) : base(name, basePrice) { }
    }
}