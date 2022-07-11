using _7.MilitaryElite.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _7.MilitaryElite.Models
{
    public class Soldier : ISoldier
    {
        public string ID { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }
    }
}
