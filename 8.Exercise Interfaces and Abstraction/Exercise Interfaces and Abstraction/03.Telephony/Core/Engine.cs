using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Telephony.Core
{
    using IO.Interfaces;
    using Models;
    public class Engine : IEngine
    {

        public Engine()
        {
            this.stationaryPhone = new StationaryPhone();
            this.smartPhone = new SmartPhone();
        }

        public Engine(IReader reader,IWriter writer):this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        private readonly IReader reader;
        private readonly IWriter writer;


        private readonly StationaryPhone stationaryPhone;
        private readonly SmartPhone smartPhone;
        public void Start()
        {
            string[] phoneNumbers = this.reader.ReadLine().Split(' ');
            string[] urls= this.reader.ReadLine().Split(' ');


            foreach(string phone in phoneNumbers)
            {
                if (!this.ValidateCallNumber(phone))
                {
                    this.writer.WriteLine("Invalid number!");
                }
                else if (phoneNumbers.Length == 10)
                {
                    this.smartPhone.Call(phone);
                }
                else if(phoneNumbers.Length == 7)
                {
                    this.stationaryPhone.Call(phone);
                }
            }


            foreach(string url in urls)
            {
                if (this.ValidateUrl(url))
                {
                    this.writer.WriteLine("Invalid url");
                }
                this.writer.WriteLine(this.smartPhone.BrowseUrl(url));
            }

        }


        public bool ValidateCallNumber(string number)
        {
            foreach (var digit in number)
            {
                if (!char.IsDigit(digit))
                {
                    return false;
                }
            }
            return true;
        }

        private bool ValidateUrl(string url)
        {
            foreach(var digit in url)
            {
                if (char.IsDigit(digit))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
