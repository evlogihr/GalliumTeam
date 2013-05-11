namespace Game15
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class GameField
    {
        public static readonly int[,] field = new int[4, 4];
        public static readonly Dictionary<int, Coordinates> numberPositions = new Dictionary<int, Coordinates>();

        public static void Print()
        {
            Console.WriteLine(" -------------------");
            for (int i = 0; i < field.GetLength(0); i++)
            {
                Console.Write("|");
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    if (field[i, j] == 0)
                    {
                        Console.Write("    |");
                        continue;
                    }

                    Console.Write(" {0,2} |", field[i, j]);
                }

                Console.WriteLine();
            }

            Console.WriteLine(" -------------------");
        }
        
        public static bool IsSolved()
        {
            int[,] matrix =
            {
                { 1, 2, 3, 4 },
                { 5, 6, 7, 8 },
                { 9, 10, 11, 12 },
                { 13, 14, 15, 0 }
            };
            for (int row = 0; row < GameField.field.GetLength(0); row++)
            {
                for (int col = 0; col < GameField.field.GetLength(1); col++)
                {
                    if (GameField.field[row, col] != matrix[row, col])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static void RandomField()
        {
            List<int> numbers = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            numberPositions.Clear();
            Random rand = new Random();
            for (int i = 0; i < GameField.field.GetLength(0); i++)
            {
                for (int j = 0; j < GameField.field.GetLength(1); j++)
                {
                    int position = rand.Next(0, numbers.Count);
                    GameField.field[i, j] = numbers[position];
                    numberPositions.Add(numbers[position], new Coordinates(i, j));
                    numbers.RemoveAt(position);
                }
            }
        }

        public static void TryToMoveNumber(int numberToMove)
        {
            if (numberPositions[0].CheckNeighbour(numberPositions[numberToMove]))
            {
                Coordinates temp = numberPositions[0];
                numberPositions[0] = numberPositions[numberToMove];
                numberPositions[numberToMove] = temp;
                field[numberPositions[numberToMove].Row, numberPositions[numberToMove].Col] = numberToMove;
                field[numberPositions[0].Row, numberPositions[0].Col] = 0;
            }
            else
            {
                Console.WriteLine("Illegal command!");
            }
        }
    }
}
