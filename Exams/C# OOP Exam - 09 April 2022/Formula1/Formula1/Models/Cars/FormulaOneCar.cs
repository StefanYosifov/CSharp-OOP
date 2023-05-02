namespace Formula1.Models.Cars
{
    using Formula1.Models.Contracts;
    using Formula1.Utilities;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class FormulaOneCar : IFormulaOneCar
    {
        private const int MinHorsePower = 900;
        private const int MaxHorsePower = 1050;
        private const double MinEngineDispalcement = 1.6;
        private const double MaxEngineDisplacement = 2.0;


        public FormulaOneCar(string model, int horsepower, double engineDisplacement)
        {
            Model = model;
            Horsepower = horsepower;
            EngineDisplacement = engineDisplacement;
        }

        private string model;
        private int horsepower;
        private double engineDisplacement;


        public string Model
        {
            get { return model; }
            protected set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 3)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidF1CarModel, value));
                }
                model = value;
            }
        }

        public int Horsepower
        {
            get { return horsepower; }
            protected set
            {
                if (value < MinHorsePower || value > MaxHorsePower)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidF1HorsePower, value));
                }
                horsepower = value;
            }
        }

        public double EngineDisplacement
        {
            get { return engineDisplacement; }
            protected set
            {
                if (value < MinEngineDispalcement || value > MaxEngineDisplacement)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidF1EngineDisplacement, value));
                }
                engineDisplacement = value;
            }
        }

        public double RaceScoreCalculator(int laps)
        {
            return EngineDisplacement / horsepower * laps;
        }
    }
}
