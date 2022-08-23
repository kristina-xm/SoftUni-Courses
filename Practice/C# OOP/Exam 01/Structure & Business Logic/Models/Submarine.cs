namespace NavalVessels.Models
{
    using NavalVessels.Models.Contracts;
    using System;
    using System.Collections.Generic;
    public class Submarine : Vessel, ISubmarine
    {
        private double armourThickness = 200;
        private bool submergeMode = false;

        public Submarine(string name, double mainWeaponCaliber, double speed) : base(name, mainWeaponCaliber, speed, 200)
        {

        }

        public bool SubmergeMode => submergeMode;
        public void RepairVessel()
        {
            if (this.ArmorThickness < 200)
            {
                this.ArmorThickness = 200;
            }
        }

        public void ToggleSubmergeMode()
        {
            if (this.SubmergeMode == false)
            {
                submergeMode = true;
                this.MainWeaponCaliber += 40;
                this.Speed -= 4;
            }
            else
            {
                submergeMode = false;
                this.MainWeaponCaliber -= 40;
                this.Speed += 4;
            }
        }

        public override string ToString()
        {
            var text = base.ToString();

            if (this.SubmergeMode == false)
            {
                return $"{text}{Environment.NewLine} *Submerge mode: OFF";
            }
            else
            {
                return $"{text}{Environment.NewLine} *Submerge mode: ON";
            }
        }
    }
}
