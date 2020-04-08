using SoftUniRestaurant.Models.Foods.Contracts;
using System;

namespace SoftUniRestaurant.Models.Foods
{
    public abstract class Food : IFood
    {
        private string name;
        private int servingSize;
        private decimal price;

        public Food(string name, int servingSize, decimal price)
        {
            this.Name = name;
            this.ServingSize = servingSize;
            this.Price = price;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (value == " " || value == string.Empty)
                {
                    throw new ArgumentException("Name cannot be null or white space!");
                }
                else
                {
                    name = value;
                }
            }
        }

        public int ServingSize
        {
            get { return servingSize; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Serving size cannot be less or equal to zero");
                }
                else
                {
                    servingSize = value;
                }
            }
        }

        public decimal Price
        {
            get { return price; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Price cannot be less or equal to zero");
                }
                else
                {
                    price = value;
                }
            }
        }

        public override string ToString()
        {
            return $"{this.Name}: {this.ServingSize}g - {this.Price:f2}";
        }
    }
}
