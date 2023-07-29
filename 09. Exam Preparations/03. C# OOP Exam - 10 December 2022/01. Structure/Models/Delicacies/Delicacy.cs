using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;

namespace ChristmasPastryShop.Models.Delicacies
{
    public abstract class Delicacy : IDelicacy
    {
        //Fields
        private string name;
        private double price;

        //Constructor
        public Delicacy(string name, double price)
        {
            Name = name;
            Price = price;
        }

        //Properties
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
                }
            }
        }

        public double Price { get => price; private set => price = value; }

        //Methods
        public override string ToString()
        {
            return $"{Name} - {Price:f2} lv";
        }
    }
}
