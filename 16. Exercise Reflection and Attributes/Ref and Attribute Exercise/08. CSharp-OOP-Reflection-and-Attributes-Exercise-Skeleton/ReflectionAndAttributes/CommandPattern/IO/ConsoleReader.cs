namespace CommandPattern.IO
{
    using CommandPattern.IO.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            string line=Console.ReadLine();
            return line;
        }
    }
}
