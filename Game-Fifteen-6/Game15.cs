namespace Game15
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class Game15
    {
        private static readonly OrderedMultiDictionary<int, string> bestResults = new OrderedMultiDictionary<int, string>(true);

        public static void Main()
        {
            Initialize();
            StartGame();
        }

        private static void Initialize()
        {
            do
            {
                GameField.RandomField();
            }
            while (GameField.IsSolved());

            Console.WriteLine("Welcome to the game “15”. Please try to arrange the numbers sequentially." +
                "Use 'top' to view the top scoreboard, 'restart' to start a new game and 'exit' to quit the game.");
        }

        private static void StartGame()
        {
            GameField.Print();
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
                                GameField.TryToMoveNumber(numberToMove);
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

                GameField.Print();
                gameIsFinished = GameField.IsSolved();
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

        private static void AddToScoreBoard(int moves)
        {
            Console.WriteLine("Congratulations! You won the game in {0} moves.", moves);
            Console.Write("Please enter your name for the top scoreboard: ");
            string name = Console.ReadLine();
            bestResults.Add(moves, name);
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
    }
}
