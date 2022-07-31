namespace Heroes.Models.Map
{
    using global::Heroes.IO.Contracts;
    using global::Heroes.Models.Contracts;
    using global::Heroes.Models.Heroes;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Map
    {

        public string Fight(ICollection<IHero> fighters)
        {

            var KnightList = fighters.Where(x => x.GetType().Name == "Knight").ToList();
            var barbarianList = fighters.Where(x => x.GetType().Name == "Barbarian").ToList();

            while (KnightList.Any(x => x.IsAlive) && barbarianList.Any(x => x.IsAlive))
            {
                foreach(var knight in KnightList)
                {
                    foreach(var barbarian in barbarianList)
                    {
                        if (barbarian.IsAlive)
                        {
                            barbarian.TakeDamage(knight.Weapon.DoDamage());
                        }
                    }
                }


                foreach(var barbarian in barbarianList)
                {
                    foreach(var knight in KnightList)
                    {
                        if (knight.IsAlive)
                        {
                            knight.TakeDamage(barbarian.Weapon.DoDamage());
                        }
                    }
                }
            }
            if (KnightList.Any(x => x.Health > 0))
            {
                var deadKnights = KnightList.Where(x => x.Health <= 0);
                return ($"The knights took {deadKnights.Count()} casualties but won the battle.");
            }

            return $"The barbarians took {barbarianList.Where(x => x.Health <= 0).ToList().Count} casualties but won the battle.";
        }
    }
}
