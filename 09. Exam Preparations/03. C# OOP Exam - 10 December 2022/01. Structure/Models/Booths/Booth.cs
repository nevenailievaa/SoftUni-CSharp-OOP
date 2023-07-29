using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Repositories.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Text;

namespace ChristmasPastryShop.Models.Booths
{
    public class Booth : IBooth
    {
        //Fields
        private int boothId;
        private int capacity;
        private readonly IRepository<IDelicacy> delicacyMenu;
        private readonly IRepository<ICocktail> cocktailMenu;
        private double currentBill;
        private double turnover;
        private bool isReserved;

        //Constructor
        public Booth(int boothId, int capacity)
        {
            BoothId = boothId;
            Capacity = capacity;

            delicacyMenu = new DelicacyRepository();
            cocktailMenu = new CocktailRepository();
            currentBill = 0;
            turnover = 0;
            isReserved = false;
        }

        //Properties
        public int BoothId { get => boothId; private set => boothId = value; }

        public int Capacity
        {
            get => boothId;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.CapacityLessThanOne);
                }
                boothId = value;
            }
        }

        public IRepository<IDelicacy> DelicacyMenu => delicacyMenu;

        public IRepository<ICocktail> CocktailMenu => cocktailMenu;

        public double CurrentBill => currentBill;

        public double Turnover => turnover;

        public bool IsReserved => isReserved;


        //Methods
        public void ChangeStatus()
        {
            isReserved = !isReserved;
        }

        public void Charge()
        {
            turnover += currentBill;
            currentBill = 0;
        }

        public void UpdateCurrentBill(double amount)
        {
            currentBill += amount;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Booth: {boothId}");
            sb.AppendLine($"Capacity: {capacity}");
            sb.AppendLine($"Turnover: {turnover:f2} lv");

            sb.AppendLine($"-Cocktail menu:");
            foreach (var cocktail in cocktailMenu.Models)
            {
                sb.AppendLine(cocktail.ToString());
            }

            sb.AppendLine($"-Delicacy menu:");
            foreach (var delicacy in delicacyMenu.Models)
            {
                sb.AppendLine(delicacy.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}