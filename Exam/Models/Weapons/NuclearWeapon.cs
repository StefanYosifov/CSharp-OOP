namespace PlanetWars.Models.Weapons
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class NuclearWeapon : Weapon
    {
        private const double NuclearDestructionLevel = 15;
        public NuclearWeapon(int destructionLevel) : base(destructionLevel, 15)
        {
        }
    }
}
