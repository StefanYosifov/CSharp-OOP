namespace Vehicles
{
    using P01.Vehicles.Models;
    using System;
    using Vehicles.Engine;
    using Vehicles.Factory;

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
