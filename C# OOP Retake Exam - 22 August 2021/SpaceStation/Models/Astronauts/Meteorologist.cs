namespace SpaceStation.Models.Astronauts
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Meteorologist:Astronaut
    {
        private const int OxygenLevel = 90;
        public Meteorologist(string name) : base(name, OxygenLevel)
        {

        }
    }
}
