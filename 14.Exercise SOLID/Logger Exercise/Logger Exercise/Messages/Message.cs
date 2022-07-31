namespace Logger_Exercise.Messages
{
    using Logger_Exercise.Enums;
    using Logger_Exercise.Exceptions;
    using Logger_Exercise.Messages.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Message : IMessage
    {

        private const string EmptyArgumentMessage = "Argument cannot be empty, enter something in it";
        private readonly string logTime;
        private readonly string messageText;


        public Message(string dateTime, string messageText)
        {
           this.LogTime = dateTime;
           this.MessageText = messageText;
        }

        public string LogTime {
            get
            {
                return this.logTime;
            }
            
            private set
            {
                if (!IsValidDateTime(value))
                {
                    throw new IvanlidDateTimeExceptions();
                }
                else if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(nameof(LogTime),EmptyArgumentMessage);
                }
            }
        }

        public string MessageText
        {
            get
            {
                return messageText;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(nameof(MessageText), EmptyArgumentMessage);
                }
            }
        }

        public ReportLevel Level { get; }


        private bool IsValidDateTime(string text)
        {
            return DateTime.TryParse(text,out DateTime date);
        }
    }
}
