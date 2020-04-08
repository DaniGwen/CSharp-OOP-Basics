using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMasterExam.Products
{
    public class Ram : Product
    {
        public Ram(double price) : base(price, weight: 0.1)
        {
            Price = price;
        }
    }
}
