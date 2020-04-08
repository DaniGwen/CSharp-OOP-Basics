using StorageMasterExam.Vehicles;
using System.Collections.Generic;

namespace StorageMasterExam.Storages
{
    public class AutomatedWarehouse : Storage
    {
        private static readonly Vehicle[] DefaultVehicles =
        {
            new Truck(),
        };

        public AutomatedWarehouse(string name) : base(name, capacity: 1, garageSlots: 2, vehicles: DefaultVehicles)
        {
        }
    }
}
