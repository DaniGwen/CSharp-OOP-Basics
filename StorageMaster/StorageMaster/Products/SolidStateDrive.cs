namespace StorageMasterExam.Products
{
    public class SolidStateDrive : Product
    {
        public SolidStateDrive(double price) : base(price, weight: 02)
        {
            Price = price;
        }
    }
}
