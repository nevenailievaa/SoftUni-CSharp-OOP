using NUnit.Framework;
using System.Collections.Generic;
using System;

namespace FootballTeam.Tests
{
    public class Tests
    {
        [Test]
        public void ConstructorShouldWorkProperly()
        {
            FootballTeam team = new FootballTeam("Real Madrid", 21);

            Assert.IsNotNull(team);
            Assert.AreEqual("Real Madrid", team.Name);
            Assert.AreEqual(21, team.Capacity);


            Type t = team.Players.GetType();
            Type expectedType = typeof(List<FootballPlayer>);

            Assert.AreEqual(t, expectedType);
        }

        [TestCase(null)]
        [TestCase("")]
        public void NameShouldThrowArgumentExceptionIfNullOrEmpty(string name)
        {
            FootballTeam team = new FootballTeam("Real Madrid", 21);

            Assert.Throws<ArgumentException>(()
                => team.Name = name, "Name cannot be null or empty!");
        }

        [TestCase(0)]
        [TestCase(5)]
        [TestCase(14)]
        public void CapacityShouldThrowArgumentExceptionIfLessThan15(int capacity)
        {
            FootballTeam team = new FootballTeam("Real Madrid", 21);

            Assert.Throws<ArgumentException>(()
                => team.Capacity = capacity, "Capacity min value = 15");
        }

        [Test]
        public void AddMethodShouldAddPlayerCorrectly()
        {
            FootballTeam team = new FootballTeam("Real Madrid", 21);
            FootballPlayer player = new FootballPlayer("Cristiano Ronaldo", 7, "Forward");

            string expextedMessage = team.AddNewPlayer(player);

            Assert.AreEqual(1, team.Players.Count);
            Assert.AreEqual(expextedMessage, $"Added player {player.Name} in position {player.Position} with number {player.PlayerNumber}");
        }

        [Test]
        public void AddMethodShouldReturnTheCorrectMessageIfTryingToAddMoreFootballersThanTheCapacity()
        {
            FootballPlayer player1 = new FootballPlayer("Player1Name", 1, "Goalkeeper");
            FootballPlayer player2 = new FootballPlayer("Playe2rName", 2, "Goalkeeper");
            FootballPlayer player3 = new FootballPlayer("Player3Name", 3, "Midfielder");
            FootballPlayer player4 = new FootballPlayer("Player4Name", 4, "Midfielder");
            FootballPlayer player5 = new FootballPlayer("Player5Name", 5, "Midfielder");
            FootballPlayer player6 = new FootballPlayer("Player6Name", 6, "Midfielder");
            FootballPlayer player7 = new FootballPlayer("Player7Name", 7, "Midfielder");
            FootballPlayer player8 = new FootballPlayer("Player8Name", 8, "Midfielder");
            FootballPlayer player9 = new FootballPlayer("Player9Name", 9, "Midfielder");
            FootballPlayer player10 = new FootballPlayer("Player10Name", 10, "Midfielder");
            FootballPlayer player11 = new FootballPlayer("Player11Name", 11, "Midfielder");
            FootballPlayer player12 = new FootballPlayer("Player12Name", 12, "Forward");
            FootballPlayer player13 = new FootballPlayer("Player13Name", 13, "Forward");
            FootballPlayer player14 = new FootballPlayer("Player14Name", 14, "Forward");
            FootballPlayer player15 = new FootballPlayer("Player15Name", 15, "Forward");
            FootballPlayer player16 = new FootballPlayer("Player16Name", 16, "Forward");

            FootballTeam team = new FootballTeam("Real Madrid", 15);

            team.AddNewPlayer(player1);
            team.AddNewPlayer(player2);
            team.AddNewPlayer(player3);
            team.AddNewPlayer(player4);
            team.AddNewPlayer(player5);
            team.AddNewPlayer(player6);
            team.AddNewPlayer(player7);
            team.AddNewPlayer(player8);
            team.AddNewPlayer(player9);
            team.AddNewPlayer(player10);
            team.AddNewPlayer(player11);
            team.AddNewPlayer(player12);
            team.AddNewPlayer(player13);
            team.AddNewPlayer(player14);
            team.AddNewPlayer(player15);

            string expextedMessage = team.AddNewPlayer(player16);

            Assert.AreEqual(15, team.Players.Count);
            Assert.AreEqual(expextedMessage, $"No more positions available!");
        }

        [Test]
        public void PickPlayerMethodShouldPickPlayersCorrectly()
        {
            FootballTeam team = new FootballTeam("Real Madrid", 21);
            FootballPlayer player = new FootballPlayer("Cristiano Ronaldo", 7, "Forward");
            team.AddNewPlayer(player);

            FootballPlayer searchedPlayer1 = team.PickPlayer("Cristiano Ronaldo");
            FootballPlayer searchedPlayer2 = team.PickPlayer("Leo Messi");

            Assert.AreSame(player, searchedPlayer1);
            Assert.IsNull(searchedPlayer2);
        }

        [Test]
        public void PlayerScoreMethodShouldPickPlayerAndScoreCorrectly()
        {
            FootballTeam team = new FootballTeam("Real Madrid", 21);
            FootballPlayer player = new FootballPlayer("Cristiano Ronaldo", 7, "Forward");
            team.AddNewPlayer(player);

            string expectedMessage = team.PlayerScore(7);

            Assert.AreEqual(expectedMessage, $"{player.Name} scored and now has {player.ScoredGoals} for this season!");
            Assert.AreEqual(1, player.ScoredGoals);
        }
    }
}