namespace Logger_Exercise.Appenders.Interfaces
{
    using Logger_Exercise.Layout.Interfaces;
    using Logger_Exercise.Messages.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public  interface IAppender
    {
        int Count { get; }

        ILayout layout { get; }

        void Append(IMessage imessage);
    }
}
