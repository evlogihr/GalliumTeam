using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game15
{
    public class Comunicator
    {

        public static string GetNumber()
        {
            Console.Write("Enter a number to move: ");
            string input = Console.ReadLine();
            return input;
        }

        public static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }

        public static string GetName()
        {
            Console.WriteLine("Congratulations! You won the game");
            Console.Write("Please enter your name for the top scoreboard: ");
            string name = Console.ReadLine();

            return name;
        }

        public static void DisplayIntroMessage()
        {
            Console.WriteLine("Welcome to the game “15”." +
                "\nPlease try to arrange the numbers sequentially." +
                "\nCommands:" +
                "\n - 'top' - view the top scoreboard" +
                "\n - 'restart' - start a new game" +
                "\n - 'exit' - quit the game");
        }
    }
}
