namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Database database;
        private Person personOne = new Person(24242424, "Peter");
        private Person personTwo = new Person(53535353, "Jacob");
        private Person personThree = new Person(89898989, "Anna");

        [SetUp]
        public void Setup()
        {
            database = new Database();
        }

        //Tests//

        [TestCase(24242424, "Peter")]
        [TestCase(53535353, "Jacob")]
        [TestCase(89898989, "Anna")]
        public void PersonShouldBeInitializedCorrectrly(long id, string userName)
        {
            //Arrange
            long expextedId = id;
            string expectedUserName = userName;

            //Act
            Person person = new Person(id, userName);

            //Assert
            Assert.AreEqual(expextedId, person.Id);
            Assert.AreEqual(expectedUserName, person.UserName);
        }

        [Test]
        public void DatabaseConstructorShouldWorkProperly()
        {
            //Arrange
            Person[] people = new Person[] { personOne, personTwo, personThree};

            //Act
            Database database = new Database(people);

            //Assert
            Assert.AreEqual(people.Length, database.Count);
        }

        [Test]
        public void AddRangeShouldReturnExceptionIfLengthIsMoreThan16()
        {
            //Arrange
            Person[] people = new Person[] { personOne, personTwo, personThree, personOne, personTwo, personThree, personOne, personTwo, personThree, personOne, personTwo, personThree, personOne, personTwo, personThree, personOne, personTwo, personThree };

            //Assert
            ArgumentException exception = Assert.Throws<ArgumentException>(
                () => new Database(people));

            Assert.AreEqual(exception.Message, "Provided data length should be in range [0..16]!");
        }

        [Test]
        public void AddMethodShouldWorkProperly()
        {
            //Arrange
            Person[] people = new Person[] { personOne, personTwo };
            database = new Database(people);

            //Act
            database.Add(personThree);

            //Assert
            Assert.AreEqual(database.Count, 3);
        }
        
        [Test]
        public void AddMethodShouldThrowAnExceptionIfThereAreAlready16Users()
        {
            //Arrange
            Person[] people = new Person[]
            {
                personOne, personTwo, personThree,
                new Person(1212, "Victoria"),
                new Person(1313, "Boris"),
                new Person(1414, "Dimitar"),
                new Person(1515, "Dimana"),
                new Person(1616, "Preslava"),
                new Person(1717, "Nevena"),
                new Person(1818, "Victor"),
                new Person(1919, "Elena"),
                new Person(1010, "Simeon"),
                new Person(2121, "Iliya"),
                new Person(2222, "Gergana"),
                new Person(2323, "Rositsa"),
                new Person(2424, "Sonya"),
            };

            //Act
            database = new Database(people);

            //Assert

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(
                () => database.Add(new Person(2525, "Petko")));

            Assert.AreEqual(exception.Message, "Array's capacity must be exactly 16 integers!");
        }

        [Test]
        public void AddMethodShouldThrowAnExceptionIfThereAreAlreadyUsersWithThisUsername()
        {
            //Arrange
            Person[] people = new Person[] { personOne, personTwo };
            Person person = new Person(121212, "Jacob");
            database = new Database(people);

            //Assert
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(
                () => database.Add(person));

            Assert.AreEqual(exception.Message, "There is already user with this username!");
        }

        [Test]
        public void AddMethodShouldThrowAnExceptionIfThereAreAlreadyUsersWithThisId()
        {
            //Arrange
            Person[] people = new Person[] { personOne, personTwo };
            Person person = new Person(53535353, "Samuel");
            database = new Database(people);

            //Assert
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(
                () => database.Add(person));

            Assert.AreEqual(exception.Message, "There is already user with this Id!");
        }

        [Test]
        public void RemoveMethodShouldWorkProperly()
        {
            //Arrange
            database = new Database(personOne, personTwo, personThree);

            //Act
            database.Remove();

            //Assert
            Assert.AreEqual(database.Count, 2);
        }

        [Test]
        public void RemoveMethodShouldThrowAnExceptionIfPeopleAreZero()
        {
            //Arrange
            Person[] people = { };
            database = new Database(people);

            //Assert
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(
                () => database.Remove());
        }

        //Finding By Username Tests
        [Test]
        public void FindByUsernameWorksCorrectly()
        {
            //Arrange
            database = new Database(personOne, personTwo, personThree);

            //Act
            Person person = database.FindByUsername(personThree.UserName);

            //Assert
            Assert.AreEqual(person, personThree);
        }

        [TestCase("")]
        [TestCase(null)]
        public void DatabaseFindByUsernameMethodShouldThrowAnExceptionIfUsernameIsNull(string username)
        {
            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(()
                => database.FindByUsername(username), "Username parameter is null!");
        }

        [TestCase("Anton")]
        [TestCase("Lazar")]
        [TestCase("Deniz")]
        public void DatabaseFindByUsernameMethodShouldThrowAnExceptionIfUsernameIsNotFound(string username)
        {
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
                => database.FindByUsername(username), "No user is present by this username!");
        }

        //Finding By Id Tests
        [Test]
        public void FindByIdWorksCorrectly()
        {
            //Arrange
            database = new Database(personOne, personTwo, personThree);

            //Act
            Person person = database.FindById(personThree.Id);

            //Assert
            Assert.AreEqual(person, personThree);
        }

        [TestCase(1111111111111)]
        [TestCase(2222222222222)]
        [TestCase(3333333333333)]
        public void DatabaseFindByUsernameMethodShouldThrowAnExceptionIfIdIsNotFound(long id)
        {
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
                => database.FindById(id), "No user is present by this ID!");
        }

        [TestCase(-17401248471)]
        [TestCase(-1)]
        public void DatabaseFindByIdMethodShouldThrowAnExceptionIfIdIsNegativeNumber(long id)
        {
            ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(()
                => database.FindById(id), "Id should be a positive number!");
        }
    }
}