namespace Gym.Models.Equipment
{
    using Gym.Models.Equipment.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Equipment : IEquipment
    {

        public Equipment(double weight, decimal price)
        {
            this.Weight = weight;
            this.Price = price;
        }

        private double weight;
        private decimal price;


        public double Weight
        {
            get
            {
                return this.weight;
            }
            private set
            {
                this.weight = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            private set
            {
                this.price = value;
            }
        }
    }
}
