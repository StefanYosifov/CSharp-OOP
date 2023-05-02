using System;
using System.Collections.Generic;

namespace _04.BorderControl
{
    using Models;
    using Models.Interfaces;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            List<IInhabitant> inhabitants = new List<IInhabitant>();
            while (command != "End")
            {
                string[] inhabitantFromConsole = command.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries).ToArray();
                string name=inhabitantFromConsole[0];
                IInhabitant inhabitant = null;
                if (inhabitantFromConsole.Length==2)
                {
                    string ID = inhabitantFromConsole[1];
                    inhabitant=new Robot(name,ID);
                }
                else
                {
                    int age = int.Parse(inhabitantFromConsole[1]);
                    string ID = inhabitantFromConsole[2];
                    inhabitant = new Citizen(name, age, ID);
                }

                inhabitants.Add(inhabitant);
                command = Console.ReadLine();
            }

            string removeID = Console.ReadLine();
            inhabitants.RemoveAll(x => !x.Id.EndsWith(removeID));
            foreach(var ids in inhabitants)
            {
                Console.WriteLine(ids.Id);
            }
        }
    }
}
