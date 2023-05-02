using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Exceptions
{
    public class FoodNotPreferedException:Exception
    {
        

        public FoodNotPreferedException(string message):base(message)
        {

        }

    }
}
