using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Models.Foods
{
    public class Soup : Food
    {
        public Soup(string name, decimal price) : base(name, servingSize: 245, price)
        {
        }
    }
}
