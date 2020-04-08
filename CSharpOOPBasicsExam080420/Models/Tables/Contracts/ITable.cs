using SoftUniRestaurant.Models.Drinks;
using SoftUniRestaurant.Models.Drinks.Contracts;
using SoftUniRestaurant.Models.Foods;
using SoftUniRestaurant.Models.Foods.Contracts;
using System.Collections.Generic;

namespace SoftUniRestaurant.Models.Tables.Contracts
{
    public interface ITable
    {
        //ICollection<Food> FoodOrders { get; }

        //ICollection<Drink> DrinkOrders { get; }

        int TableNumber { get;  }

        int Capacity { get; }

        int NumberOfPeople { get; }

        decimal PricePerPerson { get; }

        bool IsReserved { get; }

        decimal Price { get; }

        void Reserve(int numberOfPeople);

        void OrderFood(IFood food);

        void OrderDrink(IDrink drink);

        decimal GetBill();

        void Clear();

        string GetFreeTableInfo();

    }
}
