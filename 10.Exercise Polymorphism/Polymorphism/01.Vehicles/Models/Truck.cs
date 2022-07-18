namespace Vehicles.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Vehicles.Models.Interfaces;

    public class Truck : Vehicle
    {
        private const double SummerIncreaseInFuelConsumpion = 1.6;
        private const double InEfficientRefueling = 0.95;

        public Truck(double fuelQuantity, double fuelConsumption) : base(fuelQuantity, fuelConsumption)
        {

        }


        public override double FuelConsumption
        {
            get
            {
                return base.FuelConsumption;
            }
            protected set
            {
                base.FuelConsumption = value+SummerIncreaseInFuelConsumpion;
            }
        }

        public override void Drive(double distance)
        {
            double truckFuel = distance * FuelConsumption;
            if (distance > truckFuel)
            {
                Console.WriteLine($"{GetType().Name} needs refueling");
            }
            else
            {
                Console.WriteLine($"{GetType().Name} travelled {distance} km");
                base.FuelQuantity -= truckFuel;
            }

        }


        public override void Refuel(double fuel)
        {
            this.FuelQuantity += fuel * InEfficientRefueling;
        }
    }
}
