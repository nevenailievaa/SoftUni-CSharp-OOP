using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;

namespace VendingRetail
{
    public class CoffeeMat
    {
        private Dictionary<string, double> drinks;
        private int waterTankLevel;
        private double income;
        private int waterCapacity;
        private int buttonsCount;

        public CoffeeMat(int waterCapacity, int buttonsCount)
        {
            WaterCapacity = waterCapacity;
            this.ButtonsCount = buttonsCount;
            this.income = 0;
            this.waterTankLevel = 0;
            this.drinks = new Dictionary<string, double>();

        }

        public int WaterCapacity 
        {
            get
            {
                return this.waterCapacity;
            }
            private set
            {
                this.waterCapacity = value;
            }
        }

        public int ButtonsCount 
        {
            get
            {
                return this.buttonsCount;
            }
            private set
            {
                this.buttonsCount = value;
            } 
        }

        public double Income => this.income;

        public string FillWaterTank()
        {
            if (waterTankLevel == waterCapacity)
            {
                return $"Water tank is already full!";
            }
            int mililitresFilled = waterCapacity - waterTankLevel;
            this.waterTankLevel += mililitresFilled;
            return $"Water tank is filled with {mililitresFilled}ml";
        }

        public bool AddDrink(string name, double price)
        {
            if (this.drinks.Count < buttonsCount && 
                !this.drinks.Any(d => d.Key == name))
            {
                drinks[name] = price;
                return true ;
            }
            return false ;
        }

        public string BuyDrink(string name)
        {
            if (waterTankLevel < 80)
            {
                return $"CoffeeMat is out of water!";
            }

            double priceToPay = 0;

            if (this.drinks.Keys.Any(k => k == name))
            {
                priceToPay = this.drinks[name];
                this.waterTankLevel -= 80;
                this.income += priceToPay;
            }                       
            else 
            {
                return $"{name} is not available!";
            }
            return $"Your bill is {priceToPay:f2}$";
        }

        public double CollectIncome()
        {
            double collectedIncome = this.income;
            this.income = 0;
            return collectedIncome;
        }
    }
}
