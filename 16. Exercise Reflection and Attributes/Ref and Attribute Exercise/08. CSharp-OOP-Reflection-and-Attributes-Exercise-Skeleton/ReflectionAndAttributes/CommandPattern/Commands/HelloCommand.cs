namespace CommandPattern.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using CommandPattern.Core.Contracts;

    public class HelloCommand : ICommand
    {
        public string Execute(string[] args)
        {
            return $"Hello, {args[0]}"; 
        }


    }
}
