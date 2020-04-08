using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Models.Foods
{
    public class MainCourse : Food
    {
        public MainCourse(string name, decimal price) : base(name, servingSize: 500, price)
        {
        }
    }
}
