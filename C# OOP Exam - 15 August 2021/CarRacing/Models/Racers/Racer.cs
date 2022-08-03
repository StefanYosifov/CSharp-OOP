namespace CarRacing.Models.Racers
{
    using CarRacing.Models.Cars.Contracts;
    using CarRacing.Models.Racers.Contracts;
    using CarRacing.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Racer : IRacer
    {




        private string username;
        private string racingBehavior;
        private int drivingExperience;
        private ICar car;

        public Racer(string username, string racingBehavior, int drivingExperience, ICar car)
        {
            this.Username = username;
            this.RacingBehavior = racingBehavior;
            this.DrivingExperience = drivingExperience;
            this.Car = car;
        }

        public string Username
        {
            get
            {
                return this.username;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRacerName);
                }
                this.username=value;
            }
        }

        public string RacingBehavior 
        {
            get
            {
                return this.racingBehavior;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRacerBehavior);
                }
                this.racingBehavior = value;
            }
        }

        public int DrivingExperience
        {
            get
            {
                return this.drivingExperience;
            }
            protected set
            {
                if (value>100 || value<0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRacerDrivingExperience);
                }
                this.drivingExperience = value;
            }
        }

        public ICar Car
        {
            get
            {
                return this.car;
            }
            private set
            {
                this.car = value;
            }
        }

        public bool IsAvailable()
        {
            return car.FuelAvailable >= car.FuelConsumptionPerRace;
        }

        public virtual void Race()
        {
            
        }
    }
}
