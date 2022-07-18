namespace Vehicles.Factory
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Vehicles.Models;

    public interface IFactoryVehicle
    {

        Vehicle CreateVehicle(string vehicleType, double fuelQuantity, double fuelConsumption);
        

    }
}
