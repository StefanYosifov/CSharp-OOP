using Raiding.Factory;
using Raiding.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Raiding.Core
{
    internal class Engine : IEngine
    {
        private readonly ICollection<BaseHero> heroes;
        HeroFactory factory;


        public Engine()
        {
            this.heroes=new List<BaseHero>();
            factory = new HeroFactory();
        }


        public void Start()
        {
            
            
            int amountOfHeroes = int.Parse(Console.ReadLine());
            try
            {
                while (heroes.Count < amountOfHeroes)
                { 
                    string name = Console.ReadLine();
                    string type = Console.ReadLine();
                    BaseHero hero = factory.CreateHero(name, type);
                    if(hero == null) 
                    {
                        continue;
                    }
                    heroes.Add(hero);
                }
                foreach (var hero in heroes)
                {
                    Console.WriteLine(hero.CastAbility());
                }


                int victoryPoints = int.Parse(Console.ReadLine());

                if (victoryPoints > heroes.Sum(x => x.Power))
                {
                    Console.WriteLine("Defeat...");// For the future - this can be moved
                }
                else
                {
                    Console.WriteLine("Victory!"); // For the future - this can be moved
                }
            }
            catch (Exception)
            {

                throw;
            }
            

        }
    }
}
