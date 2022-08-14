namespace PlanetWars.Models.MilitaryUnits
{
    using PlanetWars.Models.MilitaryUnits.Contracts;
    using PlanetWars.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Text;


    public class MilitaryUnit : IMilitaryUnit
    {
        private const int EnduranceInitial = 1;


        private double cost;
        private int enduranceLevel;

        public MilitaryUnit(double cost)
        {
            this.Cost = cost;
            this.EnduranceLevel = EnduranceInitial;
        }

        public double Cost
        {
            get => this.cost;
            private set
            {
                this.cost = value;
            }
        }

        public int EnduranceLevel
        {
            get => this.enduranceLevel;
            private set
            {
                this.enduranceLevel = value;
            }
        }

        public void IncreaseEndurance()
        {
            this.EnduranceLevel += 1;
            if(this.EnduranceLevel > 20)
            {
                throw new ArgumentException(ExceptionMessages.EnduranceLevelExceeded);
            }
        }
    }
}
