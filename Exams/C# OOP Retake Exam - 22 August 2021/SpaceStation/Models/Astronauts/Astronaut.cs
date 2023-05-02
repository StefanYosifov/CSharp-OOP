namespace SpaceStation.Models.Astronauts
{
    using SpaceStation.Models.Astronauts.Contracts;
    using SpaceStation.Models.Bags;
    using SpaceStation.Models.Bags.Contracts;
    using SpaceStation.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Astronaut : IAstronaut
    {

        private const int decreaseOxygenBy = 10;

        public Astronaut(string name,double oxygen)
        {
            this.Name = name;
            this.Oxygen = oxygen;
            this.bag = new Backpack();
        }

        private string name;
        private double oxygen;
        private IBag bag;
         


        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidAstronautName);
                }
                this.name = value;
            }
        }


        public double Oxygen
        {
            get
            {
                return this.oxygen;
            }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidOxygen);
                }
                this.oxygen = value;
            }
        }

        public bool CanBreath
        {
            get
            {
                return Oxygen > 0;
            }
        }

        public IBag Bag
        {
            get
            {
                return this.bag;
            }
        }

 

        public virtual void Breath()
        {
            this.Oxygen -= decreaseOxygenBy;
            if (this.Oxygen < 0)
            {
                this.Oxygen = 0;
            }
        }
    }
}
