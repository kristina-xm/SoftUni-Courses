using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Articles
{
    public class Article
    {
        public Article(string title, string content, string author)
        {
            this.Title = title;
            this.Content = content;
            this.Author = author;
        }

        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public string Edit(string newContent)
        {
            return this.Content = newContent;
        }

        public string ChangeAuthor(string newAuthor)
        {
            return this.Author = newAuthor;
        }

        public string Rename(string newTitle)
        {
            return this.Title = newTitle;
        }

        public override string ToString()
        {
            return $"{this.Title} - {this.Content}: {this.Author}";
        }
    }
}
