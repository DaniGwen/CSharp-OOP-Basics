using StorageMaster.Vehicles;
using StorageMasterExam.Vehicles;
using System.Collections.Generic;

namespace StorageMasterExam.Storages
{
    public class Warehouse : Storage
    {
        private static readonly Vehicle[] DefaultVehicles =
        {
            new SemiTruck(),
            new SemiTruck(),
            new SemiTruck(),
        };

        public Warehouse(string name) : base(name, capacity: 10, garageSlots: 10, vehicles: DefaultVehicles)
        {
        }
    }
}
