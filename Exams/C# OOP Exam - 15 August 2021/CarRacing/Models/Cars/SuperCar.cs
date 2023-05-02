namespace CarRacing.Models.Cars
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class SuperCar : Car
    {
        private const double StartWithAvailableFuel = 80;
        private const double StartWithFuelConsumpion = 10;
        public SuperCar(string make, string model, string vIN, int horsePower) 
            : base(make, model, vIN, horsePower, StartWithAvailableFuel, StartWithFuelConsumpion)
        {
        }


    }
}
