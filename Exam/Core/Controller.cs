using PlanetWars.Core.Contracts;

namespace PlanetWars.Core
{
    using PlanetWars.Models.MilitaryUnits.Contracts;
    using PlanetWars.Models.Planets;
    using PlanetWars.Models.Planets.Contracts;
    using PlanetWars.Models.Weapons;
    using PlanetWars.Models.Weapons.Contracts;
    using PlanetWars.Repositories;
    using PlanetWars.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Controller : IController
    {
        public Controller()
        {
            this.planets = new PlanetRepository();
 
        }


        private PlanetRepository planets;
        public string AddUnit(string unitTypeName, string planetName)
        {
            IPlanet planet=planets.FindByName(planetName);
            if (planet == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            IMilitaryUnit unit = null;

            if (unitTypeName == nameof(SpaceForces))
            {
                unit = new SpaceForces();
            }
            else if (unitTypeName == nameof(StormTroopers))
            {
                unit = new StormTroopers();
            }
            else if (unitTypeName == nameof(AnonymousImpactUnit))
            {
                unit = new AnonymousImpactUnit();
            }
            else
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.ItemNotAvailable, unitTypeName));
            }

            if (planet.Army.Any(x=>GetType().Name == unit.GetType().Name))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnitAlreadyAdded, unitTypeName, planetName));
            }
            planet.Spend(unit.Cost);
            planet.AddUnit(unit);


            return String.Format(OutputMessages.UnitAdded, unitTypeName, planetName);

        }

        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel) ///////////////////////////////////!!!!!!!!!!!!!???
        {
            IPlanet planet=planets.FindByName(planetName);
            if (planet == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            IWeapon weapon = null;
            if (weaponTypeName == nameof(SpaceMissiles))
            {
                weapon=new SpaceMissiles(destructionLevel);
            }
            else if (weaponTypeName == nameof(NuclearWeapon))
            {
                weapon = new NuclearWeapon(destructionLevel);
            }
            else if (weaponTypeName == nameof(BioChemicalWeapon))
            {
                weapon = new BioChemicalWeapon(destructionLevel);
            }
            else
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.ItemNotAvailable, weaponTypeName));
            }

            if (planets.Models.Any(x => x.GetType().Name == weapon.GetType().Name))
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.WeaponAlreadyAdded, weaponTypeName, planetName));
            }
            

            planet.Spend(weapon.Price);
            planet.AddWeapon(weapon);
            return String.Format(OutputMessages.WeaponAdded, planetName, weaponTypeName);
        }

        public string CreatePlanet(string name, double budget)
        {
            if (planets.Models.Any(x => x.Name == name))
            {
                return string.Format(OutputMessages.ExistingPlanet, name);
            }

            IPlanet planet = new Planet(name, budget);
            planets.AddItem(planet);
            return string.Format(OutputMessages.NewPlanet, name);
        }

        public string ForcesReport()
        {
            StringBuilder sb = new StringBuilder();
            var orderedPlanets = planets.Models.OrderByDescending(m => m.MilitaryPower).ThenBy(a => a.Name);
            sb.AppendLine($"***UNIVERSE PLANET MILITARY REPORT***");
            foreach(var planet in orderedPlanets)
            {
                sb.AppendLine(planet.PlanetInfo());
            }
            return sb.ToString().Trim();
        }

        public string SpaceCombat(string planetOne, string planetTwo)
        {
            IPlanet firstPlanet = planets.FindByName(planetOne);
            IPlanet secondPlanet = planets.FindByName(planetTwo);


            bool bothContainNuclearWeapons = firstPlanet.Weapons.Any(x=>x.GetType().Name == nameof(NuclearWeapon))
                && secondPlanet.Weapons.Any(x=>x.GetType().Name==nameof(NuclearWeapon));
            bool bothHaveTheSameMilitaryPower = firstPlanet.MilitaryPower == secondPlanet.MilitaryPower;


            if (bothHaveTheSameMilitaryPower && !bothContainNuclearWeapons) // Same military strenght, one nuke
            {
                if (firstPlanet.Weapons.Any(x=>x.GetType().Name == nameof(NuclearWeapon)))
                {
                    firstPlanet.Spend(firstPlanet.Budget / 2);
                    firstPlanet.Profit(secondPlanet.Army.Sum(x => x.Cost) + secondPlanet.Weapons.Sum(x => x.Price));
                    firstPlanet.Profit(secondPlanet.Budget / 2);
                }
                else if(secondPlanet.Weapons.Any(x=>x.GetType().Name==nameof(NuclearWeapon)))
                {
                    secondPlanet.Spend(secondPlanet.Budget / 2);
                    secondPlanet.Profit(firstPlanet.Army.Sum(x => x.Cost) + firstPlanet.Weapons.Sum(x => x.Price));
                    secondPlanet.Profit(firstPlanet.Budget / 2);
                }
                else if(firstPlanet.Weapons.Any(x => x.GetType().Name != nameof(NuclearWeapon)) && secondPlanet.Weapons.Any(x => x.GetType().Name != nameof(NuclearWeapon)))
                {
                    firstPlanet.Spend(firstPlanet.Budget / 2);
                    secondPlanet.Spend(secondPlanet.Budget / 2);
                    return OutputMessages.NoWinner;
                }
            }



            else if (bothHaveTheSameMilitaryPower && bothContainNuclearWeapons) // Same military strenght, 2 nukes
            {
                firstPlanet.Spend(firstPlanet.Budget / 2);
                secondPlanet.Spend(secondPlanet.Budget / 2);
                return OutputMessages.NoWinner;
            }


            else if (firstPlanet.MilitaryPower > secondPlanet.MilitaryPower) // First stronger,no nukes
            {
                firstPlanet.Spend(firstPlanet.Budget/2);
                firstPlanet.Profit(secondPlanet.Budget/2);
                firstPlanet.Profit(secondPlanet.Army.Sum(x => x.Cost) + secondPlanet.Weapons.Sum(x => x.Price));
                this.planets.RemoveItem(secondPlanet.Name);
                return string.Format(OutputMessages.WinnigTheWar,firstPlanet.Name,secondPlanet.Name);
            }


               secondPlanet.Spend(secondPlanet.Budget / 2); // Second stronger, no nukes
               secondPlanet.Profit(firstPlanet.Budget / 2);
               secondPlanet.Profit(firstPlanet.Army.Sum(x => x.Cost) + firstPlanet.Weapons.Sum(x => x.Price));
               this.planets.RemoveItem(firstPlanet.Name);
               return string.Format(OutputMessages.WinnigTheWar, secondPlanet.Name, firstPlanet.Name);



        }

        public string SpecializeForces(string planetName)
        {
            IPlanet planet = planets.FindByName(planetName);
            if (planet == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            if (planet.Army == null)
            {
                throw new InvalidOperationException(ExceptionMessages.NoUnitsFound);
            }

            foreach(var unit in planet.Army)
            {
                unit.IncreaseEndurance();
            }

            planet.Spend(1.25);
            return String.Format(OutputMessages.ForcesUpgraded, planetName);
        }
    }
}
