using StorageMasterExam.Products;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace StorageMasterExam.Vehicles
{
    public abstract class Vehicle
    {
        private int capacity;
        public IReadOnlyCollection<Product> Trunk;
        private bool isFull;
        private bool isEmpty;
        private List<Product> Products;

        public Vehicle(int capacity)
        {
            Capacity = capacity;
            Products = new List<Product>();
        }

        protected int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }

        public bool IsFull
        {
            get { return isFull; }
            private set
            {
                if (Trunk.Sum(p => p.Weight) >= Capacity)
                {
                    isFull = true;
                }
                else
                {
                    isFull = false;
                }
            }
        }

        protected bool IsEmpty
        {
            get { return isEmpty; }
            set
            {
                if (!Trunk.Any())
                {
                    isEmpty = true;
                }
                else
                {
                    isEmpty = false;
                }
            }
        }

        public void LoadProduct(Product product)
        {
            if (IsFull)
            {
                throw new Exception("Vehicle is full!");
            }

            Products.Add(product);
            Trunk = new ReadOnlyCollection<Product>(Products);
        }

        public Product Unload()
        {
            if (IsEmpty)
            {
                throw new Exception("No products left in vehicle!");
            }

            var elementToRemove = Trunk.Last();
            Products.RemoveAt(Products.Count - 1);
            Trunk = new ReadOnlyCollection<Product>(Products);

            return elementToRemove;
        }
    }
}
