namespace AquaShop.Models.Decorations
{
    using AquaShop.Models.Decorations.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;


    public abstract class Decoration : IDecoration
    {
        public Decoration(int comfort,decimal price)
        {
            this.Comfort = comfort;
            this.Price = price;
        }


        private int comfort;
        private decimal price;


        public int Comfort
        {
            get => this.comfort;
            private set
            {
                this.comfort = value;
            }
        }

        public decimal Price
        {
            get => this.price;
            private set
            {
                this.price = value;
            }
        }
    }
}
