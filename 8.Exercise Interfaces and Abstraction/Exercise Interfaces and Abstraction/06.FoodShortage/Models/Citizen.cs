using System;
using System.Collections.Generic;
using System.Text;

namespace _06.FoodShortage.Models
{
    using Models.Interfaces;
    public class Citizen : IInhabitant, IBuyer
    {
        public Citizen(string name,int age,string id,string birthdate)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthdate = birthdate;
            
        }
        public string Name { get; private set; }

        public int Age { get; private set; }
        public string Id {get;private set;}

        public int Food { get; private set; } = 0;

        public string Birthdate { get; private set; }

        public void BuyFood()
        {
            Food += 10;
        }
    }
}
