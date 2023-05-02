namespace Vehicles.Factory
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Vehicles.Models;

    public class VehicleFactory : IFactoryVehicle
    {
        public Vehicle CreateVehicle(string vehicleType, double fuelQuantity, double fuelConsumption)
        {
            Vehicle vehicle = null;
            if (vehicleType == "Car")
            {
                vehicle = new Car(fuelQuantity, fuelConsumption);
            }
            else if (vehicleType == "Truck")
            {
                vehicle = new Truck(fuelQuantity, fuelConsumption);
            }
            return vehicle;
        }
    }
}
