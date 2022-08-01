namespace SpaceStation.Models.Mission
{
    using SpaceStation.Models.Astronauts.Contracts;
    using SpaceStation.Models.Mission.Contracts;
    using SpaceStation.Models.Planets.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
           foreach(var astronaut in astronauts)
            {
                while (planet.Items.Count > 0)
                {
                    var takeItem = planet.Items.ElementAt(0);

                    astronaut.Breath();
                    planet.Items.Remove(takeItem);
                    astronaut.Bag.Items.Add(takeItem);

                    if (astronaut.CanBreath == false)
                    {
                        break;
                    }
                }
            }
        }
    }
}
