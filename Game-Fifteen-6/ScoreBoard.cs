namespace Game15
{
    using System;
    using System.Linq;
    using Wintellect.PowerCollections;

    public static class ScoreBoard
    {
        private static readonly OrderedMultiDictionary<int, string> bestResults = new OrderedMultiDictionary<int, string>(true);

        public static void Add(int moves)
        {
            Console.WriteLine("Congratulations! You won the game in {0} moves.", moves);
            Console.Write("Please enter your name for the top scoreboard: ");
            string name = Console.ReadLine();
            bestResults.Add(moves, name);
        }

        public static void PrintTopPlayers()
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
