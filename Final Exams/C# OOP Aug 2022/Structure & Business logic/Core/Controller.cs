namespace PlanetWars.Core
{
    using PlanetWars.Core.Contracts;
    using PlanetWars.Models.MilitaryUnits;
    using PlanetWars.Models.MilitaryUnits.Contracts;
    using PlanetWars.Models.Planets;
    using PlanetWars.Models.Planets.Contracts;
    using PlanetWars.Models.Weapons;
    using PlanetWars.Models.Weapons.Contracts;
    using PlanetWars.Repositories;
    using PlanetWars.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    public class Controller : IController
    {
        private PlanetRepository planets;

        public Controller()
        {
            planets = new PlanetRepository();
        }

        public string CreatePlanet(string name, double budget)
        {
           
            var planet = new Planet(name, budget);

            if (planets.Models.Any(p => p.Name == name))
            {
                return String.Format(OutputMessages.ExistingPlanet, name);
            }

            planets.AddItem(planet);
            return String.Format(OutputMessages.NewPlanet, name);
        }


        public string AddUnit(string unitTypeName, string planetName)
        {
            IMilitaryUnit militaryUnit = null;

            var planet = planets.FindByName(planetName);

            if (unitTypeName != "SpaceForces" && unitTypeName != "StormTroopers" && unitTypeName != "AnonymousImpactUnit")
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidUnitName, unitTypeName));
            }

            if (planet == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }


            if (planet.Army.Any(u => u.GetType().Name == unitTypeName))
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.UnitAlreadyAdded, unitTypeName, planetName));
            }

            switch (unitTypeName)
            {
                case "SpaceForces":
                    militaryUnit = new SpaceForces();
                    break;
                case "StormTroopers":
                    militaryUnit = new StormTroopers();
                    break;
                case "AnonymousImpactUnit":
                    militaryUnit = new AnonymousImpactUnit();
                    break;
                default:
                    break;
            }

            planet.Spend(militaryUnit.Cost);
            planet.AddUnit(militaryUnit);

            return String.Format(OutputMessages.UnitAdded, unitTypeName, planetName);
        }

        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {

            IWeapon weapon = null;

            var planet = planets.FindByName(planetName);


            if (planet == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            if (planet.Weapons.Any(u => u.GetType().Name == weaponTypeName))
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.WeaponAlreadyAdded, weaponTypeName, planetName));
            }

            if (weaponTypeName != "BioChemicalWeapon" && weaponTypeName != "NuclearWeapon" && weaponTypeName != "SpaceMissiles")
            {
                throw new InvalidOperationException($"{weaponTypeName} still not available!");
            }


            switch (weaponTypeName)
            {
                case "BioChemicalWeapon":
                    weapon = new BioChemicalWeapon(destructionLevel);
                    break;
                case "NuclearWeapon":
                    weapon = new NuclearWeapon(destructionLevel);
                    break;
                case "SpaceMissiles":
                    weapon = new SpaceMissiles(destructionLevel);
                    break;
                default:
                    break;
            }

            planet.Spend(weapon.Price);
            planet.AddWeapon(weapon);

            return String.Format(OutputMessages.WeaponAdded, planetName, weaponTypeName);
        }

        public string SpecializeForces(string planetName)
        {
            var planet = planets.FindByName(planetName);

            if (planet == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            if (planet.Army.Count == 0)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.NoUnitsFound));
            }

            planet.Spend(1.25);

            planet.TrainArmy();

            return String.Format(OutputMessages.ForcesUpgraded, planetName);
        }

        public string SpaceCombat(string planetOne, string planetTwo)
        {
            IPlanet winner = null;
            IPlanet loser = null;

            var planet1 = planets.FindByName(planetOne);
            var planet2 = planets.FindByName(planetTwo);

            bool hasNuclearWeaponP2 = planet2.Army.Any(a => a.GetType().Name == "NuclearWeapon");
            bool hasNuclearWeaponP1 = planet1.Army.Any(a => a.GetType().Name == "NuclearWeapon");

            if (planet1.MilitaryPower == planet2.MilitaryPower)
            {
                if (planet2.Army.Any(a => a.GetType().Name == "NuclearWeapon"))
                {
                    winner = planet2;
                    loser = planet1;

                    winner.Spend(winner.Budget / 2);
                    //loser.Spend(loser.Budget / 2);

                    winner.Profit(loser.Budget / 2);
                    loser.Spend(loser.Budget / 2);

                    winner.Profit(loser.Weapons.Sum(w => w.Price));
                    winner.Profit(loser.Army.Sum(w => w.Cost));

                    planets.RemoveItem(loser.Name);

                    return String.Format(OutputMessages.WinnigTheWar, winner.Name, loser.Name);
                }
                else if (planet1.Army.Any(a => a.GetType().Name == "NuclearWeapon"))
                {
                    winner = planet1;
                    loser = planet2;

                    winner.Spend(winner.Budget / 2);
                    //loser.Spend(loser.Budget / 2);

                    winner.Profit(loser.Budget / 2);
                    loser.Spend(loser.Budget / 2);

                    winner.Profit(loser.Weapons.Sum(w => w.Price));
                    winner.Profit(loser.Army.Sum(w => w.Cost));

                    planets.RemoveItem(loser.Name);

                    return String.Format(OutputMessages.WinnigTheWar, winner.Name, loser.Name);
                }
                else if (hasNuclearWeaponP2 && hasNuclearWeaponP1)
                {
                    planet1.Spend(planet1.Budget / 2);
                    planet2.Spend(planet2.Budget / 2);

                    return String.Format(OutputMessages.NoWinner);
                }
                else if (!hasNuclearWeaponP2 && !hasNuclearWeaponP1)
                {
                    planet1.Spend(planet1.Budget / 2);
                    planet2.Spend(planet2.Budget / 2);

                    return String.Format(OutputMessages.NoWinner);
                }
                else
                {
                    return "";
                }
                
            }
            else if(planet1.MilitaryPower > planet2.MilitaryPower)
            {
                winner = planet1;
                loser = planet2;

                winner.Spend(winner.Budget / 2);
                //loser.Spend(loser.Budget / 2);

                winner.Profit(loser.Budget / 2);
                loser.Spend(loser.Budget / 2);

                winner.Profit(loser.Weapons.Sum(w => w.Price));
                winner.Profit(loser.Army.Sum(w => w.Cost));

                planets.RemoveItem(loser.Name);

                return String.Format(OutputMessages.WinnigTheWar, winner.Name, loser.Name);
            }
            else if(planet1.MilitaryPower < planet2.MilitaryPower)
            {
                winner = planet2;
                loser = planet1;

                winner.Spend(winner.Budget / 2);
                //loser.Spend(loser.Budget / 2);

                winner.Profit(loser.Budget / 2);
                loser.Spend(loser.Budget / 2);

                winner.Profit(loser.Weapons.Sum(w => w.Price));
                winner.Profit(loser.Army.Sum(w => w.Cost));

                planets.RemoveItem(loser.Name);

                return String.Format(OutputMessages.WinnigTheWar, winner.Name, loser.Name);
            }
            else
            {
                return "";
            }
        }

        public string ForcesReport()
        {
            var sb = new StringBuilder();

            sb.AppendLine("***UNIVERSE PLANET MILITARY REPORT***");

            var sortedPlanets = planets.Models.OrderByDescending(x => x.MilitaryPower).ThenBy(x => x.Name);

            foreach (var planet in planets.Models)
            {
                sb.AppendLine(planet.PlanetInfo());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
