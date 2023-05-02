namespace Logger_Exercise.Layout
{
    using Logger_Exercise.Layout.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class SimpleLayOut : ILayout
    {
        public string Format
        {
            get
            {
                return "{0} - {1} - {2}";
            }
        }

    }
}
