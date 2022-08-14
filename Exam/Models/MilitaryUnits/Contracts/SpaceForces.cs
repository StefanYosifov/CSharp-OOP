namespace PlanetWars.Models.MilitaryUnits.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class SpaceForces : MilitaryUnit
    {
        private const double SpaceCost = 11;
        public SpaceForces() : base(SpaceCost)
        {
        }
    }
}
