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
            GameField.Print();
            Console.Write("Enter a number to move: ");
            string input = Console.ReadLine();
            int moves = 0;
            while (input != "exit")
            {
                moves++;
                switch (input)
                {
                    case "top":
                        //PrintBestOfTheBest();
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

                if (GameField.IsSolved())
                {
                    //AddToScoreBoard(moves);
                    moves = 0;
                    Initialize();
                }

                Console.Write("Enter a number to move: ");
                input = Console.ReadLine();
            }
        }
    }
}
