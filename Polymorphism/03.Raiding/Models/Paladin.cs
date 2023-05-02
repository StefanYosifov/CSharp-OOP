using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Models
{
    public class Paladin : BaseHero
    {
        private const int PalandinPower = 100;
        public Paladin(string name, string type) : base(name, type)
        {
        }


        public override int Power
        {
            get
            {
                return PalandinPower;
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
