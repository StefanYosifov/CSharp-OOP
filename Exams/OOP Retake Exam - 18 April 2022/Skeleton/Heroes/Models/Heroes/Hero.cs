namespace Heroes.Models.Heroes
{
    using global::Heroes.Models.Contracts;
    using global::Heroes.Utilities;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Hero : IHero
    {

        //fields
        private string name;
        private int health;
        private int armour;
        private IWeapon weapon;

        public Hero(string name,int health,int armour) 
        {
            this.Name = name;
            this.Health = health;
            this.Armour = armour;
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
                    throw new ArgumentException(HeroesErrorMessages.nameIsNullOrWhiteSpace);
                }
                this.name = value;
            }
        }

        public int Health
        {
            get
            {
                return this.health;
            }
            protected set
            {
                if(value< 0)
                {
                    throw new ArgumentException(HeroesErrorMessages.healthIsBelowZero);
                }
                this.health = value;
            }
        }

        public int Armour
        {
            get
            {
                return this.armour;
            }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(HeroesErrorMessages.armourIsBelowZero);
                }
                this.armour = value;
            }
        }

        public IWeapon Weapon
        {
            get
            {
                return this.weapon;
            }
            protected set
            {
                AddWeapon(value);
            }
        }

        public bool IsAlive
        {
            get
            {
                if (this.Health > 0)
                {
                    return true;
                }
                return false;
            }
        }

        public void AddWeapon(IWeapon weapon)
        {
            if (weapon == null)
            {
                throw new ArgumentException(WeaponsErrorMessages.weaponIsNull);
            }
            this.Weapon = weapon;
        }

        public void TakeDamage(int points)
        {
            this.Armour -= points;
            if (this.Armour < 0)
            {
                int remainingPoints = points - this.Armour;
                this.Armour = 0;
                this.Health -= remainingPoints;
            }
            else
            {
                this.Health -= points;
            }
            if (this.Health < 0)
            {
                this.Health = 0;
            }
        }
    }
}
