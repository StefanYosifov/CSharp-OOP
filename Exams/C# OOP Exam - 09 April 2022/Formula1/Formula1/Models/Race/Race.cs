namespace Formula1.Models.Race
{
    using Formula1.Models.Contracts;
    using Formula1.Utilities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Race : IRace
    {
        private const int InvalidLapCount = 1;

        public Race(string raceName, int numberOfLaps)
        {
            RaceName = raceName;
            NumberOfLaps = numberOfLaps;
            TookPlace = false;
            pilots = new List<IPilot>();
        }


        private string raceName;
        private int numberOfLaps;
        private bool tookPlace;
        private readonly ICollection<IPilot> pilots;

        public Race()
        {
        }

        public string RaceName
        {
            get
            { return raceName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidRaceName, value));
                }
                raceName = value;
            }
        }

        public int NumberOfLaps
        {
            get { return numberOfLaps; }
            private set
            {
                if (value < InvalidLapCount)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidLapNumbers, value));
                }
                numberOfLaps = value;
            }
        }

        public ICollection<IPilot> Pilots
        {
            get
            {
                return pilots;
            }
        }


        public bool TookPlace
        {
            get
            {
                return tookPlace;
            }
            set
            {
                tookPlace = value;
            }
        }



        public void AddPilot(IPilot pilot)
        {
            pilots.Add(pilot);
        }

        public string RaceInfo()
        {
            StringBuilder sb = new StringBuilder();
            string YesOrNo = TookPlace ? "Yes" : "No";

            sb.AppendLine($"The {RaceName} race has:");
            sb.AppendLine($"Participants: {Pilots.Where(x=>x.CanRace).Count()}");
            sb.AppendLine($"Number of laps: {NumberOfLaps}");
            sb.AppendLine($"Took place: {YesOrNo}");
            return sb.ToString().Trim();
        }
    }
}
