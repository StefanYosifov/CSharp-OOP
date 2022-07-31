namespace CommandPattern.IO
{
    using CommandPattern.IO.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ConsoleWriter : IWriter
    {
        public void Write(string value)
        {
            Console.Write(value);
        }

        public void WriteLine(string value)
        {
            Console.WriteLine(value);
        }
    }
}
