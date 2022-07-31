﻿namespace NavalVessels.Models
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

        public Battleship(string name, double mainWeaponCaliber, double speed) : base(name, mainWeaponCaliber, speed, InitialArmorThickness)
        {
             
        }   


        private bool sonarMode;

        public bool SonarMode
        {
            get
            {
                return this.sonarMode;
            }
            protected set
            {
                this.sonarMode = false;
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
                this.SonarMode = true;
                this.Speed -= IncreaseDeacresSpeed;
            }
            else
            {
                this.MainWeaponCaliber -= IncreadeDeacreasWeaponDamage;
                this.SonarMode = false;
                this.Speed += IncreaseDeacresSpeed;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(base.ToString());
            string sonarOnOrOff = this.SonarMode ? "ON" : "OFF";
            sb.AppendLine($" *Sonar mode: {sonarOnOrOff}");
            return sb.ToString().Trim();
        }
    }
}
