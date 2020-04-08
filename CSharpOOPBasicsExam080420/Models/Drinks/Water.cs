
namespace SoftUniRestaurant.Models.Drinks
{
    public class Water : Drink
    {
        public Water(string name, int servingSize, string brand) : base(name, servingSize, price: 1.50m, brand)
        {
        }
    }
}
