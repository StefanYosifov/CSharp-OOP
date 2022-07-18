using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models.Foods
{
    public abstract class FoodNotPrefered
    {
        public FoodNotPrefered(int quantity)
        {
            Quantity = quantity;
        }

        public int Quantity { get; private set; }
    }
}
