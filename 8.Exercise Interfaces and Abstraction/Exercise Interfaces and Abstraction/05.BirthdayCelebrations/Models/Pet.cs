using System;
using System.Collections.Generic;
using System.Text;

namespace _05.BirthdayCelebrations.Models
{
    using Models.Interfaces;
    public class Pet : IInhabitant,IBirthdate
    {
        public Pet(string name, string birthdate)
        {
            Name = name;
            Birthdate = birthdate;
        }

        public string Name { get; private set; }
        public string Id { get; private set; }

        public string Birthdate { get; private set; }
    }
}
