using System;
using System.Collections.Generic;
using System.Text;

namespace Animals.Models
{
    public class Dog:Animals
    {
        public Dog(string name,string favouriteFood):base(name,favouriteFood)
        {

        }


        public override string ExplainSelf()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"I am {this.Name} and my favourite food is {this.FavouriteFood} DJAAF");
            return sb.ToString().Trim();
        }

    }
}
