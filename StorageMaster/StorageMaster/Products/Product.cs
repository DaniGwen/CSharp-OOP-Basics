using System;
namespace StorageMasterExam.Products
{
    public abstract class Product
    {
        private double price;
        private double weight;

        public Product(double price, double weight)
        {
            Price = price;
            Weight = weight;
        }

        internal double Price
        {
            get { return price; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Price cannot be negative!");
                }
                else
                {
                    price = value;
                }
            }
        }

        internal double Weight
        {
            get { return weight; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Weight cannot be negative!");
                }
                else
                {
                    weight = value;
                }
            }
        }

    }
}
