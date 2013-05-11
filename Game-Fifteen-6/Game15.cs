namespace Game15
{
    using System;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class Game15
    {
        private static readonly OrderedMultiDictionary<int, string> bestResults = new OrderedMultiDictionary<int, string>(true);

        public static void Main()
        {
            GameManeger.Initialize();
            GameManeger.StartGame();
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
