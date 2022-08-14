namespace PlanetWars.Models.MilitaryUnits.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class AnonymousImpactUnit : MilitaryUnit
    {
        private const double AnonymousCost = 30;

        public AnonymousImpactUnit() : base(AnonymousCost)
        {
        }
    }
}
