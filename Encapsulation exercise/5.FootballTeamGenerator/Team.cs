namespace _5.FootballTeamGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    public class Team
    {
        public Team()
        {
            players = new List<Player>();
        }

        public Team(string name)
            :this()
        {
            this.Name = name;
        }


        private string name;
        private readonly List<Player> players;
        public string Name
        {
            get {
                return this.name;
                    }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ErrorMessages.NameNullExceptionMessage));
                }
                this.name = value;  
            }
        }
        
        public int Rating
        {
            get
            {
                return (int)Math.Round(this.players.Average(x => x.Stats.GetOverallStats()),0);
            }
        }

        public void AddPlayer(Player player)
        {
            this.players.Add(player);
        }

        public void RemovePlayer(string playerName)
        {
           Player player=this.players.FirstOrDefault(x=>x.Name==playerName);
            if (player == null)
            {
                throw new ArgumentException(string.Format(ErrorMessages.PlayerNotInTeam,playerName,this.Name));
            }
            this.players.Remove(player);
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Name} - {this.Rating}");
            return sb.ToString().TrimEnd();
        }
    }
}
