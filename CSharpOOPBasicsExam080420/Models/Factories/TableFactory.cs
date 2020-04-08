using SoftUniRestaurant.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SoftUniRestaurant.Models.Factories
{
    public class TableFactory
    {
        public Table CreateTable(string type, int tableNumber, int capacity)
        {
            var tableName = type + "Table";

            var productType = this.GetType()
                .Assembly
                .GetTypes()
                .FirstOrDefault(t => typeof(Table).IsAssignableFrom(t) && !t.IsAbstract && t.Name == tableName);

            if (productType == null)
            {
                throw new InvalidOperationException("Invalid table type!");
            }

            try
            {
                var table = (Table)Activator.CreateInstance(productType, tableNumber,capacity);
                return table;
            }
            catch (TargetInvocationException e)
            {
                throw e.InnerException;
            }

        }
    }
}
