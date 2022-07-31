namespace Logger_Exercise.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class IvanlidDateTimeExceptions:Exception
    {
        private const string  DefaultMessage="Provided DateTime was not in the correct format";

        public IvanlidDateTimeExceptions():base(DefaultMessage)
        {

        }
    }
}
