namespace Gym.Models.Equipment
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class BoxingGloves : Equipment
    {
        private const double BoxingGlovesWeight = 227;
        private const decimal BoxingGlovesPrice = 120;


        public BoxingGloves() : base(BoxingGlovesWeight, BoxingGlovesPrice)
        {
        }



    }
}
