using System;
using System.Collections.Generic;
using System.Text;

namespace _06.FoodShortage.Models
{
    using Models.Interfaces;
    public class Rebel : IInhabitant, IBuyer
    {

        public Rebel(string name,string Id, string group)
        {
            this.Name = name;
            this.Id = Id;
            this.Group = group;
        }
        public string Name { get; private set; }
        public string Id { get;private set; }

        public int Food { get; private set; } = 0;

        public string Group { get; private set; }

       
        public void BuyFood()
        {
            Food += 5;
        }
    }
}
