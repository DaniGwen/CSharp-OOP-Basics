
using System;
using System.Collections.Generic;

namespace Problem_3._Shopping_Spree
{
    public class Person
    {
        private string name;
        private double money;
        public readonly List<Product> Products;

        public Person(string name, double money)
        {
            this.Name = name;
            this.Money = money;
            this.Products = new List<Product>();
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

        public double Money
        {
            get { return money; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                else
                {
                    money = value;
                }
            }
        }

        public void AddProduct(Product product)
        {
            this.Products.Add(product);
        }

        public void SpendMoney(double productCost)
        {
            this.Money -= productCost;
        }
    }
}
