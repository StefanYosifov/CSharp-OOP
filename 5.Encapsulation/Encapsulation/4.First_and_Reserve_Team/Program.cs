using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonsInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int numberOfPeople = int.Parse(Console.ReadLine());
            List<Person> people = new List<Person>();
            Person person = new Person();
            for (int i = 0; i < numberOfPeople; i++)
            {
                try
                {


                    string[] perInf = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                    string firstName = perInf[0];
                    string lastName = perInf[1];
                    int age = int.Parse(perInf[2]);
                    decimal salary = decimal.Parse(perInf[3]);
                    person = new Person(firstName, lastName, age, salary);

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                people.Add(person);

            }

            Team teams = new Team("Softuni");
            foreach(var p in people)
            {
                teams.Add(p);
            }
            teams.FirstTeamCount();
            teams.ReserveTeamCount();
            
        }
    }
}
