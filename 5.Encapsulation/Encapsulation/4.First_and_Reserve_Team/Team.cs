using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    public class Team
    {
        public Team(string name)
        {
            this.Name = name;
            FirstTeam = new List<Person>();
            ReserveTeam = new List<Person>();
        }

        private string name;
        private List<Person> firstTeam;
        private List<Person> reserveTeam;


        public string Name { get { return name; } private set { name = value; } }
        public IReadOnlyList<Person> FirstTeam
        {
            get { return firstTeam; }
            set { value = firstTeam; }
            
        }

        public IReadOnlyList<Person> ReserveTeam
        {
            get { return reserveTeam;}
            set { value = reserveTeam; }
 
        }

        public void Add(Person person)
        {
            if (person.Age < 40)
            {
                firstTeam.Add(person);
            }
            else
            {
                reserveTeam.Add(person);
            }
        }

        public void FirstTeamCount()
        {
            Console.WriteLine($"First team has {FirstTeam.Count} players.");
        }

        public void ReserveTeamCount()
        {
            Console.WriteLine($"Reserve team has {ReserveTeam.Count} players.");
        }
    }
}
