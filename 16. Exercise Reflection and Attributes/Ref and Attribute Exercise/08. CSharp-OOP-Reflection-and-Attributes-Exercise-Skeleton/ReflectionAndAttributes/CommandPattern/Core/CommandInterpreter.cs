namespace CommandPattern.Core
{
    using CommandPattern.Core.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] commandSplit = args.Split();

            string cmdName = commandSplit[0];
            string[] cmdArgs = commandSplit.Skip(1).ToArray();


            Assembly assembly = Assembly.GetExecutingAssembly();
            Type type = assembly.GetTypes().FirstOrDefault(x=>x.Name == $"{cmdName}Command");
            if (type == null)
            {
                throw new InvalidOperationException($"Provided type does not exist");
            }
            MethodInfo executeMethod = type.GetMethods().FirstOrDefault(m => m.Name == "Execute");
            object commandInstance = Activator.CreateInstance(type);
            string result= (string)executeMethod.Invoke(commandInstance, new object[] {cmdArgs});

            return result;
        }
    }
}
