﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters
{
    public class Hero
    {
        public Hero(string userName, int level)
        {
            UserName = userName;
            Level = level;
        }

        public string UserName { get; set; }

        public int Level { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Type: {this.GetType().Name} Username: {this.UserName} Level: {this.Level}");
            return sb.ToString();
        }
    }
}
