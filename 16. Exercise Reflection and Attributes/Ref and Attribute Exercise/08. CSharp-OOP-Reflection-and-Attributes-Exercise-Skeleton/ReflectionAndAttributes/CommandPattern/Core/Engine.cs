namespace CommandPattern.Core
{
    using CommandPattern.Core.Contracts;
    using CommandPattern.IO.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;
        private readonly IWriter writer;
        private readonly IReader reader;

        public Engine(ICommandInterpreter commandInterpreter, IReader reader,IWriter writer)
        {
            this.commandInterpreter = commandInterpreter;
            this.reader = reader;
            this.writer=writer;
        }

        public void Run()
        {
            while (true)
            {
                string input = this.reader.ReadLine();
                string result=commandInterpreter.Read(input);
                this.writer.WriteLine(result);
            }
        }
    }
}
