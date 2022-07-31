namespace Heroes.Core
{
    using Heroes.Core.Contracts;
    using Heroes.IO;
    using Heroes.Models.Contracts;
    using Heroes.Models.Heroes;
    using Heroes.Models.Map;
    using Heroes.Models.Weapons;
    using Heroes.Repositories;
    using Heroes.Utilities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Reflection;

    public class Controller : IController
    {

        private HeroRepository heroes;
        private WeaponRepository weapons;
        Writer writer;


        public Controller()
        {
            this.heroes = new HeroRepository();
            this.weapons = new WeaponRepository();
            Writer writer = new Writer();
        }

        public string AddWeaponToHero(string weaponName, string heroName)
        {
            IWeapon weapon = weapons.Models.FirstOrDefault(x => x.Name == weaponName);
            IHero hero=heroes.Models.FirstOrDefault(x => x.Name == heroName);


            if (weapon == null)
            {
                throw new InvalidOperationException(string.Format(WeaponsErrorMessages.weaponWithSuchNameDoesNotExist, weaponName));
            }
            if (hero == null)
            {
                throw new InvalidOperationException(string.Format(HeroesErrorMessages.heroWithSuchNameDoesNotExist,heroName));
            }
            if(hero.Weapon != null)
            {
                throw new InvalidOperationException(string.Format(HeroesErrorMessages.heroAlreadyHasAWeapon, hero.Name));
            }

            hero.AddWeapon(weapon);
            return $"Hero {heroName} can participate in battle using a {weapons}.".Trim();
        }

        public string CreateHero(string type, string name, int health, int armour)
        {


            Type[] heroTypes = Assembly.GetExecutingAssembly().GetTypes();
            IHero findHero = heroes.FindByName(name);
            if (findHero.Name == null)
            {
                throw new InvalidOperationException(string.Format(HeroesErrorMessages.heroWithSuchNameExists, name));
            }
            if (heroTypes.Any(x => x.GetType().Name != type))
            {
                throw new InvalidOperationException(HeroesErrorMessages.heroWithSuchTypeExists);
            }
            heroes.Add(findHero);
            return string.Format(WeaponsErrorMessages.weaponSuccesfullyAdded, name);
    }

        public string CreateWeapon(string type, string name, int durability)
        {

            
            Type[] classesTypes = Assembly.GetEntryAssembly().GetTypes().Where(x=>x.IsSubclassOf(Weapon));
            IWeapon findWeapon = weapons.Models.FirstOrDefault(x => x.Name == name);
            if (weapons.Models.Contains(findWeapon))
            {
                throw new InvalidOperationException(string.Format(WeaponsErrorMessages.weaponWithSuchNameExists, name));
            }
            if (classesTypes.Any(x=>x.GetType().Name.ToLower()!=type))
            {
                throw new InvalidOperationException(WeaponsErrorMessages.weaponTypeIsInvalid);
            }

            IWeapon weapon = null;
            if (type == "Mace")
            {
                weapon = new Mace(name, durability);
            }
            else if (type == "Claymore")
            {
                weapon = new Claymore(name, durability);
            }
            weapons.Add(weapon);
            return $"A {type} {name} is added to the collection.";
        }

        public string HeroReport()
        {
            StringBuilder sb = new StringBuilder();
            var orderedHero = heroes.Models.OrderBy(x => x.GetType().Name).ThenByDescending(x => x.Health).ThenBy(x => x.Name);
            foreach(var hero in orderedHero)
            {
                sb.AppendLine($"{hero.GetType().Name}: {hero.Name}");
                sb.AppendLine($"--Health: {hero.Health}");
                sb.AppendLine($"--Armour: {hero.Armour}");
                sb.AppendLine($"--Weapon: {hero.Weapon}/Unarmed");
            }
            return sb.ToString().Trim();
        }

        public string StartBattle()
        {
            Map map = new Map();
            return map.Fight((ICollection<IHero>)heroes.Models);
        }
    }
}
