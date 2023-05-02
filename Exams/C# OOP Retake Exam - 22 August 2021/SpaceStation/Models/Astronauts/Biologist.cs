namespace SpaceStation.Models.Astronauts
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Biologist : Astronaut
    {
        private const int DecreaseOxygenBy = 5;
        private const int OxygenLevel = 70;

        public Biologist(string name) : base(name, OxygenLevel)
        {

        }


        public override void Breath()
        {
            if (this.Oxygen - DecreaseOxygenBy >= 0)
            {
                base.Oxygen -= 5;
            }
            else
            {
                base.Oxygen = 0;
            }
        }

    }
}
