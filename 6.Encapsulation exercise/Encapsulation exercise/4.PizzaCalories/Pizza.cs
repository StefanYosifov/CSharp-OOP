using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _4.PizzaCalories
{
    public class Pizza
    {
        public Pizza()
        {
            toppings = new List<Topping>();
        }

        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.dough = dough;
            this.toppings = new List<Topping>();
        }

        private string name;
        private readonly List<Topping> toppings;
        private Dough dough;

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) && value.Length<1 || value.Length>15)
                {
                    throw new Exception(Error_messages.pizzaInvalidName);
                }
                this.name = value;
            }
        }

        public Topping Topping
        {
            get
            {
                return this.Topping;
            }
            private set
            {
                if (toppings.Count > 10)
                {
                    throw new ArgumentException(Error_messages.pizzaInvalidToppingRange );
                }
            }
        }

        public Dough Dough
        {
            get
            {
                return this.Dough;
            }
            private set
            {
                dough = value;
            }
        }


        public void AddToping(Topping topping)
        {
            toppings.Add(topping);
            if (this.toppings.Count > 15)
            {
                throw new Exception(String.Format(Error_messages.toppingOutOfRange));
            }

        }

        public double CalculateTotalCalories()
        {
            double doughCalories = this.dough.CalculateCalories();
            double toppingCalories = this.toppings.Sum(x => x.CalculateCalories());

            return doughCalories + toppingCalories;
        }
    }
}
