namespace Logger_Exercise.Appenders
{
    using Logger_Exercise.Appenders.Interfaces;
    using Logger_Exercise.Layout.Interfaces;
    using Logger_Exercise.Messages.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ConsoleAppender : IAppender
    {

        public ConsoleAppender()
        {

        }

        public int Count { get; private set; }

        public ILayout layout { get; }

        public void Append(IMessage imessage)
        {
            string formattedMessage = this.FormatMessage(imessage);
            Console.WriteLine(formattedMessage);
        }

        private string FormatMessage(IMessage message)
        {
            return String.Format(this.layout.Format,message.LogTime,message.Level.ToString(),message.MessageText);
        }
    }
}
