using Raiding.Exceptions;
using Raiding.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Factory
{
    public class HeroFactory : IHeroFactory
    {
        public BaseHero CreateHero(string name,string type)
        {
            BaseHero hero=null;
            if (type == "Druid")
            {
                hero = new Druid(name,type);
            }
            else if(type == "Paladin")
            {
                hero = new Paladin(name, type);
            }
            else if (type == "Rogue")
            {
                hero = new Rogue(name, type);
            }
            else if (type == "Warrior")
            {
                hero = new Warrior(name, type);
            }
            else
            {
                Console.WriteLine("Invalid hero");  
            }
            return hero;
        }
    }
}
