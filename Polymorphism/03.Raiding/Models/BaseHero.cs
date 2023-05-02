using Raiding.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Models
{
    public abstract class BaseHero : IBaseHero
    {
        
        public BaseHero(string name, string type)
        {
            Name = name;
            Type = type;
        }

        public string Name { get; private set; }

        public string Type { get; private set; }

        public virtual int Power { get;}

        public abstract string CastAbility();
        
    }
}
