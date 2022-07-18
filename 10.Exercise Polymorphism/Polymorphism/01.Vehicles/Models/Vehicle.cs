namespace Vehicles.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Vehicles.Models.Interfaces;

    public abstract class Vehicle : IVehicle
    {

        public Vehicle(double fuelQuantity,double fuelConsumption)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity {get;protected set; }

        public virtual double FuelConsumption { get; protected set; }

        public abstract void Drive(double distance);
        public abstract void Refuel(double fuel);
    }
}
