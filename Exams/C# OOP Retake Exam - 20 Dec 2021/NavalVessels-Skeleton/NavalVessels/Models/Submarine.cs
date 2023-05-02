using NavalVessels.Models.Contracts;

namespace NavalVessels.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Submarine : Vessel, ISubmarine
    {
        private const double InitialArmorThickness = 200;
        private const double IncreaseDecreaseWeaponDamage = 40;
        private const double IncreaseDecreaseSpeed = 4;
        public Submarine(string name, double mainWeaponCaliber, double speed) : base(name, mainWeaponCaliber, speed, InitialArmorThickness)
        {

        }
        private bool submergeMode=false;
        public bool SubmergeMode
        {
            get
            {
                return submergeMode;
            }
             set
            {
                submergeMode = false;
            }
        }

        public override void RepairVessel()
        {
         this.ArmorThickness = InitialArmorThickness;
        }

        public void ToggleSubmergeMode()
        {
            if (SubmergeMode == false)
            {
                MainWeaponCaliber += IncreaseDecreaseWeaponDamage;
                Speed -= IncreaseDecreaseSpeed;
                SubmergeMode = true;
            }
            else
            {
                MainWeaponCaliber -= IncreaseDecreaseWeaponDamage;
                Speed += IncreaseDecreaseSpeed;
                SubmergeMode = false;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            string submergeMode = SubmergeMode ? "ON" : "OFF";
            sb.AppendLine($" *Submerge mode: {submergeMode}");
            return sb.ToString().Trim();
        }
    }
}
