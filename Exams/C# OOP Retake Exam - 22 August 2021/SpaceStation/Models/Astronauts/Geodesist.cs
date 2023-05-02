namespace SpaceStation.Models.Astronauts
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Geodesist : Astronaut
    {
        private const int OxygenLevel = 50;

        public Geodesist(string name) : base(name, OxygenLevel)
        {

        }
    }
}
