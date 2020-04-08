using System;

namespace _04.PizzaCalories
{
    public class Pizza
    {
        private string name;
        private int numberOfToppings;
        private double calories;
        private Dough dough;

        public Pizza(string name)
        {
            this.Name = name;
        }

        public Dough Dough
        {
            private get { return dough; }
            set
            {
                this.Calories += value.Calories;
                dough = value;
            }
        }


        public string Name
        {
            get { return name; }
            private set
            {
                if (value.Length < 1 || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                else
                {
                    name = value;
                }
            }
        }

        public int NumberOfToppings
        {
            get { return numberOfToppings; }
            private set { numberOfToppings = value; }
        }

        public double Calories
        {
            get { return calories; }
            private set { calories = value; }
        }

        public void AddTopping(Topping topping)
        {
            this.Calories += topping.Calories;
            this.NumberOfToppings += 1;
        }
    }
}
