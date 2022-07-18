namespace Vehicles.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Vehicles.Models.Interfaces;

    public class Car : Vehicle
    {
        private double SummerIncreaseInFuelConsumpion = 0.9;

        public Car(double fuelQuantity, double fuelConsumption) : base(fuelQuantity, fuelConsumption)
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
            double carFuel = distance * FuelConsumption;
            if (distance > carFuel)
            {
                Console.WriteLine($"{GetType().Name} needs refueling");
            }
            else
            {
                Console.WriteLine($"{GetType().Name} travelled {distance} km");
                base.FuelQuantity -= carFuel;
            }
        }

        public override void Refuel(double fuel)
        {
            FuelConsumption += fuel;
        }
    }
}
