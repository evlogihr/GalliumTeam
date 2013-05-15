using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Game15;
using Wintellect.PowerCollections;
using System.Text;

namespace GameTest
{
    [TestClass]
    public class ScoreBoardTests
    {
        [TestMethod]
        public void GetTopPlayersEmptyTest()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("--------------------");
            sb.AppendLine("Scoreboard is empty.");
            sb.Append("--------------------");

            string empty = ScoreBoard.GetTopPlayers();

            Assert.AreEqual(sb.ToString(), empty);
        }

        [TestMethod]
        public void AddPlayerScoreTest()
        {
            ScoreBoard.Add(10, "Pesho");
            ScoreBoard.Add(20, "Mimi");

            OrderedMultiDictionary<int, string> scoreBoard = ScoreBoard.GetScoreBoard();
       
            Assert.AreEqual(scoreBoard.Count, 2);
        }

        [TestMethod]
        public void GetTopPlayersTest()
        {
            OrderedMultiDictionary<int, string> testScore = ScoreBoard.GetScoreBoard();
            testScore.Add(10, "Pesho");
            testScore.Add(20, "Mimi");            

            StringBuilder sb = new StringBuilder();
            int counter = 1;
            sb.AppendLine("--------------------");
            foreach (var item in testScore)
            {
                sb.AppendFormat("{0}. {1} --> {2} moves\n", counter, item.Value, item.Key);
                counter++;
            }
            sb.Append("--------------------");

            ScoreBoard.Add(10, "Pesho");
            ScoreBoard.Add(20, "Mimi");

            string consoleOutput = ScoreBoard.GetTopPlayers();

            Assert.AreEqual<string>(sb.ToString(), consoleOutput);
        }
    }
}
