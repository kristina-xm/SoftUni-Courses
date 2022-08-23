namespace CarRacing.Models.Maps
{
    using CarRacing.Models.Maps.Contracts;
    using CarRacing.Models.Racers;
    using CarRacing.Models.Racers.Contracts;

    public class Map : IMap
    {
        public Map()
        {

        }
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            var map = new Map();

            if (!racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                return "Race cannot be completed because both racers are not available!";
            }
            else if (!racerOne.IsAvailable())
            {
                return $"{racerTwo.Username} wins the race! {racerOne.Username} was not available to race!";
            }
            else if (!racerTwo.IsAvailable())
            {
                return $"{racerOne.Username} wins the race! {racerTwo.Username} was not available to race!";
            }
            
            racerOne.Race();
            racerTwo.Race();

            double racerOneChance = map.CalculateChanceForWinning((Racer)racerOne);
            double racerTwoChance = map.CalculateChanceForWinning((Racer)racerTwo);

            if (racerOneChance > racerTwoChance)
            {
                return $"{racerOne.Username} has just raced against {racerTwo.Username}! {racerOne.Username} is the winner!";
            }
            else
            {
                return $"{racerOne.Username} has just raced against {racerTwo.Username}! {racerTwo.Username} is the winner!";
            }
        }

        public double CalculateChanceForWinning(Racer racer)
        {
            double chance = 0;
            double multiplier = 0;

            if (racer.RacingBehavior == "strict")
            {
                multiplier = 1.2;
            }
            else if (racer.RacingBehavior == "aggressive")
            {
                multiplier = 1.1;
            }

            return chance = racer.Car.HorsePower * racer.DrivingExperience * multiplier;
        }
    }
}
