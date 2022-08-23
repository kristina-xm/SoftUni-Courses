namespace NavalVessels.Models
{
    using NavalVessels.Models.Contracts;
    using System;


    public class Battleship : Vessel, IBattleship
    {
        private double armorThickness = 300;
        private bool sonarMode = false;

        public Battleship(string name, double mainWeaponCaliber, double speed) : base(name, mainWeaponCaliber, speed, 300)
        {

        }

        public bool SonarMode => sonarMode;

        public void RepairVessel()
        {
            if (this.ArmorThickness < 300)
            {
                this.ArmorThickness = 300;
            }
        }

        public void ToggleSonarMode()
        {
            if (this.SonarMode == false)
            {
                sonarMode = true;
                this.MainWeaponCaliber += 40;
                this.Speed -= 5;
            }
            else
            {
                sonarMode = false;
                this.MainWeaponCaliber -= 40;
                this.Speed += 5;
            }
        }

        public override string ToString()
        {
            var text = base.ToString();
           
            if (this.SonarMode == false)
            {
                return $"{text}{Environment.NewLine} *Sonar mode: OFF";
            }
            else 
            {
                return $"{text}{Environment.NewLine} *Sonar mode: ON";
            }
           
        }
    }
}
