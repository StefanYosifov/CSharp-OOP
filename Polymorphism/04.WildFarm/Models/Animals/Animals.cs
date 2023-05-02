using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WildFarm.Models.Foods;


namespace WildFarm.Models.Animals
{

    using Exceptions;
    public abstract class Animals
    {

        public string Name { get; }

        public double Weight { get; protected set; }

        public int FoodEaten { get; protected set; }

        protected virtual IReadOnlyCollection<Type> preferedFoods { get;  set; }

        protected abstract double WeightMultiplier { get; }

        public abstract string ProduceSound();

       
        
    }
}
