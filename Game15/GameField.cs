namespace Game15
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class GameField
    {
        private static readonly int[,] Field = new int[4, 4];
        private static readonly Dictionary<int, Coordinates> NumberPositions = new Dictionary<int, Coordinates>();
        
        public static void RandomField()
        {
            List<int> numbers = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            NumberPositions.Clear();
            Random rand = new Random();
            for (int i = 0; i < GameField.Field.GetLength(0); i++)
            {
                for (int j = 0; j < GameField.Field.GetLength(1); j++)
                {
                    int position = rand.Next(0, numbers.Count);
                    GameField.Field[i, j] = numbers[position];
                    NumberPositions.Add(numbers[position], new Coordinates(i, j));
                    numbers.RemoveAt(position);
                }
            }
        }

        public static void TryToMoveNumber(int numberToMove)
        {
            if (NumberPositions[0].CheckNeighbour(NumberPositions[numberToMove]))
            {
                Coordinates temp = NumberPositions[0];
                NumberPositions[0] = NumberPositions[numberToMove];
                NumberPositions[numberToMove] = temp;
                Field[NumberPositions[numberToMove].Row, NumberPositions[numberToMove].Col] = numberToMove;
                Field[NumberPositions[0].Row, NumberPositions[0].Col] = 0;
            }
            else
            {
                Console.WriteLine("Illegal command!");
            }
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
            for (int row = 0; row < Field.GetLength(0); row++)
            {
                for (int col = 0; col < Field.GetLength(1); col++)
                {
                    if (Field[row, col] != matrix[row, col])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static void Print()
        {
            Console.WriteLine(" -------------------");
            for (int i = 0; i < Field.GetLength(0); i++)
            {
                Console.Write("|");
                for (int j = 0; j < Field.GetLength(1); j++)
                {
                    if (Field[i, j] == 0)
                    {
                        Console.Write("    |");
                        continue;
                    }

                    Console.Write(" {0,2} |", Field[i, j]);
                }

                Console.WriteLine();
            }

            Console.WriteLine(" -------------------");
        }
    }
}
