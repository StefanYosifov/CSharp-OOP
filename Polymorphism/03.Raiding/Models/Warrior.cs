﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Models
{
    public class Warrior : BaseHero
    {
        private const int WarriorPower = 100;
        public Warrior(string name,string type) : base(name, type)
        {
        }

        public override int Power
        {
            get
            {
                return WarriorPower;
            }
           
        }

        public override string CastAbility()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{GetType().Name} - {Name} hit for {Power} damage");
            return sb.ToString().Trim();
        }
    }
}
