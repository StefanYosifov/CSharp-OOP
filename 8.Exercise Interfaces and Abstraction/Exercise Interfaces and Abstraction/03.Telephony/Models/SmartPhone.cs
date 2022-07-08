using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Telephony.Models
{
    using Interfaces;
    public class SmartPhone : ICallable, IBrowsable
    {
        public string BrowseUrl(string url)
        {
            return $"Browsing... {url}";
        }

        public string Call(string number)
        {
            return $"Calling... {number}";
        }
    }


}
