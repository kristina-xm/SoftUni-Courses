using System;

namespace Articles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] article = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            string title = article[0];
            string content = article[1];
            string author = article[2];

            Article newArticle = new Article(title, content, author);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] cmdArgs = Console.ReadLine().Split(": ", StringSplitOptions.RemoveEmptyEntries);

                string command = cmdArgs[0];
                string typeOfCommand = cmdArgs[1];

                if (command == "Edit")
                {
                    string newcontent = typeOfCommand;
                    newArticle.Edit(newcontent);
                }
                else if (command == "ChangeAuthor")
                {
                    string newAuthor = typeOfCommand;
                    newArticle.ChangeAuthor(newAuthor);
                }
                else if (command == "Rename")
                {
                    string newName = typeOfCommand;
                    newArticle.Rename(newName);
                }
            }
            Console.WriteLine(newArticle);
        }
    }
}
