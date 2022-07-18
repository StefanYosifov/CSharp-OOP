using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Models
{
    public class Rogue : BaseHero
    {
        private const int RoguePower = 80;


        
        public Rogue(string name, string type) : base(name, type)
        {
        }

        

        public override int Power
        {
            get
            {
                return RoguePower;
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
