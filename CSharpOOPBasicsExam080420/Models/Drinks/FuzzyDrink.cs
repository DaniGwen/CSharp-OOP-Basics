namespace SoftUniRestaurant.Models.Drinks
{
    public class FuzzyDrink : Drink
    {
        public FuzzyDrink(string name, int servingSize, string brand) : base(name, servingSize, price: 2.50m, brand)
        {
        }
    }
}
