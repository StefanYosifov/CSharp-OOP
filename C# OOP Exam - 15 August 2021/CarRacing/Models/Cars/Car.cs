namespace CarRacing.Models.Cars
{
    using CarRacing.Models.Cars.Contracts;
    using CarRacing.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Car : ICar
    {
        private const int VINMustHaveLenght = 17;

        public Car(string make, string model, string vIN, int horsePower, double fuelAvailable, double fuelConsumptionPerRace)
        {
            this.Make = make;
            this.Model = model;
            this.VIN = vIN;
            this.HorsePower = horsePower;
            this.FuelAvailable = fuelAvailable;
            this.FuelConsumptionPerRace = fuelConsumptionPerRace;
        }

        private string make;
        private string model;
        private string vin;
        private int horsepower;
        private double fuelAvailable;
        private double fuelConsumptionPrice;


        public string Make
        {
            get
            {
                return this.make;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCarMake);
                }
                this.make = value;
            }
        }

        public string Model
        {
            get
            {
                return this.model;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCarModel);
                }
                this.model = value;
            }
        }

        public string VIN
        {
            get
            {
                return this.vin;
            }
            private set
            {
                if (value.Length!=VINMustHaveLenght)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCarVIN);
                }
                this.vin = value;
            }
        }

        public int HorsePower
        {
            get
            {
                return this.horsepower;
            }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCarHorsePower);
                }
                this.horsepower = value;
            }
        }

        public double FuelAvailable
        {
            get
            {
                return this.fuelAvailable;
            }
            protected set
            {
                if (value < 0)
                {
                    this.fuelAvailable = 0;
                }
                this.fuelAvailable = value;
            }
        }

        public double FuelConsumptionPerRace
        {
            get
            {
                return this.fuelConsumptionPrice;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCarFuelConsumption);
                }
                this.fuelConsumptionPrice = value;
            }
        }

        public virtual void Drive()
        {
            this.FuelAvailable -= FuelConsumptionPerRace;
        }
    }
}
