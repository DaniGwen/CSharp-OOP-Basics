using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem_3._Shopping_Spree
{
    class Startup
    {
        static void Main()
        {
            var personInput = Console.ReadLine().Trim(' ', ';').Split(";").ToArray();
            var productInput = Console.ReadLine().Trim(' ', ';').Split(";").ToArray();

            try
            {
                var listCustomers = GetPeople(personInput);
                var listProducts = GetProducts(productInput);

                var input = Console.ReadLine();

                while (input != "END")
                {
                    var inputArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                    var customer = listCustomers.FirstOrDefault(c => c.Name == inputArgs.First());
                    var product = listProducts.FirstOrDefault(p => p.Name == inputArgs.Last());

                    if (customer.Money < product.Cost)
                    {
                        Console.WriteLine($"{customer.Name} can't afford {product.Name}");
                    }
                    else
                    {
                        Console.WriteLine($"{ customer.Name} bought { product.Name}");
                        customer.AddProduct(product);
                        customer.SpendMoney(product.Cost);
                    }

                    input = Console.ReadLine();
                }

                foreach (var customer in listCustomers)
                {
                    if (customer.Products.Count != 0)
                    {
                        var sb = new StringBuilder();

                        foreach (var product in customer.Products)
                        {
                            sb.Append(product.Name + ", ");
                        }
                        Console.WriteLine($"{customer.Name} - {sb.ToString().TrimEnd(',',' ')}");
                    }
                    else
                    {
                        Console.WriteLine($"{customer.Name} - Nothing bought");
                    }

                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        public static List<Person> GetPeople(string[] personInput)
        {
            var listCustomers = new List<Person>();

            foreach (var personArgs in personInput)
            {
                var personName = personArgs.Split('=').First();
                var personMoney = double.Parse(personArgs.Split('=').Last());

                var person = new Person(personName, personMoney);

                listCustomers.Add(person);
            }

            return listCustomers;
        }

        public static List<Product> GetProducts(string[] productInput)
        {
            var listProducts = new List<Product>();

            foreach (var productArgs in productInput)
            {
                var productName = productArgs.Split('=').First();
                var productCost = double.Parse(productArgs.Split('=').Last());

                var product = new Product(productName, productCost);

                listProducts.Add(product);
            }

            return listProducts;
        }
    }
}
