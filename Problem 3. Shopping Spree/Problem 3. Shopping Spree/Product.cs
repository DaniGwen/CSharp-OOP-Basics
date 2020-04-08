
using System;

namespace Problem_3._Shopping_Spree
{
    public class Product
    {
        private string name;
        private double cost;

        public Product(string name, double cost)
        {
            this.Name = name;
            this.Cost = cost;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (value == string.Empty || value == " ")
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                else
                {
                    name = value;
                }
            }
        }

        public double Cost
        {
            get { return cost; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Cost cannot be negative");
                }
                else
                {
                    cost = value;
                }
            }
        }
    }
}
