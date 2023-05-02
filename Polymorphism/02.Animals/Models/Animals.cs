using System;
using System.Collections.Generic;
using System.Text;

namespace Animals.Models
{
    using Interfaces;
    public abstract class Animals : IAnimal
    {

        public Animals(string name,string favouriteFood)
        {
            this.Name = name;
            this.FavouriteFood = favouriteFood;
        }
        

        private string name;
        private string favouriteFood;

        public string Name 
        {
            get { return this.name; }
            private set { this.name = value; }
        }


        public string FavouriteFood
        {
            get { return this.favouriteFood; }
            private set { this.favouriteFood = value; }

        }

        public abstract string ExplainSelf();
        
       
        
    }
}
