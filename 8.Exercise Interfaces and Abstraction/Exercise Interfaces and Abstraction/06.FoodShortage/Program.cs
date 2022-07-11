using System;
using System.Linq;

namespace _06.FoodShortage
{
    using Models;
    using Models.Interfaces;
    using System.Collections.Generic;

    public class Program
    {
        static void Main(string[] args)
        {
            int numberOfPeople=int.Parse(Console.ReadLine());
            List<IInhabitant> inhabitants = new List<IInhabitant>();
            for(int i=0; i<numberOfPeople; i++)
            {
                bool skipAddingName = false;
                string[] inhabitantInformation = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                string name = inhabitantInformation[0];
                int age = int.Parse(inhabitantInformation[1]);
                IInhabitant inhabitant = null;
                if (inhabitantInformation.Length == 4)
                {
                    string Id=inhabitantInformation[2];
                    string Birthdate=inhabitantInformation[3];
                    inhabitant = new Citizen(name, age, Id, Birthdate);
                }
                else if (inhabitantInformation.Length == 3)
                {
                    string Id = inhabitantInformation[1];
                    string group = inhabitantInformation[2];
                    inhabitant = new Rebel(name, Id, group); 
                }
                foreach(var inhabits in inhabitants)
                {
                    if (inhabits.Name == name)
                    {
                        skipAddingName = true;
                        break;
                    }
                }
                if (!skipAddingName)
                {
                    inhabitants.Add(inhabitant);
                }
            }

            string names = Console.ReadLine();
            while (names != "End")
            {
                var Ibuyer=inhabitants.Where(x=>x.Name == names).FirstOrDefault();
                if (Ibuyer != null)
                {
                    Ibuyer.BuyFood();
                }

                names = Console.ReadLine();
            }
            Console.WriteLine(inhabitants.Sum(x=>x.Food));
        }
    }
}
