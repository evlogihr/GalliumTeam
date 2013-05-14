namespace Game15
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class GameField
    {
        /// <summary>
        /// Stores the current GameField
        /// </summary>
        private static readonly int[,] Field = new int[4, 4];

        /// <summary>
        /// A dictionary that stores all the numbers and their coordinates
        /// </summary>
        private static readonly Dictionary<int, Coordinates> NumbersAndPositions = new Dictionary<int, Coordinates>();

        /// <summary>
        /// Generate a random Field
        /// </summary>
        public static void RandomField()
        {
            List<int> numbers = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            NumbersAndPositions.Clear();
            Random rand = new Random();
            for (int row = 0; row < Field.GetLength(0); row++)
            {
                for (int col = 0; col < Field.GetLength(1); col++)
                {
                    int currentNumber = rand.Next(0, numbers.Count); // take a random number from the List of numbers
                    Field[row, col] = numbers[currentNumber]; // place the selected number in the current row and col
                    NumbersAndPositions.Add(numbers[currentNumber], new Coordinates(row, col)); // update the dictionary
                    numbers.RemoveAt(currentNumber); // remove it from the number from the List so it is not used again
                }
            }
        }

        public static void TryToMoveNumber(int numberToMove) // TODO: refactor it to not print anything on the console, istead return bool
        {
            if (NumbersAndPositions[0].CheckNeighbour(NumbersAndPositions[numberToMove]))
            {
                Coordinates temp = NumbersAndPositions[0];
                NumbersAndPositions[0] = NumbersAndPositions[numberToMove];
                NumbersAndPositions[numberToMove] = temp;
                Field[NumbersAndPositions[numberToMove].Row, NumbersAndPositions[numberToMove].Col] = numberToMove;
                Field[NumbersAndPositions[0].Row, NumbersAndPositions[0].Col] = 0;
            }
            else
            {
                Console.WriteLine("Illegal command!");
            }
        }

        /// <summary>
        /// Check if the current field is solved
        /// </summary>
        /// <returns>true or false</returns>
        public static bool IsSolved()
        {
            bool isSolved = true;
            int[,] solvedField =
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
                    if (Field[row, col] != solvedField[row, col])
                    {
                        isSolved = false;
                    }
                }
            }

            return isSolved;
        }

        /// <summary>
        /// Prints the current GameField on the Console
        /// </summary>
        public static void PrintToConsole()
        {
            Console.WriteLine(" -------------------");
            for (int row = 0; row < Field.GetLength(0); row++)
            {
                Console.Write("|");
                for (int col = 0; col < Field.GetLength(1); col++)
                {
                    if (Field[row, col] == 0)
                    {
                        Console.Write("    |");
                        continue;
                    }

                    Console.Write(" {0,2} |", Field[row, col]);
                }

                Console.WriteLine();
            }

            Console.WriteLine(" -------------------");
        }
    }
}
