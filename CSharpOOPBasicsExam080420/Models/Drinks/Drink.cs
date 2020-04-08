using SoftUniRestaurant.Models.Drinks.Contracts;
using System;

namespace SoftUniRestaurant.Models.Drinks
{
    public abstract class Drink : IDrink
    {
        private string name;
        private int servingSize;
        private decimal price;
        private string brand;

        public Drink(string name, int servingSize, decimal price, string brand)
        {
            this.Name = name;
            this.ServingSize = servingSize;
            this.Price = price;
            this.Brand = brand;
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

        public string Brand
        {
            get { return brand; }
            private set
            {
                if (value == " " || value == string.Empty)
                {
                    throw new ArgumentException("Brand cannot be null or white space!");
                }
                else
                {
                    brand = value;
                }
            }
        }

        public override string ToString()
        {
            return $"{this.Name} {this.Brand} - {this.ServingSize}ml - {this.Price:f2}lv";
        }
    }
}
