using StorageMasterExam.Factories;
using StorageMasterExam.Products;
using StorageMasterExam.Storages;
using StorageMasterExam.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace StorageMasterExam.Core
{
    public class StorageMaster
    {
        private readonly Dictionary<string, Storage> storageRegistry;
        private readonly Dictionary<string, Stack<Product>> productsPool;

        private Vehicle CurrentVehicle;

        private readonly StorageFactory storageFactory;
        private readonly ProductFactory productFactory;

        public StorageMaster()
        {
            this.storageFactory = new StorageFactory();
            this.productFactory = new ProductFactory();

            this.storageRegistry = new Dictionary<string, Storage>();
            this.productsPool = new Dictionary<string, Stack<Product>>();
        }

        public string AddProduct(string type, double price)
        {
            if (!this.productsPool.ContainsKey(type))
            {
                this.productsPool[type] = new Stack<Product>();
            }

            var product = this.productFactory.CreateProduct(type, price);

            this.productsPool[type].Push(product);


            return $"Added {type} to pool";
        }

        public string RegisterStorage(string type, string name)
        {
            var storage = this.storageFactory.Createstorage(type, name);

            this.storageRegistry[storage.Name] = storage;

            return $"Registered {storage.Name}";
        }

        public string SelectVehicle(string storageName, int garageSlot)
        {
            var storage = this.storageRegistry[storageName];
            var vehicle = storage.GetVehicle(garageSlot);

            this.CurrentVehicle = vehicle;

            return $"Selected {vehicle.GetType().Name}";
        }

        public string LoadVehicle(IEnumerable<string> productNames)
        {
            var productCount = productNames.Count();
            var loadedProductsCount = 0;

            foreach (var product in productNames)
            {
                if (!this.productsPool.ContainsKey(product))
                {
                    throw new InvalidOperationException($"{product} is out of stock!");
                }

                var productFromPool = this.productsPool[product].Pop();

                this.CurrentVehicle.LoadProduct(productFromPool);

                loadedProductsCount += 1;
            }

            var result = loadedProductsCount / productCount;

            return $"Loaded {result} products into {this.CurrentVehicle}";
        }

        public string SendVehicleTo(string sourceName, int sourceGarageSlot, string destinationName)
        {
            if (!this.storageRegistry.ContainsKey(sourceName))
            {
                throw new InvalidOperationException("Invalid source storage!");
            }

            if (!this.storageRegistry.ContainsKey(destinationName))
            {
                throw new InvalidOperationException("Invalid destination storage!");
            }

            var sourceStorage = this.storageRegistry[sourceName];
            var destinationStorage = this.storageRegistry[destinationName];

            var vehicle = sourceStorage.GetVehicle(sourceGarageSlot);

            var destinationGarageSlot = sourceStorage.SendVehicleTo(sourceGarageSlot, destinationStorage);

            return $"Sent {vehicle.GetType().Name} to {destinationStorage.Name} (slot {destinationGarageSlot})";
        }

        public string UnloadVehicle(string storageName, int garageSlot)
        {
            var storage = this.storageRegistry[storageName];
            var vehicle = storage.GetVehicle(garageSlot);

            var productsInVehicle = vehicle.Trunk.Count;
            var unloadedProductsCount = storage.UnloadVehicle(garageSlot);

            return $"Unloaded {unloadedProductsCount}/{productsInVehicle} products at {storage.Name}";
        }

        public string GetStorageStatus(string storageName)
        {
            var storage = this.storageRegistry[storageName];

            var sortedStorage = storage.Products.GroupBy(p => p.GetType().Name)
                .Select(p => new
                {
                    Name = p.Key,
                    Count = p.Count()
                })
                .OrderByDescending(p => p.Count)
                .ThenBy(p => p.GetType().Name)
                .Select(p => $"{p.Name} ({p.Count})")
                .ToArray();

            var productsWeight = storage.Products.Sum(p => p.Weight);

            var stockFormat = string.Format($"Stock ({0}/{1}): [{2}]",
                productsWeight,
                storage.Capacity,
                string.Join(',', sortedStorage));

            var garage = storage.Garage.ToArray();

            var vehicleNames = garage.Select(vehicle => vehicle?.GetType().Name ?? "empty").ToArray();

            var garageFormat = string.Format("Garage: [{0}]", string.Join('|', vehicleNames));

            return stockFormat + Environment.NewLine + garageFormat;
        }

        public string GetSummary()
        {
            var storagesOrdered = this.storageRegistry.Values.OrderByDescending(s => s.Products.Sum(p => p.Price))
                 .Select(s => new
                 {
                     Name = s.Name,
                     TotalMoney = s.Products.Sum(p => p.Price)
                 })
                 .Select(p => $"{p.Name}:" + Environment.NewLine + $"Storage worth: ${p.TotalMoney:f2}")
                 .ToArray();

            return string.Join(Environment.NewLine, storagesOrdered);
        }
    }
}
