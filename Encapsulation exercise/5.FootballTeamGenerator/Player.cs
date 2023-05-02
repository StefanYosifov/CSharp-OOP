using System;
using System.Collections.Generic;
using System.Text;

namespace _5.FootballTeamGenerator
{
    public class Player
    {
        public Player(string name,Stats stats)
        {
            this.Name = name;
            this.Stats = Stats;
        }


        private string name;




        public string Name 
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ErrorMessages.NameNullExceptionMessage);
                }
                this.name = value;
            }
        
        }

        public Stats Stats { get; private set; }



    }
}
