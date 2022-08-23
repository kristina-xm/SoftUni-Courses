namespace SpaceStation.Models.Mission
{
    using SpaceStation.Models.Astronauts.Contracts;
    using SpaceStation.Models.Mission.Contracts;
    using SpaceStation.Models.Planets;
    using SpaceStation.Models.Planets.Contracts;
    using System.Collections.Generic;

    public class Mission : IMission
    {
        public Mission()
        {

        }
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            List<string> removedFromPlanet = new List<string>();

            foreach (var astronaut in astronauts)
            {
                if (!astronaut.CanBreath || planet.Items.Count == 0)
                {
                    continue;
                }

                foreach (var item in planet.Items)
                {
                    astronaut.Bag.Items.Add(item);
                    astronaut.Breath();
                    removedFromPlanet.Add(item);

                    if (!astronaut.CanBreath)
                    {
                        break;
                    }
                }

                for (int i = 0; i < removedFromPlanet.Count; i++)
                {
                    planet.Items.Remove(removedFromPlanet[i]);

                    if (planet.Items.Count == 0)
                    {
                        break;
                    }
                }

                removedFromPlanet = new List<string>();
            }
        }
    }
}
