namespace StorageMasterExam.Products
{
    public class Gpu : Product
    {
        public Gpu(double price) : base(price, weight: 0.7)
        {
            Price = price;
        }
    }
}
