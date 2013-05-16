namespace GameTest
{
    using System;
    using Game15;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class PlayerTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestPlayerNullForName()
        {
            IPlayer player = new Player(null, 10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestPlayerNegativeScore()
        {
            IPlayer player = new Player("Pesho", -100);   
        }
    }
}
