namespace Gym.Models.Athletes
{
    using Gym.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Boxer : Athlete
    {

        private const int InitialStamina = 60;
        private const int IncreaseStamina = 15;
        private const int MaxStamina = 100;

        public Boxer(string fullName, string motivation, int numberOfMedals) : base(fullName, motivation, numberOfMedals, InitialStamina)
        {

        }

        public override void Exercise()
        {
            Stamina += IncreaseStamina;
            if (Stamina > MaxStamina)
            {
                Stamina = MaxStamina;
                throw new ArgumentException(ExceptionMessages.InvalidStamina);
            }
        }
    }
}
