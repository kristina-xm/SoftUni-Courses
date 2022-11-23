namespace Telephony.IO
{
    using System;
    using System.IO;
    using System.Linq;
    using Telephony.IO.Interfaces;

    public class FileReader : IReader
    {

        private readonly string[] allLines;
        private int lineNum;

        public string FilePath { get; set; }
        public FileReader(string filePath)
        {
            this.FilePath = filePath;
            this.allLines = File.ReadAllLines(filePath);
            this.lineNum = 0;
        }

        public string ReadLine()
        {
            if (!this.HasMoreLines())
            {
                return null;
            }

            return this.allLines.Skip(lineNum).Take(1).First();
        }
        private bool HasMoreLines()
            => this.lineNum < allLines.Length - 1;
    }
}
