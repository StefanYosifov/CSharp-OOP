namespace Gym.Models.Athletes
{
    using Gym.Models.Athletes.Contracts;
    using Gym.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Athlete : IAthlete
    {
        public Athlete(string fullName,string motivation,int numberOfMedals, int stamina)
        {
            this.FullName = fullName;
            this.Motivation = motivation;
            this.NumberOfMedals = numberOfMedals;
            this.Stamina = stamina;
        }


        private string fullName;
        private string motivation;
        private int stamina;
        private int numberOfMedals;

        public string FullName
        {
            get
            {
                return this.fullName; 
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGymName);
                }
                this.fullName = value;
            }
        }

        public string Motivation
        {
            get
            {
                return this.motivation;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAthleteMotivation);
                }
                this.motivation = value;
            }
        }

        public int Stamina
        {
            get
            {
                return this.stamina;
            }
            protected set
            {
                this.stamina = value;
            }
        }

        public int NumberOfMedals
        {
            get
            {
                return this.numberOfMedals;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAthleteMedals);
                }
                this.numberOfMedals = value;
            }
        }

        public abstract void Exercise();
    }
}
