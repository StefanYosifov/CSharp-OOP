﻿namespace AquaShop.Models.Aquariums
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class SaltwaterAquarium : Aquarium
    {
        private const int SaltwaterAquariumCapacity = 25;
        public SaltwaterAquarium(string name) 
            : base(name, SaltwaterAquariumCapacity)
        {
        }


    }
}
