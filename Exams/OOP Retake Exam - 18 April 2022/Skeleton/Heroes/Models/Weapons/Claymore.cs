namespace Heroes.Models.Weapons
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Claymore : Weapon
    {


        private int claymoreDamage = 20;
        public int ClaymoreDamage => claymoreDamage;

        public Claymore(string name, int durability) : base(name, durability)
        {

        }

        public override int DoDamage()
        {
            this.Durability -= 1;
            if (this.Durability <= 0)
            {
                return 0;
            }
            return ClaymoreDamage;
        }
    }
}
