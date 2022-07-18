namespace Raiding
{
    using Raiding.Core;
    using System;
    public class StartUp
    {
        static void Main()
        {
            IEngine engine = new Engine();
            engine.Start();
        }
    }
}
