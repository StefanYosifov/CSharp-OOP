using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Beverage:Product
    {

        public Beverage(string name,decimal price,double millimeters):base(name,price)
        {
            this.Millimeters = millimeters;
        }

        public double Millimeters { get; set; }

    }
}
