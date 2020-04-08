
namespace SoftUniRestaurant.Models.Drinks
{
    public class Juice : Drink
    {
        public Juice(string name, int servingSize, string brand) : base(name, servingSize, price: 1.80m, brand)
        {
        }
    }
}
