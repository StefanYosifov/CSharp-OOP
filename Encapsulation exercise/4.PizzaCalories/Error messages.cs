using System;
using System.Collections.Generic;
using System.Text;

namespace _4.PizzaCalories
{
    public static class Error_messages
    {

        public const string doughRange = "Dough weight should be in the range[1..200].";
        public const string doughIncorrectType = "Invalid type of dough.";

        public const string toppingInvalid = "Cannot place {0} on top of your pizza.";
        public const string toppingOutOfRange = "{0} weight should be in the range [1..50].";


        public const string pizzaInvalidName = "Pizza name should be between 1 and 15 symbols.";
        public const string pizzaInvalidToppingRange = "Number of toppings should be in range [0..10].";

    }
}
