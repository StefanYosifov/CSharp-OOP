namespace NavalVessels.Models
{
    using NavalVessels.Models.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Battleship : Vessel,IBattleship
    {
        private const double InitialArmorThickness = 300;
        private const double IncreadeDeacreasWeaponDamage = 40;
        private const double IncreaseDeacresSpeed = 5;

        public Battleship(string name, double mainWeaponCaliber, double speed)
            : base(name, mainWeaponCaliber, speed, InitialArmorThickness)
        {
             
        }   


        private bool sonarMode=false;

        public bool SonarMode
        {
            get
            {
                return this.sonarMode;
            }
            
        }

        public override void RepairVessel()
        {
            this.ArmorThickness = InitialArmorThickness;
            
        }

        public void ToggleSonarMode()
        {
            if (this.SonarMode == false)
            {
                this.MainWeaponCaliber += IncreadeDeacreasWeaponDamage;
                this.sonarMode = true;
                this.Speed -= IncreaseDeacresSpeed;
            }
            else
            {
                this.MainWeaponCaliber -= IncreadeDeacreasWeaponDamage;
                this.sonarMode = false;
                this.Speed += IncreaseDeacresSpeed;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            string sonarOnOrOff = this.SonarMode  ? "ON" : "OFF";
            sb.AppendLine($" *Sonar mode: {sonarOnOrOff}");
            return sb.ToString().Trim();
        }
    }
}
