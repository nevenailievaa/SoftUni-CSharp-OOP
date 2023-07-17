namespace Database.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DatabaseTests
    {
        private Database database;

        [SetUp]
        public void Setup()
        {
            database = new Database(1, 2);
        }

        //Tests//

        [Test]
        public void CreatingDatabaseCountShouldBeCorrect()
        {
            //Arrange
            int actualResult = database.Count;
            int expectedResult = 2;

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void CreatingDatabaseShouldAddElementsCorrectly(int[] data)
        {
            //Arrange
            database = new Database(data);

            //Act
            int[] actualResult = database.Fetch();

            //Assert
            Assert.AreEqual(data, actualResult);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 })]
        public void CreatingDatabaseShouldThrowExceptionWhenCountIsMoreThan16(int[] data)
        {
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
                => database = new Database(data));

            Assert.AreEqual("Array's capacity must be exactly 16 integers!", exception.Message);
        }

        [Test]
        public void DatabaseCountShouldWorkCorrectly()
        {
            //Arrange
            int expectedResult = 2;
            int actualResult = database.Count;

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(-3)]
        [TestCase(10)]
        public void DatabaseAddMethodShouldIncreaseCount(int number)
        {
            //Arrange
            int expectedResult = 3;

            //Act
            database.Add(number);

            //Assert
            Assert.AreEqual(expectedResult, database.Count);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        public void DatabaseAddMethodShouldAddElementsCorrectly(int[] data)
        {
            //Arrange
            database = new Database();

            //Act
            foreach (var number in data)
            {
                database.Add(number);
            }

            //Assert
            Assert.AreEqual(database.Count, data.Length);
        }

        [Test]
        public void DatabaseAddMethodShouldThrowExceptionWhenCountIsMoreThan16()
        {
            //Act
            for (int i = 3; i < 17; i++)
            {
                database.Add(i);
            }

            //Assert
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
            => database.Add(17), "Array's capacity must be exactly 16 integers!");

            Assert.AreEqual(exception.Message, "Array's capacity must be exactly 16 integers!");
        }

        [Test]
        public void DatabaseRemoveMethodShouldDecreaseCount()
        {
            //Arrange
            int expectedCount = 1;

            //Act
            database.Remove();

            //Assert
            Assert.AreEqual(expectedCount, database.Count);
        }

        [Test]
        public void DatabaseRemoveMethodShouldRemoveElementsCorrectly()
        {
            //Arrange
            int[] expectedResult = { 1 };

            //Act
            database.Remove();

            int[] actualResult = database.Fetch();

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void DatabaseRemoveMethodShouldThrowExceptionIfDatabaseIsEmpty()
        {
            //Act
            database.Remove();
            database.Remove();

            //Assert
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(
                () => database.Remove());

            Assert.AreEqual(exception.Message, "The collection is empty!");
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        public void DatabaseFetchMethodShouldReturnCorrectData(int[] data)
        {
            //Arrange
            database = new Database(data);

            //Act
            int[] databaseFetch = database.Fetch();

            //Assert
            Assert.AreEqual(data, databaseFetch);
        }
    }
}