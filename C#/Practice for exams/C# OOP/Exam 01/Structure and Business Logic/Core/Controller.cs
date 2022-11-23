namespace NavalVessels.Core
{
    using NavalVessels.Core.Contracts;
    using NavalVessels.Models;
    using NavalVessels.Models.Contracts;
    using NavalVessels.Repositories;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Controller : IController
    {
        private VesselRepository vessels;
        private List<ICaptain> captains;

        public Controller()
        {
            vessels = new VesselRepository();
            captains = new List<ICaptain>();
        }


        public string HireCaptain(string fullName)
        {
            var captain = new Captain(fullName);

            if (captains.Any(c => c.FullName == fullName))
            {
                return $"Captain {fullName} is already hired.";
            }

            captains.Add(captain);
            return $"Captain {fullName} is hired.";
        }

        public string ProduceVessel(string name, string vesselType, double mainWeaponCaliber, double speed)
        {
            IVessel vessel = null;

            if (vessels.Models.Any(v => v.Name == name))
            {
                return $"{vesselType} vessel {name} is already manufactured.";
            }

            if (vesselType != "Submarine" && vesselType != "Battleship")
            {
                return "Invalid vessel type.";
            }

            if (vesselType == "Submarine")
            {
                vessel = new Submarine(name, mainWeaponCaliber, speed);
            }
            else if (vesselType == "Battleship")
            {
                vessel = new Battleship(name, mainWeaponCaliber, speed);
            }

            vessels.Add(vessel);

            return $"{vesselType} {name} is manufactured with the main weapon caliber of {mainWeaponCaliber} inches and a maximum speed of {speed} knots.";
        }

        public string AssignCaptain(string selectedCaptainName, string selectedVesselName)
        {
            var captain = captains.FirstOrDefault(c => c.FullName == selectedCaptainName);
            var vessel = vessels.FindByName(selectedVesselName);

            if (captain == null)
            {
                return $"Captain {selectedCaptainName} could not be found.";
            }

            if (vessel == null)
            {
                return $"Vessel {selectedVesselName} could not be found.";
            }

            if (vessel.Captain != null)
            {
                return $"Vessel {selectedVesselName} is already occupied.";
            }

            captain.AddVessel(vessel);
            vessel.Captain = captain;

            return $"Captain {selectedCaptainName} command vessel {selectedVesselName}.";
        }

        public string AttackVessels(string attackingVesselName, string defendingVesselName)
        {
            var attackingVessel = vessels.Models.FirstOrDefault(x => x.Name == attackingVesselName);

            var defendingVessel = vessels.Models.FirstOrDefault(x => x.Name == defendingVesselName);

            if (attackingVessel == null)
            {
                return $"Vessel {attackingVesselName} could not be found.";
            }  
            else if (defendingVessel == null)
            {
                return $"Vessel {defendingVesselName} could not be found.";
            }  

            if (attackingVessel.ArmorThickness == 0)
            {
                return $"Unarmored vessel {attackingVesselName} cannot attack or be attacked.";
            }
            else if (defendingVessel.ArmorThickness == 0)
            {
                return $"Unarmored vessel {defendingVesselName} cannot attack or be attacked.";
            }

            attackingVessel.Attack(defendingVessel);
            attackingVessel.Captain.IncreaseCombatExperience();
            defendingVessel.Captain.IncreaseCombatExperience();

            return $"Vessel {defendingVesselName} was attacked by vessel {attackingVesselName} - current armor thickness: {defendingVessel.ArmorThickness}.";

        }

        public string CaptainReport(string captainFullName)
        {
            var captain = captains.FirstOrDefault(c => c.Vessels.Count > 0 && c.FullName == captainFullName);
            
            return captain.Report();
        }

        public string ServiceVessel(string vesselName)
        {
            var vessel = vessels.Models.FirstOrDefault(x => x.Name == vesselName);

            if (vessel == null)
            {
                return $"Vessel {vesselName} could not be found.";
            }

            vessel.RepairVessel();
            return $"Vessel {vesselName} was repaired.";
        }

        public string ToggleSpecialMode(string vesselName)
        {
            var vessel = vessels.Models.FirstOrDefault(x => x.Name == vesselName);

            if (vessel == null)
            {
                return $"Vessel {vesselName} could not be found.";
            }
            if (vessel.GetType().Name == "Battleship")
            {
                Battleship currVesselType = (Battleship)(vessels.Models.FirstOrDefault(x => x.Name == vesselName));

                currVesselType.ToggleSonarMode();

                return $"Battleship {vesselName} toggled sonar mode.";
            }
            else
            {
                Submarine currVesselType = (Submarine)(vessels.Models.FirstOrDefault(x => x.Name == vesselName));

                currVesselType.ToggleSubmergeMode();

                return $"Submarine {vesselName} toggled submerge mode.";
            }
  
        }

        public string VesselReport(string vesselName)
        {
            var vessel = vessels.Models.FirstOrDefault(x => x.Name == vesselName);

            return vessel.ToString();
        }
    }
}
