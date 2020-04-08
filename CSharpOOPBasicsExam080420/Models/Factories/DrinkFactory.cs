using SoftUniRestaurant.Models.Drinks;
using System;
using System.Linq;
using System.Reflection;

namespace SoftUniRestaurant.Models.Factories
{
    public class DrinkFactory
    {
        public Drink CreateDrink(string type, string name, int servingSize, string brand)
        {
            var productType = this.GetType()
                .Assembly
                .GetTypes()
                .FirstOrDefault(t => typeof(Drink).IsAssignableFrom(t) && !t.IsAbstract && t.Name == type);

            if (productType == null)
            {
                throw new InvalidOperationException("Invalid drink type!");
            }

            try
            {
                var drink = (Drink)Activator.CreateInstance(productType, name, servingSize, brand);
                return drink;
            }
            catch (TargetInvocationException e)
            {
                throw e.InnerException;
            }

        }
    }
}
