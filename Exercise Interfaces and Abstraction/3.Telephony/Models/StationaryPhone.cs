using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Telephony.Models
{
    using Interfaces;
    public class StationaryPhone : ICallable
    {
        public string Call(string number)
        {
           
            return $"Dialing... {number}";
        }




       
    }

   
}
