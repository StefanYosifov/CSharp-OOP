using _7.MilitaryElite.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _7.MilitaryElite.Models
{
    public class Private:ISoldier
    {

        public Private(string firstName,string lastName,decimal salary)
        {
            
            Salary = salary;
        }

        public decimal Salary { get; private set; }

        public string ID {get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }
    }
}
