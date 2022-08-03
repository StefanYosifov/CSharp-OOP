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
            


            if(racerOne==null && racerTwo == null)
            {
                return OutputMessages.RaceCannotBeCompleted;
            }
            else if (racerOne == null)
            {
                return String.Format(OutputMessages.OneRacerIsNotAvailable, racerTwo.Username, racerOne.Username);
            }
            else if (racerTwo == null)
            {
                return String.Format(OutputMessages.OneRacerIsNotAvailable, racerOne.Username, racerTwo.Username);
            }
            else
            {
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

                racerOne.Car.Drive();
                racerTwo.Car.Drive();
                racerOne.Race();
                racerTwo.Race();

                IRacer winner = firstRacerCalculations > secondRacerCalculations ? racerOne : racerTwo;
                 return String.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, winner.Username);

            }
        }
    }
}
