namespace Gym.Models.Gyms
{
    public class WeightliftingGym : Gym
    {
        private const int numberOfAthletes = 20;
        public WeightliftingGym(string name) : base(name, numberOfAthletes)
        {
        }
    }
}
