using StorageMasterExam.Products;
using System;
using System.Linq;
using System.Reflection;

namespace StorageMasterExam.Factories
{
    public class ProductFactory
    {
        public Product CreateProduct(string type, double price)
        {
            var productType = this.GetType()
                .Assembly
                .GetTypes()
                .FirstOrDefault(t => typeof(Product).IsAssignableFrom(t) && !t.IsAbstract && t.Name == type);

            if (productType == null)
            {
                throw new InvalidOperationException("Invalid product type!");
            }

            try
            {
                var product = (Product)Activator.CreateInstance(productType, price);
                return product;
            }
            catch (TargetInvocationException exception)
            {
                throw exception.InnerException;
            }
        }
    }
}
