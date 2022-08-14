namespace PlanetWars.Models.Weapons
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class SpaceMissiles : Weapon
    {
        private const double SpaceDestructionLevel = 8.75;
        public SpaceMissiles(int destructionLevel) : base(destructionLevel, 8.75)
        {

        }
    }
}
