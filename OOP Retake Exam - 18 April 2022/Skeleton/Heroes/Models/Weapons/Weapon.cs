namespace Heroes.Models.Weapons
{
    using global::Heroes.Models.Contracts;
    using global::Heroes.Utilities;
    using System;

    public abstract class Weapon : IWeapon
    {
        private string name;
        private int durability;

        protected Weapon(string name,int durability)
        {
            this.Name = name;
            this.Durability = durability;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            protected set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(WeaponsErrorMessages.nameIsEmptyOrWhiteSpace);
                }
            }
        }

        public int Durability
        {
            get
            {
                return this.durability;
            }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(WeaponsErrorMessages.durabilityIsBelowZero);
                }
            }
        }

        public abstract int DoDamage();
        
    }
}
