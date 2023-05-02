using System;
using System.Linq;

namespace _05.BirthdayCelebrations
{
    using Models.Interfaces;
    using Models;
    using System.Collections.Generic;

    public class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine().Trim();
            List<IBirthdate> inhabitants = new List<IBirthdate>();
            while (command != "End")
            {
                string[] citizenInformation = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string inhabitantType = citizenInformation[0];
                string name = citizenInformation[1];
                IBirthdate inhabitant = null;
                if (inhabitantType == "Citizen")
                {
                    int age = int.Parse(citizenInformation[2]);
                    string ID = citizenInformation[3];
                    string birthdate = citizenInformation[4];
                    inhabitant = new Citizen(name, age, ID, birthdate);
                }
                else if (inhabitantType == "Pet")
                {
                    string birthdate = citizenInformation[2];
                    inhabitant = new Pet(name,birthdate);

                }
                else if (inhabitantType == "Robot")
                {
                    string ID = citizenInformation[2];
                    inhabitant = new Robot(name, ID);
                }
                inhabitants.Add(inhabitant);
                command = Console.ReadLine();
            }

            string yearToDisplay = Console.ReadLine();
            DisplayYear(inhabitants, yearToDisplay);

        }
    
       static public void DisplayYear(List<IBirthdate> list,string year)
        {
            foreach(var inhabitant in list)
            {
                if (inhabitant.Birthdate != null)
                {
                    string[] date = inhabitant.Birthdate.Split('/');
                    if (date[2] == year)
                    {
                        Console.WriteLine(inhabitant.Birthdate);
                    }
                }
            }
        }
    }
}
