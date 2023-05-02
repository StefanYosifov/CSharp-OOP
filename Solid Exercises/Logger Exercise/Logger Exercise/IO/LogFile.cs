namespace Logger_Exercise.IO
{
    using Logger_Exercise.IO.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class LogFile : ILogFile
    {
        private readonly StringBuilder sbContent;
        private readonly IFileWriter fileWriter;
        public LogFile()
        {
            this.sbContent = new StringBuilder();
           
        }

        public ulong Size
        {
            get { return (ulong)sbContent.Length; }
        }

        public string Content
        {
            get => sbContent.ToString();
        }

        public void SaveAs(string filename)
        {
            
        }

        public void Write(string content)
        {
            this.sbContent.AppendLine(content);
        }
    }
}
