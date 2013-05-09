namespace Game15
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class Game15
    {
        private static int[,] field = new int[4, 4];
        private static OrderedMultiDictionary<int, string> bestResults = new OrderedMultiDictionary<int, string>(true);
        private static Dictionary<int, Coordinates> numberPositions = new Dictionary<int, Coordinates>();

        public static void Main()
        {
            Initialize();
            StartGame();
        }

        private static void Initialize()
        {
            do
            {
                RandomGameField();
            }
            while (IsGameFieldSolved());

            Console.WriteLine("Welcome to the game “15”. Please try to arrange the numbers sequentially." +
                "Use 'top' to view the top scoreboard, 'restart' to start a new game and 'exit' to quit the game.");
        }

        private static void RandomGameField()
        {
            List<int> numbers = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            numberPositions.Clear();
            Random rand = new Random();
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    int position = rand.Next(0, numbers.Count);
                    field[i, j] = numbers[position];
                    numberPositions.Add(numbers[position], new Coordinates(i, j));
                    numbers.RemoveAt(position);
                }
            }
        }

        private static void StartGame()
        {
            PrintGameField();
            Console.Write("Enter a number to move: ");
            string input = Console.ReadLine();
            bool gameIsFinished = false;
            int moves = 0;
            while (input != "exit")
            {
                moves++;
                switch (input)
                {
                    case "top":
                        PrintBestOfTheBest();
                        break;
                    case "restart":
                        Initialize();
                        break;
                    default:
                        int numberToMove;
                        if (int.TryParse(input, out numberToMove))
                        {
                            if (0 < numberToMove && numberToMove < 16)
                            {
                                TryToMoveNumber(numberToMove);
                            }
                            else
                            {
                                Console.WriteLine("Illegal command!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Illegal command!");
                        }

                        break;
                }

                PrintGameField();
                gameIsFinished = IsGameFieldSolved();
                if (gameIsFinished)
                {
                    AddToScoreBoard(moves);
                    moves = 0;
                    Initialize();
                }

                Console.Write("Enter a number to move: ");
                input = Console.ReadLine();
            }
        }

        private static void TryToMoveNumber(int numberToMove)
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

        private static void AddToScoreBoard(int moves)
        {
            Console.WriteLine("Congratulations! You won the game in {0} moves.", moves);
            Console.Write("Please enter your name for the top scoreboard: ");
            string name = Console.ReadLine();
            bestResults.Add(moves, name);
        }

        private static bool IsGameFieldSolved()
        {
            int[,] matrix =
            {
                { 1, 2, 3, 4 },
                { 5, 6, 7, 8 },
                { 9, 10, 11, 12 },
                { 13, 14, 15, 0 }
            };
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    if (field[row, col] != matrix[row, col])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private static void PrintBestOfTheBest()
        {
            if (bestResults.Count == 0)
            {
                Console.WriteLine("Scoreboard is empty.");
            }

            int counter = 1;
            foreach (var item in bestResults)
            {
                Console.WriteLine("{0}. {1} --> {2} moves", counter, item.Value, item.Key);
                counter++;
            }
        }

        private static void PrintGameField()
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
    }
}
