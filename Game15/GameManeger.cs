namespace Game15
{
    using System;
    using System.Linq;

    public static class GameManeger
    {
        public static void Initialize()
        {
            GameField.RandomField();
            Console.WriteLine("Welcome to the game “15”. Please try to arrange the numbers sequentially." +
                "Use 'top' to view the top scoreboard, 'restart' to start a new game and 'exit' to quit the game.");
        }

        public static void StartGame()
        {
            bool isGameInProgress = true;
            int moves = 0;
            do
            {
                GameField.Print();
                Console.Write("Enter a number to move: ");
                ReadCommand(out isGameInProgress);
                moves++;
                if (GameField.IsSolved())
                {
                    ScoreBoard.Add(moves);
                    moves = 0;
                    Initialize();
                }
            }
            while (isGameInProgress);
        }

        private static void ReadCommand(out bool isGameInProgress)
        {
            isGameInProgress = true;
            string command = Console.ReadLine();
            switch (command)
            {
                case "top":
                    ScoreBoard.PrintTopPlayers();
                    break;
                case "restart":
                    Initialize();
                    break;
                case "exit":
                    isGameInProgress = false;
                    break;
                default:
                    int numberToMove;
                    bool isValidNumber = false;
                    if (int.TryParse(command, out numberToMove))
                    {
                        isValidNumber = 0 < numberToMove && numberToMove < 16;
                    }

                    if (isValidNumber)
                    {
                        GameField.TryToMoveNumber(numberToMove);
                    }
                    else
                    {
                        Console.WriteLine("Illegal command!");
                    }

                    break;
            }
        }
    }
}
