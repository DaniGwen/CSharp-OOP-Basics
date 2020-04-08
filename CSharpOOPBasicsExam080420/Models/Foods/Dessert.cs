using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Models.Foods
{
    public class Dessert : Food
    {
        public Dessert(string name, decimal price) : base(name, servingSize: 200, price)
        {
        }
    }
}
