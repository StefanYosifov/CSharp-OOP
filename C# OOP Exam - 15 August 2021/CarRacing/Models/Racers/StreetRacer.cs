namespace CarRacing.Models.Racers
{
    using CarRacing.Models.Cars.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class StreetRacer : Racer
    {
        private const int StartingDrivingExperience = 10;
        private const string StartingRacingBehavior = "aggresive";
        private const int IncreaseDrivingExperience = 5;
        public StreetRacer(string username, ICar car) : base(username, StartingRacingBehavior, StartingDrivingExperience, car)
        {
        }

        public override void Race()
        {
            base.Race();
            this.DrivingExperience += IncreaseDrivingExperience;
        }
    }
}
