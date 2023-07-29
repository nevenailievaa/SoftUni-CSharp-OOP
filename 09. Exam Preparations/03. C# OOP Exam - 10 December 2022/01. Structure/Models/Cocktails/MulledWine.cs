using ChristmasPastryShop.Models.Delicacies;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using System;

namespace ChristmasPastryShop.Models.Cocktails
{
    public class MulledWine : Cocktail
    {
        //Fields
        private const double basePrice = 13.50;

        //Constructor
        public MulledWine(string name, string size) : base(name, size, basePrice) { }
    }
}
