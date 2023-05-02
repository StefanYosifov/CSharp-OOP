using System;

using WarCroft.Constants;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
		private string name;
		private float baseHealth;
		private float health;
		private float baseArmor;
		private float armor;
		private float abilityPoints;
		private bag bag;


        public string Name
        {
			get => this.name;
			private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
					throw new ArgumentNullException(ExceptionMessages.CharacterNameInvalid);
                }
				this.name = value;
            }
        }

        public float BaseHealth
		{
			get => this.baseHealth;
			private set
            {
				this.baseHealth = value;
            }
		}

        public float Health
        {
			get=> this.Health;
			private set
            {
				this.health = value;
            }
        }

        public float BaseArmor
        {
			get => this.baseArmor;
            private set
            {
				this.baseArmor = value;
            }
        }

        public int Armor
        {
			get => this.armor;
			private set
            {
				this.armor = value;
            }
        }


        public bool IsAlive { get; set; } = true;

		protected void EnsureAlive()
		{
			if (!this.IsAlive)
			{
				throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
			}
		}
	}
}