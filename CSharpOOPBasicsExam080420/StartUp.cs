using SoftUniRestaurant.Core;
using System.Globalization;

namespace SoftUniRestaurant
{
    public class StartUp
    {
        public static void Main()
        {
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;

            var controller = new RestaurantController();

            var engine = new Engine(controller);

            engine.Run();
        }
    }
}
