namespace PlanetWars.Models.MilitaryUnits.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class StormTroopers : MilitaryUnit
    {
        private const double StormCost = 2.5;

        public StormTroopers() : base(StormCost)
        {
        }
    }
}
