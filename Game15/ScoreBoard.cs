namespace Game15
{
    using System;
    using System.Linq;
    using System.Text;
    using Wintellect.PowerCollections;

    public static class ScoreBoard
    {
        private static readonly OrderedMultiDictionary<int, string> bestResults = new OrderedMultiDictionary<int, string>(true);

        public static void Add(int moves,string name)
        {
            bestResults.Add(moves, name);
        }

        public static string GetTopPlayers()
        {
            var sb = new StringBuilder();

            if (bestResults.Count != 0)
            {
                int counter = 1;
                sb.AppendLine("--------------------");
                foreach (var item in bestResults)
                {
                    sb.AppendFormat("{0}. {1} --> {2} moves\n", counter, item.Value, item.Key);
                    counter++;
                }
                sb.Append("--------------------");
            }
            else
            {
                sb.AppendLine("--------------------");
                sb.AppendLine("Scoreboard is empty.");
                sb.Append("--------------------");
            }

            return sb.ToString();
        }
    }
}
