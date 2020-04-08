namespace SoftUniRestaurant.Models.Tables
{
    public class InsideTable : Table
    {
        public InsideTable(int tableNumber, int capacity) : base(tableNumber, capacity, pricePerPerson: 2.50m)
        {
        }
    }
}
