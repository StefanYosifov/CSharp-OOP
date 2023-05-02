using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Models
{
    public class Druid : BaseHero
    {

        private const int DruidPower = 80;
        public Druid(string name, string type) : base(name, type)
        {
          
        }

        public override int Power
        {
            get
            {
                return DruidPower;
            }
        }

        public override string CastAbility()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{GetType().Name} - {Name} healed for {Power}");
            return sb.ToString().Trim();
        }

    }
}
