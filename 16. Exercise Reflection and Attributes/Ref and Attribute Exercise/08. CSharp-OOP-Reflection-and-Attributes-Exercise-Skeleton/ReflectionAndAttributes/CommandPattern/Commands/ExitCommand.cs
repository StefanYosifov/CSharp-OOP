namespace CommandPattern.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using CommandPattern.Core.Contracts;

    public class ExitCommand : ICommand
    {
        public string Execute(string[] args)
        {
            Environment.Exit(0);
            return null;
        }
    }
}
