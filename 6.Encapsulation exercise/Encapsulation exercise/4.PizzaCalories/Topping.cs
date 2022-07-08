using System;
using System.Collections.Generic;
using System.Text;

namespace _4.PizzaCalories
{
    public class Topping
    {

        private string topping;
        private double grams;


        private double meatCalories = 1.2;
        private double veggiesCalories = 0.8;
        private double cheeseCalories = 1.1;
        private double sauceCalories = 0.9;

        
        public string ToppingIngredient
        {
            get
            {
                return this.topping;
            }
            private set
            {
                if(value!="Meat" && value!="Veggies" && value!="Cheese" && value != "Sauce")
                {
                    throw new Exception(string.Format(Error_messages.toppingInvalid, nameof(value)));
                }
                this.topping = value;
            }
        }
        public double Grams
        {
            get
            {
                return this.grams;

            }
            private set
            {
                if(value<0 || value > 50)
                {
                    throw new Exception(string.Format(Error_messages.toppingOutOfRange, nameof(value)));
                }
                this.grams = value;
            }
        }

        public double CalculateCalories()
        {
            if (ToppingIngredient == "Meat")
            {
                return meatCalories * Grams;
            }
            else if (ToppingIngredient == "Veggies")
            {
                return veggiesCalories * Grams;
            }
            else if (ToppingIngredient == "Cheese")
            {
                return cheeseCalories * grams;
            }
            return sauceCalories * grams;
        }
    }

}
