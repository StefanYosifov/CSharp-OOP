using System;
using System.Collections.Generic;
using System.Text;

namespace Animals.Models
{
    public class Cat:Animals
    {
        public Cat(string name,string favouriteFood):base(name,favouriteFood)
        {

        }

        public override string ExplainSelf()
        {
            StringBuilder sb=new StringBuilder();
            sb.AppendLine($"I am {this.Name} and my favourite food is {this.FavouriteFood} MEEOW");
            return sb.ToString().Trim();
        }
    }
}
