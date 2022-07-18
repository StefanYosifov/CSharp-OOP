namespace Vehicles.Engine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Vehicles.Factory;
    using Vehicles.Models;
    using Vehicles.Models.Interfaces;

    public class EngineVehicle : IEngine
    {
        private readonly ICollection<Vehicle> vehicles;
        VehicleFactory factory = new VehicleFactory();
        private readonly Car car;
        private readonly Truck truck;

        public EngineVehicle()
        {
            vehicles = new List<Vehicle>();
        }

        public void Start()
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] cmdArgs = Console.ReadLine()
                    .Split();
                string action = cmdArgs[0];
                string vehicleType = cmdArgs[1];
                double distanceAmount = double.Parse(cmdArgs[2]);

                if (action == "Drive")
                {
                    if (vehicleType == "Car")
                    {
                        car.Drive(distanceAmount);
                    }
                    else if (vehicleType == "Truck")
                    {
                        truck.Drive(distanceAmount);
                    }
                }
                else if (action == "Refuel")
                {
                    if (vehicleType == "Car")
                    {
                        this.car.Refuel(distanceAmount);
                    }
                    else if (vehicleType == "Truck")
                    {
                        this.truck.Refuel(distanceAmount);
                    }
                }
            }

            Console.WriteLine(this.car);
            Console.WriteLine(this.truck);


        }

        private void AddToList(Vehicle vehicle, ICollection<Vehicle> vehicles)
        {
            if (vehicle != null)
            {
                vehicles.Add(vehicle);
            }
        }

    }


}
