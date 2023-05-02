namespace CarRacing.Models.Maps
{
    using CarRacing.Models.Maps.Contracts;
    using CarRacing.Models.Racers.Contracts;
    using CarRacing.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Map : IMap
    {

        public Map()
        {

        }
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {

            

            if (!racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                return OutputMessages.RaceCannotBeCompleted;
            }
            else if (!racerOne.IsAvailable())
            {
                return String.Format(OutputMessages.OneRacerIsNotAvailable, racerTwo.Username, racerOne.Username);
            }
            else if (!racerTwo.IsAvailable())
            {
                return String.Format(OutputMessages.OneRacerIsNotAvailable, racerOne.Username, racerTwo.Username);
            }


            
            double firstRacerBehaviorMultiplier = 1.1;
            if (racerOne.RacingBehavior == "strict")
            {
                firstRacerBehaviorMultiplier = 1.2;
            }
            double firstRacerCalculations = racerOne.Car.HorsePower * racerOne.DrivingExperience * firstRacerBehaviorMultiplier;

            double secondRacerBehaviorMultiplier = 1.1;
            if (racerTwo.RacingBehavior == "strict")
            {
                secondRacerBehaviorMultiplier = 1.2;
            }
            double secondRacerCalculations = racerTwo.Car.HorsePower * racerTwo.DrivingExperience * secondRacerBehaviorMultiplier;


            IRacer winner = firstRacerCalculations > secondRacerCalculations ? racerOne : racerTwo;
            racerOne.Race();
            racerTwo.Race();
            return String.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, winner.Username);


        }
    }
}
