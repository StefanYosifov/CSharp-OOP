namespace Formula1.Core
{
    using Formula1.Core.Contracts;
    using Formula1.Models.Contracts;
    using Formula1.Repositories;
    using Formula1.Utilities;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;
    using Formula1.Models.Race;
    using System.Reflection;
    using Formula1.Models.Pilots;
    using Formula1.Models.Cars;

    public class Controller : IController
    {
        private PilotRepository pilotRepository;
        private FormulaOneCarRepository carRepository;
        private RaceRepository raceRepository;

        public Controller()
        {
            this.pilotRepository = new PilotRepository();
            this.carRepository = new FormulaOneCarRepository();
            this.raceRepository = new RaceRepository();
        }

        public string AddCarToPilot(string pilotName, string carModel)
        {
            IPilot pilot = pilotRepository.FindByName(pilotName);
            if (pilot.Car!=null || pilot.Car.Model == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotDoesNotExistOrHasCarErrorMessage, pilotName));
            }

            if (pilotRepository.Models.Any(x => x.Car.Model != carModel))
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.CarDoesNotExistErrorMessage, carModel));
            }

            IFormulaOneCar car = carRepository.FindByName(carModel);
            pilot.AddCar(car);

            return String.Format(OutputMessages.SuccessfullyPilotToCar,pilotName,car.GetType().Name,carModel);
        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            if (raceRepository.Models.Any(x => x.RaceName!=raceName))
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }
            
            IPilot pilot= pilotRepository.FindByName(pilotFullName);
            IRace race = raceRepository.FindByName(raceName);
            if(pilot.CanRace==false || pilot==null || race.Pilots.Any(x => x.FullName == pilot.FullName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotDoesNotExistErrorMessage, pilotFullName));
            }
            race.AddPilot(pilot);
            return String.Format(OutputMessages.SuccessfullyAddPilotToRace,pilotFullName,raceName);
        }

        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {

            Type typeClass=typeof(IFormulaOneCar);
            ConstructorInfo ctor = typeClass.GetConstructor(BindingFlags.Instance,null,CallingConventions.Any,null,null);
            
            
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidTypeCar, type));
            }
            if (carRepository.Models.Any(x => x.Model == model))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarExistErrorMessage, model));
            }
            return string.Format(OutputMessages.SuccessfullyCreateCar, type,model);
            
        }

        public string CreatePilot(string fullName)
        {
            var pilot = new Pilot(fullName);
            if(pilot == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotExistErrorMessage,fullName));
            }
            pilotRepository.Add(pilot);
            return string.Format(OutputMessages.SuccessfullyCreatePilot,fullName);
        }

        public string CreateRace(string raceName, int numberOfLaps)
        {
            if (raceRepository.Models.Any(x => x.RaceName == raceName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExistErrorMessage, raceName));
            }

            IRace race=new Race(raceName, numberOfLaps);
            raceRepository.Add(race);
            return String.Format(OutputMessages.SuccessfullyCreateRace, raceName);
        }

        public string PilotReport()
        {
            StringBuilder sb = new StringBuilder();
            var pilot = pilotRepository.Models;
            foreach(var pilotItem in pilot)
            {
                sb.AppendLine(pilotItem.ToString());
            }
            return sb.ToString().Trim();
        }

        public string RaceReport()
        {
            StringBuilder sb = new StringBuilder();
            var race=raceRepository.Models;
            foreach(var raceItem in race)
            {
                sb.AppendLine(raceItem.RaceInfo());
            }
            return sb.ToString().Trim();
        }

        public string StartRace(string raceName)
        {
            if (raceRepository.Models.Any(x=>x.RaceName!=raceName))
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }

            IRace race = raceRepository.FindByName(raceName);
            if (race.Pilots.Count < 3)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidRaceParticipants, raceName));
            }
            if (race.TookPlace == true)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceTookPlaceErrorMessage, raceName));
            }

            var driverParticipants = race.Pilots.OrderByDescending(x => x.Car.RaceScoreCalculator(race.NumberOfLaps)).ToArray();
            StringBuilder sb = new StringBuilder();

            var firstDriver = driverParticipants[0];
            var secondDriver= driverParticipants[1];
            var thirdDriver= driverParticipants[2];
            sb.AppendLine($"Pilot {firstDriver.FullName} wins the {raceName} race.");
            sb.AppendLine($"Pilot {secondDriver.FullName} is second in the {raceName} race.");
            sb.AppendLine($"Pilot {thirdDriver.FullName} is third in the {raceName} race.");

            return sb.ToString().Trim();
        }
    }
}
