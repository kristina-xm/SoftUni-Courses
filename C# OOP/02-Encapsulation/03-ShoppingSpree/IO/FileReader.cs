namespace ShoppingSpree.IO
{
    using ShoppingSpree.IO.Interfaces;
    using System.IO;
    using System.Linq;

    public class FileReader : IReader
    {
        private readonly string[] allLines;
        private int lineNum;

        public FileReader(string filePath)
        {
            this.FilePath = filePath;
            this.allLines = File.ReadAllLines(filePath);
            this.lineNum = 0;
        }

        public string FilePath { get; set; }

        public string ReadLine()
        {
            if (!this.HasMoreLines())
            {
                return null;
            }

            return this.allLines
                .Skip(lineNum)
                .Take(1)
                .First();
        }

        private bool HasMoreLines()
            => this.lineNum < allLines.Length - 1;
    }
}
