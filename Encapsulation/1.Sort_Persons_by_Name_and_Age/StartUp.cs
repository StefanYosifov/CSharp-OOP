using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonsInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            int peopleNumber = int.Parse(Console.ReadLine());
            var people = new List<Person>();


            for(int i = 0; i < peopleNumber; i++)
            {
                string[] personInfo = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).ToArray();
                string personFirstName=personInfo[0];
                string personLastName=personInfo[1];
                int personAge = int.Parse(personInfo[2]);
                Person person = new Person(personFirstName, personLastName, personAge);
                people.Add(person);
            }

            var ordered = people.OrderBy(x => x.FirstName).ThenBy(x => x.LastName);

            foreach(var person in ordered)
            {
                Console.WriteLine(person);
            }

        }
    }
}
