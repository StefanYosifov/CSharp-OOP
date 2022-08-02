namespace Gym.Models.Equipment
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Kettlebell : Equipment
    {
        private const double KettlebellWeight = 10000;
        private const decimal KettlebellPrice = 80;

        public Kettlebell() : base(KettlebellWeight, KettlebellPrice)
        {
        }
    }
}
