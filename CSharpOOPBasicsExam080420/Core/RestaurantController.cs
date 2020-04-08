namespace SoftUniRestaurant.Core
{
    using SoftUniRestaurant.Models.Drinks;
    using SoftUniRestaurant.Models.Factories;
    using SoftUniRestaurant.Models.Foods;
    using SoftUniRestaurant.Models.Tables;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class RestaurantController
    {
        private readonly Dictionary<string, List<Food>> menu;
        private readonly Dictionary<string, List<Drink>> drinks;
        private readonly Dictionary<string, List<Table>> tables;

        private readonly FoodFactory foodFactory;
        private readonly DrinkFactory drinkFactory;
        private readonly TableFactory tableFactory;

        public RestaurantController()
        {
            this.menu = new Dictionary<string, List<Food>>();
            this.drinks = new Dictionary<string, List<Drink>>();
            this.tables = new Dictionary<string, List<Table>>();

            this.foodFactory = new FoodFactory();
            this.drinkFactory = new DrinkFactory();
            this.tableFactory = new TableFactory();
        }

        public string AddFood(string type, string name, decimal price)
        {
            if (!this.menu.ContainsKey(type))
            {
                this.menu[type] = new List<Food>();
            }

            var food = this.foodFactory.CreateFood(type, name, price);

            this.menu[type].Add(food);

            return $"Added {food.Name} ({food.GetType().Name}) with price { food.Price:f2} to the pool";
        }

        public string AddDrink(string type, string name, int servingSize, string brand)
        {
            if (!this.drinks.ContainsKey(type))
            {
                this.drinks[type] = new List<Drink>();
            }

            var drink = this.drinkFactory.CreateDrink(type, name, servingSize, brand);

            this.drinks[type].Add(drink);

            return $"Added {drink.Name} ({drink.Brand}) to the drink pool";
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            if (!this.tables.ContainsKey(type))
            {
                this.tables[type] = new List<Table>();
            }

            var table = this.tableFactory.CreateTable(type, tableNumber, capacity);

            this.tables[type].Add(table);

            return $"Added table number {table.TableNumber} in the restaurant";
        }

        public string ReserveTable(int numberOfPeople)
        {
            var result = string.Empty;

            foreach (var tables in this.tables.Values)
            {
                foreach (var table in tables)
                {
                    if (table.IsReserved == false && table.Capacity >= numberOfPeople)
                    {
                        table.IsReserved = true;
                        result = $"Table {table.TableNumber} has been reserved for {numberOfPeople} people";
                    }
                    else
                    {
                        result = $"No available table for {numberOfPeople} people";
                    }
                }
            }

            return result;
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            if (!this.tables.Any(list => list.Value.Any(table => table.TableNumber == tableNumber)))
            {
                return $"Could not find table with {tableNumber}";
            }

            if (!this.menu.Any(list => list.Value.Any(food => food.Name == foodName)))
            {
                return $"No {foodName} in the menu";
            }

            foreach (var listTables in this.tables)
            {
                var table = listTables.Value.FirstOrDefault(t => t.TableNumber == tableNumber);

                foreach (var listFoods in this.menu)
                {
                    var food = listFoods.Value.FirstOrDefault(f => f.Name == foodName);
                    table.OrderFood(food);
                    return $"Table {tableNumber} ordered {foodName}";
                }
            }

            return "";
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            if (!this.tables.Any(list => list.Value.Any(table => table.TableNumber == tableNumber)))
            {
                return $"Could not find table with {tableNumber}";
            }

            if (!this.drinks.Any(list => list.Value.Any(drink => drink.Name == drinkName)))
            {
                return $"There is no {drinkName} {drinkBrand} available";
            }

            foreach (var listTables in this.tables)
            {
                var table = listTables.Value.FirstOrDefault(t => t.TableNumber == tableNumber);

                foreach (var listDrinks in this.drinks)
                {
                    var drink = listDrinks.Value.FirstOrDefault(d => d.Name == drinkName);
                    table.OrderDrink(drink);
                    return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
                }
            }
            return "";
        }

        public string LeaveTable(int tableNumber)
        {
            var bill = 0m;

            foreach (var listTables in this.tables)
            {
                if (this.tables.Any(list => list.Value.Any(table => table.TableNumber == tableNumber)))
                {
                    var table = listTables.Value.FirstOrDefault(t => t.TableNumber == tableNumber);

                    bill = table.GetBill();
                    table.Clear();
                    break;
                }
            }

            return string.Format("Table: {0}" + Environment.NewLine + "Bill: {1:f2}", tableNumber, bill).TrimEnd(Environment.NewLine.ToCharArray());
        }

        public string GetFreeTablesInfo()
        {
            var sb = new StringBuilder();

            foreach (var tableList in this.tables)
            {
                foreach (var table in tableList.Value)
                {
                    if (table.IsReserved == false)
                    {
                        sb.AppendLine(table.GetFreeTableInfo());
                    }
                }
            }

            return sb.ToString().TrimEnd(Environment.NewLine.ToCharArray());
        }

        public string GetOccupiedTablesInfo()
        {
            var sb = new StringBuilder();

            foreach (var tableList in this.tables)
            {
                foreach (var table in tableList.Value)
                {
                    if (table.IsReserved == true)
                    {
                        sb.AppendLine(table.GetOccupiedTableInfo());
                    }
                }
            }

            return sb.ToString().TrimEnd(Environment.NewLine.ToCharArray());
        }

        public string GetSummary()
        {
            var totalIncome = 0m;

            foreach (var tableList in this.tables)
            {
                foreach (var table in tableList.Value)
                {
                    if (table.IsReserved == true)
                    {
                        totalIncome += table.GetBill();
                    }
                }
            }

            return $"Total income: {totalIncome:f2}lv";
        }
    }
}
