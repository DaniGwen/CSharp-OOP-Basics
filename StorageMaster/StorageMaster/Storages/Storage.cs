using StorageMasterExam.Products;
using StorageMasterExam.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StorageMasterExam.Storages
{
    public abstract class Storage
    {
        private bool isFull;
        private readonly Vehicle[] garage;
        private readonly List<Product> products;


        public Storage(string name, int capacity, int garageSlots, IEnumerable<Vehicle> vehicles)
        {
            Name = name;
            Capacity = capacity;
            GarageSlots = garageSlots;
            InitializeGarage(vehicles);
        }

        public string Name { get; }

        public int Capacity { get; }

        protected int GarageSlots { get; }

        protected bool IsFull => products.Sum(p => p.Weight) >= Capacity;

        public IReadOnlyCollection<Vehicle> Garage => Array.AsReadOnly(garage);

        public IReadOnlyCollection<Product> Products => products.AsReadOnly();

        public Vehicle GetVehicle(int garageSlot)
        {
            if (garageSlot >= garage.Length)
            {
                throw new InvalidOperationException("Invalid garage slot!");
            }

            var vehicle = garage[garageSlot];

            if (vehicle == null)
            {
                throw new InvalidOperationException("No vehicle in this garage slot!");
            }

            return vehicle;
        }

        private void InitializeGarage(IEnumerable<Vehicle> vehicles)
        {
            var garageSlot = 0;
            foreach (var vehicle in vehicles)
            {
                garage[garageSlot++] = vehicle;
            }
        }

        public int SendVehicleTo(int garageSlot, Storage deliveryLocation)
        {
            var vehicle = GetVehicle(garageSlot);

            var freeSlot = deliveryLocation.Garage.Any(v => v == null);

            if (!freeSlot)
            {
                throw new InvalidOperationException("No room in garage!");
            }

            garage[garageSlot] = null;

            var deliverySlot = deliveryLocation.AddVehicle(vehicle);

            return deliverySlot;
        }

        private int AddVehicle(Vehicle vehicle)
        {
            var freeSlot = Array.IndexOf(garage, null);
            garage[freeSlot] = vehicle;

            return freeSlot;
        }

        public int UnloadVehicle(int garageSlot)
        {
            if (IsFull)
            {
                throw new InvalidOperationException("Storage is full!");
            }

            var vehicle = GetVehicle(garageSlot);
            var numberOfTransfers = 0;

            while (!IsFull || vehicle.Trunk.Any())
            {
                var productFromVehicle = vehicle.Trunk.First();
                products.Add(productFromVehicle);
                numberOfTransfers += 1;
            }

            return numberOfTransfers;
        }
    }
}
