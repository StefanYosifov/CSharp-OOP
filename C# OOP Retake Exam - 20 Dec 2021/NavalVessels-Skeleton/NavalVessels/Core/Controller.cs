namespace NavalVessels.Core
{
    using NavalVessels.Core.Contracts;
    using NavalVessels.Models;
    using NavalVessels.Models.Contracts;
    using NavalVessels.Repositories;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;
    using NavalVessels.Utilities.Messages;

    public class Controller : IController
    {
        private VesselRepository vessels;
        private ICollection<ICaptain> captains;


        public Controller()
        {
            this.vessels=new VesselRepository();
            this.captains=new List<ICaptain>();
        }

        public string AssignCaptain(string selectedCaptainName, string selectedVesselName)
        {
            ICaptain captain = this.captains.FirstOrDefault(x=>x.FullName==selectedCaptainName);
            IVessel vessel =this.vessels.FindByName(selectedVesselName);

            if (captain == null)
            {
                return string.Format(OutputMessages.CaptainNotFound, selectedCaptainName);
            }
            if (vessel == null)
            {
                return string.Format(OutputMessages.VesselNotFound, selectedVesselName);
            }
            if (vessel.Captain != null)
            {
                return string.Format(OutputMessages.VesselOccupied, selectedVesselName);    
            }
            captains.Add(captain);
            vessel.Captain=captain;
            captain.Vessels.Add(vessel);

            return string.Format(OutputMessages.SuccessfullyAssignCaptain, selectedCaptainName, selectedVesselName);

        }

        public string AttackVessels(string attackingVesselName, string defendingVesselName)
        {
            IVessel firstVessel = vessels.FindByName(attackingVesselName);
            IVessel secondVessel = vessels.FindByName(defendingVesselName);

            if (firstVessel == null)
            {
                return string.Format(OutputMessages.VesselNotFound, attackingVesselName);
            }
            if (secondVessel == null)
            {
                return string.Format(OutputMessages.VesselNotFound, defendingVesselName);
            }

            if (firstVessel.ArmorThickness <= 0)
            {
                return string.Format(OutputMessages.AttackVesselArmorThicknessZero, attackingVesselName);
            }
            if (secondVessel.ArmorThickness <= 0)
            {
                return string.Format(OutputMessages.AttackVesselArmorThicknessZero, defendingVesselName);
            }

            firstVessel.Attack(secondVessel);
            firstVessel.Captain.IncreaseCombatExperience();
            secondVessel.Captain.IncreaseCombatExperience();

            return String.Format(OutputMessages.SuccessfullyAttackVessel, defendingVesselName, attackingVesselName, secondVessel.ArmorThickness);

        }

        public string CaptainReport(string captainFullName)
        {
            ICaptain captain = captains.FirstOrDefault(x => x.FullName == captainFullName);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(captain.Report());
            return sb.ToString().TrimEnd();
        }

        public string HireCaptain(string fullName)
        {
            ICaptain captain = new Captain(fullName);
            if (captains.Any(x => x.FullName == captain.FullName))
            {
                return String.Format(OutputMessages.CaptainIsAlreadyHired, fullName);
            }
            this.captains.Add(captain);
            return String.Format(OutputMessages.SuccessfullyAddedCaptain, fullName);
        }

        public string ProduceVessel(string name, string vesselType, double mainWeaponCaliber, double speed)
        {
            IVessel vessel = null;
            if (vesselType.ToLower() == "battleship".ToLower())
            {
                vessel = new Battleship(name, mainWeaponCaliber, speed);
            }
            else if (vesselType.ToLower()=="Submarine".ToLower())
            {
                vessel = new Submarine(name, mainWeaponCaliber, speed);
            }
            else
            {
                return OutputMessages.InvalidVesselType;
            }

            if (vessels.Models.Any(x => x.Name == vessel.Name))
            {
                return String.Format(OutputMessages.VesselIsAlreadyManufactured, vesselType, name);
            }

            this.vessels.Add(vessel);
            return String.Format(OutputMessages.SuccessfullyCreateVessel, vesselType, name,mainWeaponCaliber,speed);
        }

        public string ServiceVessel(string vesselName)
        {
            IVessel vessel = vessels.FindByName(vesselName);
            if (vessel == null)
            {
                return String.Format(OutputMessages.VesselNotFound, vesselName);
            }
            vessel.RepairVessel();
            return String.Format(OutputMessages.SuccessfullyRepairVessel, vesselName);
        }

        public string ToggleSpecialMode(string vesselName)
        {
            IVessel vessel = vessels.FindByName(vesselName);

            if (vessel.GetType().Name==nameof(Submarine))
            {
                Submarine submarine=vessel as Submarine;
                submarine.ToggleSubmergeMode();
                return string.Format(OutputMessages.ToggleSubmarineSubmergeMode, vesselName);
            }

            else if (vessel.GetType().Name == nameof(Battleship))
            {
                Battleship battleship=vessel as Battleship;
                battleship.ToggleSonarMode();
                return String.Format(OutputMessages.ToggleBattleshipSonarMode, vesselName);
            }


            return String.Format(OutputMessages.VesselNotFound, vesselName);
        }

        public string VesselReport(string vesselName)
        {
            IVessel vessel = vessels.FindByName(vesselName);
            return vessel.ToString().TrimEnd();
        }
    }
}
