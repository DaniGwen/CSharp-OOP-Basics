using SoftUniRestaurant.Models.Drinks;
using SoftUniRestaurant.Models.Drinks.Contracts;
using SoftUniRestaurant.Models.Foods;
using SoftUniRestaurant.Models.Foods.Contracts;
using SoftUniRestaurant.Models.Tables.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniRestaurant.Models.Tables
{
    public class Table : ITable
    {
        private int capacity;

        private int numberOfPeople;

        private decimal price;

        private ICollection<Food> FoodOrders;

        private ICollection<Drink> DrinkOrders { get; set; }

        public int TableNumber { get; private set; }

        public decimal PricePerPerson { get; private set; }

        public bool IsReserved { get; set; }

        public Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            this.TableNumber = tableNumber;
            this.Capacity = capacity;
            this.PricePerPerson = pricePerPerson;

            this.FoodOrders = new List<Food>();
            this.DrinkOrders = new List<Drink>();
        }

        public int Capacity
        {
            get { return capacity; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Capacity has to be greater than 0");
                }
                else
                {
                    capacity = value;
                }
            }
        }

        public int NumberOfPeople
        {
            get { return numberOfPeople; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Cannot place zero or less people!");
                }
                else
                {
                    numberOfPeople = value;
                }
            }
        }

        public decimal Price
        {
            get { return price; }
            private set
            {
                price = this.PricePerPerson * this.NumberOfPeople;
            }
        }

        public void Reserve(int numberOfPeople)
        {
            this.IsReserved = true;
            this.NumberOfPeople = numberOfPeople;
        }

        public void OrderFood(IFood food)
        {
            var productType = this.GetType()
                .Assembly
                .GetTypes()
                .FirstOrDefault(t => typeof(Food).IsAssignableFrom(t) && !t.IsAbstract && t.Name == food.GetType().Name);

            if (productType == null)
            {
                throw new InvalidOperationException("Invalid food type!");
            }

            try
            {
                var foodInstance = (Food)Activator.CreateInstance(productType, food.Name, food.Price);
                this.FoodOrders.Add(foodInstance);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

               
        }

        public void OrderDrink(IDrink drink)
        {
            this.DrinkOrders.Add((Drink)drink);
        }

        public decimal GetBill()
        {
            var totalPriceDrink = this.DrinkOrders.Sum(d => d.Price);
            var totalPriceFood = this.FoodOrders.Sum(f => f.Price);

            return totalPriceDrink + totalPriceFood;
        }

        public void Clear()
        {
            this.DrinkOrders.Clear();
            this.FoodOrders.Clear();
            this.NumberOfPeople = default(int);
        }

        public string GetFreeTableInfo()
        {
            var sb = new StringBuilder();

            return sb.AppendLine($"Table: {this.TableNumber}")
                 .AppendLine($"Type: {this.GetType().Name}")
                 .AppendLine($"Capacity: {this.Capacity}")
                 .AppendLine($"Price per Person: {this.PricePerPerson}")
                 .ToString().TrimEnd(Environment.NewLine.ToCharArray());
        }

        public string GetOccupiedTableInfo()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Table: {this.TableNumber}")
                 .AppendLine($"Type: {this.GetType().Name}")
                 .AppendLine($"Capacity: {this.Capacity}")
                 .AppendLine($"Number of people: {this.NumberOfPeople}").ToString().TrimEnd(Environment.NewLine.ToCharArray());
            if (!this.FoodOrders.Any())
            {
                sb.AppendLine($"Food orders: None");
            }
            else
            {
                sb.AppendLine($"Food orders: {this.FoodOrders.Count}");

                foreach (var food in this.FoodOrders)
                {
                    sb.AppendLine(food.ToString());
                }
            }

            if (!this.DrinkOrders.Any())
            {
                sb.AppendLine("Drink orders: None");
            }
            else
            {
                sb.AppendLine($"Drink orders: {this.DrinkOrders.Count}");

                foreach (var drink in this.DrinkOrders)
                {
                    sb.AppendLine(drink.ToString());
                }
            }

            return sb.ToString().TrimEnd(Environment.NewLine.ToCharArray());
        }
    }
}
