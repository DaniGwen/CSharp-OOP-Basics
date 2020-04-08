using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Models.Foods
{
    public class Salad : Food
    {
        public Salad(string name, decimal price) : base(name, servingSize: 300, price)
        {
        }
    }
}
