using SoftUniRestaurant.Models.Foods;
using System;
using System.Linq;
using System.Reflection;

namespace SoftUniRestaurant.Models.Factories
{
    public class FoodFactory
    {
        public Food CreateFood(string type, string name, decimal price)
        {
            //var productType = this.GetType()
            //    .Assembly
            //    .GetTypes()
            //    .FirstOrDefault(t => typeof(Food).IsAssignableFrom(t) && !t.IsAbstract && t.Name == type);

            //if (productType == null)
            //{
            //    throw new InvalidOperationException("Invalid food type!");
            //}

            //try
            //{
            //    var food = (Food)Activator.CreateInstance(productType, name, price);
            //    return food;
            //}
            //catch (TargetInvocationException e)
            //{
            //    throw e.InnerException;
            //}

            switch (type)
            {
                case "Dessert":
                    var dessert = new Dessert(name, price);
                    return dessert;
                case "MainCourse":
                    var mainCourse = new MainCourse(name, price);
                    return mainCourse;
                case "Salad":
                    var salad = new Salad(name, price);
                    return salad;
                case "Soup":
                    var soup = new Soup(name, price);
                    return soup;
            }

            return null;
        }
    }
}
