﻿namespace Formula1.Models.Pilots
{
    using Formula1.Models.Contracts;
    using Formula1.Utilities;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Pilot : IPilot
    {
        public Pilot(string fullName)
        {
            FullName = fullName;
            CanRace = false;
            NumberOfWins = 0;

        }



        private string fullName;
        private IFormulaOneCar car;
        private int numberOfWins;
        private bool canRace;

        public string FullName
        {
            get { return fullName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidPilot, value));
                }
                fullName = value;
            }

        }

        public IFormulaOneCar Car
        {
            get { return car; }
            private set
            {
                if (value == null)
                {
                    throw new NullReferenceException(ExceptionMessages.InvalidCarForPilot);
                }
                car = value;
            }
        }

        public int NumberOfWins
        {
            get
            { return numberOfWins; }
            private set
            {
                numberOfWins = value;
            }
        }

        public bool CanRace
        {
            get { return canRace; }
            private set { canRace = value; }
        }

        public void AddCar(IFormulaOneCar car)
        {
            CanRace = true;
            Car = car;
        }

        public void WinRace()
        {
            NumberOfWins++;
        }


        public override string ToString()
        {
            return $"Pilot {FullName} has {NumberOfWins}.";
        }


    }
}
