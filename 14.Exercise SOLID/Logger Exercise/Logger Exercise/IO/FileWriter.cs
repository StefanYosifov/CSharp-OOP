namespace Logger_Exercise.IO
{
    using Logger_Exercise.IO.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class FileWriter : IFileWriter
    {

        public FileWriter(string filePath)
        {
            this.FilePath = filePath;
        }

        public string FilePath { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void WriteContent(string content,string FileName)
        {
            string output = Path.Combine(this.FilePath, FileName);
            File.WriteAllText(output,content,Encoding.UTF8);
        }
    }
}
