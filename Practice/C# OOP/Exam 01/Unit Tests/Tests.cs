namespace Book.Tests
{
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;

    [TestFixture]
    public class Tests
    {
        [Test]
        public void ConstructorWorksProperly()
        {
            string bookName = "War and peace";
            string author = "Tolstoy";

            Book expectedBook = new Book("War and peace", "Tolstoy");
            Book actualBook = new Book(bookName, author);


            Assert.AreEqual(expectedBook.BookName, actualBook.BookName);
            Assert.AreEqual(expectedBook.Author, actualBook.Author);
            Assert.AreEqual(expectedBook.FootnoteCount, actualBook.FootnoteCount);
        }

        [Test]
        public void CountOfFootnotes()
        {
            Book book = new Book("War and peace", "Tolstoy");

            book.AddFootnote(17, "Text");
            book.AddFootnote(47, "Text2");

            Assert.AreEqual(2, book.FootnoteCount);
        }

        [Test]

        public void BookNameThrowExceptionIfNameIsNullOrEmpty()
        {
            string bookName = string.Empty;
            string author = "Tolstoy";
            string bookName2 = null;
            string author2 = "Vazov";

            Assert.Throws<ArgumentException>(() =>
            {
                Book book = new Book(bookName, author);
                Book book2 = new Book(bookName2, author2);

            });
        }

        [Test]
        public void AuthorNameThrowsExceptionWhenEmptyOrNull()
        {
            string bookName = "War and Peace";
            string author = string.Empty;
            string bookName2 = "Pod Igoto";
            string author2 = null;

            Assert.Throws<ArgumentException>(() =>
            {
                Book book = new Book(bookName, author);
                Book book2 = new Book(bookName2, author2);

            });
        }

        [Test]

        public void ExceptionWhenAddTheSameFootNote()
        {
            Book book = new Book("War and peace", "Tolstoy");

            book.AddFootnote(17, "Text");

           Assert.Throws<InvalidOperationException>(() =>
           {
               book.AddFootnote(17, "Text2");
           });

        }

        [Test]
        public void FindFootNoteWorksProperly()
        {
            Book book = new Book("War and peace", "Tolstoy");

            var footNote1 = new Dictionary<int, string>();
            footNote1.Add(17, "Text");

            var footNote2 = new Dictionary<int, string>();
            footNote1.Add(18, "Text2");

            var footNote3 = new Dictionary<int, string>();
            footNote1.Add(118, "Text84");
            
            book.AddFootnote(17, "Text");
            book.AddFootnote(18, "Text2");
            book.AddFootnote(118, "Text84");

            var text = book.FindFootnote(18);

            Assert.AreEqual("Footnote #18: Text2", text);
        }

        [Test]
        public void TestForInvalidFootnoteNotExisting()
        {
            Book book = new Book("War and peace", "Tolstoy");

            book.AddFootnote(17, "Text");
            book.AddFootnote(18, "Text2");
            book.AddFootnote(118, "Text84");

            Assert.Throws<InvalidOperationException>(() =>
            {
                var text = book.FindFootnote(28);
            });
        }

        [Test]
        public void AlterFootnoteWorksProperly()
        {
            Book book = new Book("War and peace", "Tolstoy");

            book.AddFootnote(17, "Text");
            string firstText = book.FindFootnote(17);

            book.AlterFootnote(17, "Text17");

            string secondText = book.FindFootnote(17);

            var text = book.FindFootnote(17);

            Assert.AreEqual("Footnote #17: Text17", text);

        }

        [Test]
        public void ExceptionForNotExistingFootnote()
        {
            Book book = new Book("War and peace", "Tolstoy");

            book.AddFootnote(17, "Text");
            book.AddFootnote(18, "Text2");
            book.AddFootnote(118, "Text84");

            Assert.Throws<InvalidOperationException>(() =>
            {
                book.AlterFootnote(28, "NewText");
            });
        }
    }
}