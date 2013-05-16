using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Game15;

namespace GameTest
{
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

            bool areTheSame = AreMatricesTheSame(firstGameField, secondGameField);
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
