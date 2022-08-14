namespace PlanetWars.Models.Planets
{
    using PlanetWars.Models.MilitaryUnits.Contracts;
    using PlanetWars.Models.Planets.Contracts;
    using PlanetWars.Models.Weapons;
    using PlanetWars.Models.Weapons.Contracts;
    using PlanetWars.Repositories;
    using PlanetWars.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Planet : IPlanet
    {
        private string name;
        private double budget;
        private double militaryPower;
        private readonly ICollection<IMilitaryUnit> army;
        private readonly ICollection<IWeapon> weaponsCollection;
        private UnitRepository units;
        private WeaponRepository weapons;


        public Planet(string name,double budget)
        {
            this.Name = name;
            this.Budget = budget;
            this.army = new List<IMilitaryUnit>();
            this.weaponsCollection = new List<IWeapon>();
            this.units = new UnitRepository();
            this.weapons=new WeaponRepository();
        }
        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlanetName);
                }
                this.name = value;
            }
        }

        public double Budget
        {
            get => this.budget;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBudgetAmount);
                }
                this.budget = value;
            }
        }

        public double MilitaryPower 
        {
            get => CalculateMilitaryPower();
            private set
            {
                this.militaryPower = value;
            }
            
        }

        public IReadOnlyCollection<IMilitaryUnit> Army => this.army as IReadOnlyCollection<IMilitaryUnit>;

        public IReadOnlyCollection<IWeapon> Weapons => this.weapons as IReadOnlyCollection<IWeapon>;

        public void AddUnit(IMilitaryUnit unit)
        {
            this.units.AddItem(unit);
        }

        public void AddWeapon(IWeapon weapon)
        {
            this.weapons.AddItem(weapon);
        }

        public string PlanetInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Planet: {Name}");
            sb.AppendLine($"--Budget: {Budget} billion QUID");
            if (this.units.Models.Count > 0)
            {
                sb.AppendLine($"--Forces: {string.Join(", ", weaponsCollection)}");
            }
            else
            {
                sb.AppendLine($"--Forces: No units");
            }
            if (this.weapons.Models.Count > 0)
            {
                sb.AppendLine($"--Combat equipment: {string.Join(", ", weapons)}");
            }
            else
            {
                sb.AppendLine($"--Combat equipment: No weapons");
            }
            sb.AppendLine($"--Military Power: {MilitaryPower}");
            return sb.ToString().Trim();
        }

        public void Profit(double amount)
        {
            this.Budget += amount;
        }

        public void Spend(double amount)
        {
            if (this.Budget < amount)
            {
                throw new InvalidOperationException(ExceptionMessages.UnsufficientBudget);
            }
            this.Budget -= amount;
        }

        public void TrainArmy()
        {
            foreach(var unit in army)
            {
                unit.IncreaseEndurance();
            }
        }


        private double CalculateMilitaryPower()
        {
            double totalAmount = this.units.Models.Sum(x=>x.EnduranceLevel) + this.Weapons.Sum(x=>x.DestructionLevel);
            if (this.Army.Any(x=>x.GetType().Name == nameof(AnonymousImpactUnit)))
            {
                totalAmount *= 1.3;
            }
            if (this.Weapons.Any(x=>x.GetType().Name == nameof(NuclearWeapon)))
            {
                totalAmount *= 1.45;
            }
            return Math.Round(totalAmount, 3);
        }
    }
}
