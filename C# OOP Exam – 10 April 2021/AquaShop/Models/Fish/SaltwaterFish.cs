namespace AquaShop.Models.Fish
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class SaltwaterFish : Fish
    {
        private const int FishSize = 5;
        private const int IncreaseSize = 2;

        public SaltwaterFish(string name, string species, decimal price) : base(name, species, price)
        {
            this.Size = FishSize;
        }

        public override void Eat()
        {
            this.Size += IncreaseSize;
        }
    }
}
