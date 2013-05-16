namespace GameTest
{
    using System;
    using Game15;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class GameFieldTests
    {
        [TestMethod]
        public void TestRandomField()
        {
            GameField.RandomField();
            int[,] firstGameField = (int[,])GameField.Field.Clone();
            GameField.RandomField();
            int[,] secondGameField = (int[,])GameField.Field.Clone();

            bool areTheSame = this.AreMatricesTheSame(firstGameField, secondGameField);
            Assert.IsFalse(areTheSame);
        }

        private bool AreMatricesTheSame(int[,] first, int[,] second)
        {
            for (int row = 0; row < first.GetLength(0); row++)
            {
                for (int col = 0; col < first.GetLength(1); col++)
                {
                    if (first[row, col] != second[row, col])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
