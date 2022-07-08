using System;

namespace _03.Telephony
{
    using IO;
    using IO.Interfaces;
    using Core;
    public class Program
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();


            IEngine engine = new Engine(reader,writer);
            engine.Start();
        }
    }
}
