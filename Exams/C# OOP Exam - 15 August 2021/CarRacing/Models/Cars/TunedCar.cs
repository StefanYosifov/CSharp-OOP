namespace CarRacing.Models.Cars
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class TunedCar : Car
    {

        private const double StartWithAvailableFuel = 65;
        private const double StartWithFuelConsumpion = 10;
        private const double CoefficientHPReduction = 0.97;
        public TunedCar(string make, string model, string vIN, int horsePower)
            : base(make, model, vIN, horsePower, StartWithAvailableFuel, StartWithFuelConsumpion)
        {
        }


        public override void Drive()
        {

            base.FuelAvailable -= base.FuelConsumptionPerRace;
            base.HorsePower = (int)(HorsePower * CoefficientHPReduction);

        }
    }
}
