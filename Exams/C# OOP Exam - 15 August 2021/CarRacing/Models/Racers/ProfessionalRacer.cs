namespace CarRacing.Models.Racers
{
    using CarRacing.Models.Cars.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ProfessionalRacer : Racer
    {
        private const int StartingDrivingExperience = 30;
        private const string StartingRacingBehavior = "strict";
        private const int IncreaseDrivingExperience = 10;

        public ProfessionalRacer(string username,ICar car) 
            : base(username, StartingRacingBehavior, StartingDrivingExperience, car)
        {
        }

        public override void Race()
        {
            base.Race();
            this.DrivingExperience += IncreaseDrivingExperience;
        }

    }
}
