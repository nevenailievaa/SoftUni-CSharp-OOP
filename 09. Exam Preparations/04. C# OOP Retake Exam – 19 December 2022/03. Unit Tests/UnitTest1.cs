namespace UniversityLibrary.Test
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    public class Tests
    {
        //Fields
        private UniversityLibrary library;

        //Tests
        [SetUp]
        public void Setup()
        {
            library = new UniversityLibrary();
        }

        [Test]
        public void ConstructorShouldWorkProperly()
        {
            Assert.IsNotNull(library);

            Type expectedType = typeof(List<TextBook>);
            Type actualType = library.Catalogue.GetType();

            Assert.AreEqual(expectedType, actualType);
        }

        [Test]
        public void AddTextBookToLibraryMethodShouldWorkCorrectly()
        {
            TextBook book = new TextBook("Pride and prejudice", "Jane Austin", "Classics");
            string expectedMessage = library.AddTextBookToLibrary(book);

            Assert.AreEqual(library.Catalogue.Count, 1);
            Assert.AreEqual(book.InventoryNumber, 1);
            Assert.AreEqual(expectedMessage, 
                $"Book: {book.Title} - {book.InventoryNumber}" + Environment.NewLine
                + $"Category: {book.Category}" + Environment.NewLine
                + $"Author: {book.Author}");
        }

        [Test]
        public void LoanTextBookToLibraryMethodShouldWorkCorrectly()
        {
            TextBook bookOne = new TextBook("Pride and prejudice", "Jane Austin", "Classics");
            TextBook bookTwo = new TextBook("Crime and punishment", "Fyodor Dostoevsky", "Classics");
            bookOne.Holder = "Nevena Firkova";

            library.AddTextBookToLibrary(bookOne);
            library.AddTextBookToLibrary(bookTwo);

            string bookOneExpectedMessage = $"Nevena Firkova still hasn't returned {bookOne.Title}!";
            string bookTwoExpectedMessage = $"{bookTwo.Title} loaned to Nevena Firkova.";

            string bookOneActualMessage = library.LoanTextBook(1, "Nevena Firkova");
            string bookTwoActualMessage = library.LoanTextBook(2, "Nevena Firkova");

            Assert.AreEqual(bookOneExpectedMessage, bookOneActualMessage);
            Assert.AreEqual(bookTwoExpectedMessage, bookTwoActualMessage);
            Assert.That(bookTwo.Holder == "Nevena Firkova");
        }

        [Test]
        public void ReturnTextBookMethodShouldWorkCorrectly()
        {
            TextBook book = new TextBook("Pride and prejudice", "Jane Austin", "Classics");
            book.Holder = "Nevena Firkova";
            library.AddTextBookToLibrary(book);

            string expectedMessage = $"{book.Title} is returned to the library.";
            string actualMessage = library.ReturnTextBook(1);

            Assert.AreEqual(expectedMessage, actualMessage);
            Assert.AreEqual(book.Holder, String.Empty);
        }
    }
}