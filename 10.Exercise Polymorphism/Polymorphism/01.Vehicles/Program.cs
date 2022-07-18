namespace Vehicles
{
    using System;
    using Vehicles.Engine;
    using Vehicles.Factory;
    using Vehicles.Models;
    using Vehicles.Models.Interfaces;

    public class StartUp
    {
        static void Main(string[] args)
        {

            string[] carData = Console.ReadLine()
                   .Split();
            string[] truckData = Console.ReadLine()
                .Split();

            IFactoryVehicle vehicleFactory = new VehicleFactory();
            Vehicle car = vehicleFactory.CreateVehicle(truckData[0], double.Parse(truckData[1]), double.Parse(truckData[2]));
            Vehicle truck = vehicleFactory.CreateVehicle(truckData[0], double.Parse(truckData[1]), double.Parse(truckData[2]));

            IEngine engine = new EngineVehicle();
            engine.Start(); //Starts business logic

        }
    }
}
