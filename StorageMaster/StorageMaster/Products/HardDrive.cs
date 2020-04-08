using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMasterExam.Products
{
    public class HardDrive : Product
    {
        public HardDrive(double price) : base(price, weight: 1)
        {
            Price = price;
        }
    }
}
