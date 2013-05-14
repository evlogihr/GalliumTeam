namespace Game15
{
    using System;
    using System.Linq;

    /// <summary>
    /// Controller class, serves as a game engine
    /// </summary>
    public class Engine
    {
        /// <summary>
        /// Initializes a game at program start or when user inputs "restart"
        /// </summary>
        public static void Initialize()
        {
            GameField.RandomField();
            Comunicator.DisplayIntroMessage();
        }

        /// <summary>
        /// Reads the user's commands from the Console and updates the GameField
        /// </summary>
        public static void Run()
        {
            bool isGameInProgress = true;
            int moves = 0;
            do
            {


                GameField.PrintToConsole();
                Comunicator.DisplayMessage("Enter number to move");
                ReadCommand(out isGameInProgress);
                moves++;
                if (GameField.IsSolved())
                {
                    string name = Comunicator.GetName();
                    ScoreBoard.Add(moves,name);
                    moves = 0;
                    Initialize();
                }
            }
            while (isGameInProgress);
        }

        /// <summary>
        /// Reads the user's input from the Console and in case it is "exit"
        /// changes the isGameInProgress to false
        /// </summary>
        /// <param name="isGameInProgress">when false will end the game</param>
        private static void ReadCommand(out bool isGameInProgress)
        {
            isGameInProgress = true;
            string command = Comunicator.GetNumber();
            switch (command)
            {
                case "top":
                    string topPlayers = ScoreBoard.GetTopPlayers();
                    Comunicator.DisplayMessage(topPlayers);
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
