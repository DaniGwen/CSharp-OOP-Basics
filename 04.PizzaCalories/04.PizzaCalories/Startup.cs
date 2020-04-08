using System;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace _04.PizzaCalories
{
    class Startup
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            var pizzaNameInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Skip(1).First();
            var doughInput = Console.ReadLine();
            var input = Console.ReadLine();

            var pizza = new Pizza(pizzaNameInput);

            try
            {
                var pizzaDough = ParseDough(doughInput);
                pizza.Dough = pizzaDough;

                while (input != "END")
                {
                    var command = input.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                        .First()
                        .ToLower();

                    if (command != "topping")
                    {
                        throw new ArgumentException("Wrong command!");
                    }

                    var arguments = input
                      .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                      .Skip(1)
                      .Select(a => a.ToLower())
                      .ToArray();

                    var toppingType = arguments[0]
                        .First()
                        .ToString()
                        .ToUpper() + arguments[0].Substring(1);

                    var toppingWeight = double.Parse(arguments[1]);

                    var topping = new Topping(toppingWeight, toppingType);

                    pizza.AddTopping(topping);

                    input = Console.ReadLine();
                }

                if (pizza.NumberOfToppings > 10)
                {
                    Console.WriteLine("Number of toppings should be in range [0..10].");
                }
                else
                {
                    Console.WriteLine($"{pizza.Name} - {pizza.Calories:f2} Calories.");
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

        }

        private static Dough ParseDough(string input)
        {
            var command = input.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                       .First()
                       .ToLower();

            if (command != "dough")
            {
                throw new ArgumentException("Wrong command!");
            }

            var doughArgs = input
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Skip(1)
                .Select(a => a.ToLower())
                .ToArray();

            var bakingTechnique = doughArgs[1]
                .First()
                .ToString()
                .ToUpper() + doughArgs[1].Substring(1);

            var doughWeight = double.Parse(doughArgs[2]);

            var flourType = doughArgs[0]
                .First()
                .ToString()
                .ToUpper() + doughArgs[0].Substring(1);

            return new Dough(flourType, bakingTechnique, doughWeight);
        }
    }
}
