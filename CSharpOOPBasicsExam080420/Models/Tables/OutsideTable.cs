
namespace SoftUniRestaurant.Models.Tables
{
    public class OutsideTable : Table
    {
        public OutsideTable(int tableNumber, int capacity) : base(tableNumber, capacity, pricePerPerson: 3.50m)
        {
        }
    }
}
