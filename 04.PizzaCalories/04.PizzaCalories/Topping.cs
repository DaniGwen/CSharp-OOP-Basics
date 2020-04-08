using System;
using System.Collections.Generic;
using System.Text;

namespace _04.PizzaCalories
{
    public class Topping
    {
        private const double Meat = 1.2;
        private const double Veggies = 0.8;
        private const double Cheese = 1.1;
        private const double Sauce = 0.9;

        private double weight;
        private string toppingType;
        private double calories;

        public Topping(double weight, string type)
        {
            this.ToppingType = type;
            this.Weight = weight;
            this.Calories = this.GetTotalCalories();
        }

        public double Calories
        {
            get { return calories; }
            private set { calories = value; }
        }


        private string ToppingType
        {
            get { return toppingType; }
            set
            {
                if (value != "Meat" && value != "Veggies"
                    && value != "Cheese" && value != "Sauce")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                else
                {
                    toppingType = value;
                }
            }
        }

        private double Weight
        {
            get { return weight; }
            set
            {
                if (value > 50 || value < 1)
                {
                    throw new ArgumentException($"{toppingType} weight should be in the range[1..50]");
                }
                else
                {
                    weight = value;
                }
            }
        }

        private double GetTotalCalories()
        {
            var toppingModifier = 0.0;

            switch (ToppingType)
            {
                case "Meat":
                    toppingModifier = Meat;
                    break;
                case "Veggies":
                    toppingModifier = Veggies;
                    break;
                case "Cheese":
                    toppingModifier = Cheese;
                    break;
                case "Sauce":
                    toppingModifier = Sauce;
                    break;
            }

            return (2 * this.Weight) * toppingModifier;
        }

    }
}
