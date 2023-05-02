namespace Heroes.Models.Weapons
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Mace : Weapon
    {
        private int maceDamage = 25;

        public int MaceDamage => maceDamage;

        public Mace(string name, int durability) : base(name, durability)
        {

        }

        public override int DoDamage()
        {
            this.Durability -= 1;
            if(this.Durability <= 0)
            {
                return 0;
            }
            return MaceDamage;
        }
    }
}
