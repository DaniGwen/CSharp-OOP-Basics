using System;
using System.Linq;

namespace SoftUniRestaurant.Core
{
    public class Engine
    {
        private readonly RestaurantController restaurantController;

        public Engine(RestaurantController restaurantController)
        {
            this.restaurantController = restaurantController;
        }

        public void Run()
        {
            while (true)
            {
                var command = Console.ReadLine();
                if (command == "END")
                {
                    break;
                }

                try
                {
                    var commandResult = this.ProcessCommand(command);
                    Console.WriteLine(commandResult);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
            }
            var summary = this.restaurantController.GetSummary();
            Console.WriteLine(summary);
        }

        private string ProcessCommand(string command)
        {
            var commandArgs = command.Split(' ');
            var commandName = commandArgs[0];
            var args = commandArgs.Skip(1).ToArray();

            var output = string.Empty;

            switch (commandName)
            {
                case "AddFood":
                    {
                        var type = args[0];
                        var name = args[1];
                        var price = decimal.Parse(args[2]);

                        output = this.restaurantController.AddFood(type, name, price);
                        break;
                    }
                case "AddDrink":
                    {
                        var type = args[0];
                        var name = args[1];
                        var servingSize = int.Parse(args[2]);
                        var brand = args[3];

                        output = this.restaurantController.AddDrink(type, name, servingSize, brand);
                        break;
                    }
                case "AddTable":
                    {
                        var type = args[0];
                        var tableNumber = int.Parse(args[1]);
                        var capacity = int.Parse(args[2]);

                        output = this.restaurantController.AddTable(type, tableNumber, capacity);
                        break;
                    }
                case "ReserveTable":
                    {
                        var numberOfPeople = int.Parse(args[0]);

                        output = this.restaurantController.ReserveTable(numberOfPeople);
                        break;
                    }
                case "OrderFood":
                    {
                        var tableNumber = int.Parse(args[0]);
                        var foodName = args[1];

                        output = this.restaurantController.OrderFood(tableNumber, foodName);
                        break;
                    }
                case "OrderDrink":
                    {
                        var tableNumber = int.Parse(args[0]);
                        var drinkName = args[1];
                        var drinkBrand = args[2];

                        output = this.restaurantController.OrderDrink(tableNumber, drinkName, drinkBrand);
                        break;
                    }
                case "LeaveTable":
                    {
                        var tableNumber = int.Parse(args[0]);

                        output = this.restaurantController.LeaveTable(tableNumber);
                        break;
                    }
                case "GetFreeTablesInfo":
                    Console.Write(this.restaurantController.GetFreeTablesInfo());
                    break;
                case "GetOccupiedTablesInfo":
                    Console.Write(this.restaurantController.GetOccupiedTablesInfo());
                    break;
            }

            return output;
        }
    }
}
