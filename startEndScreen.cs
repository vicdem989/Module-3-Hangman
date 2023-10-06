using System.Diagnostics.Contracts;
using System.Globalization;
using ANSI_COLORS;
using GAME;
using LANGUAGE;

namespace SCREEN
{
    public class StartScreen
    {
        public static void createStartScreen()
        {
            Console.Clear();
            startScreenText();

        }

        static void startScreenText()
        {            
            Console.Clear();
            Console.WriteLine("Pick a mode");
            Console.WriteLine("1 - Game");
            Console.WriteLine("2 - Choose a language");
            Console.WriteLine("3 - Exit game");
            string decision = Console.ReadLine().ToLower();
            startMenuLogic(decision);

        }

        public static void startMenuLogic(string input)
        {
            if (input == "1")
            {
                Game.chooseDifficulty();
            }
            else if (input == "2")
            {
                DifferentLanguages.chooseLanguage();
                createStartScreen();
            }
            else if (input == "3")
            {
                Console.Clear();
                Console.WriteLine("Thanks for playing");
                System.Environment.Exit(1);
            }
            else
            {
                createStartScreen();
            }
        }




        public static int getInt()
        {
            Console.Clear();
            string inputRound = Console.ReadLine();
            int result = 0;
            while (!int.TryParse(inputRound, out result))
            {
                inputRound = Console.ReadLine();
            }
            if (result >= 15)
            {
                double timeToComplete = (result * 5) / 60;
                string input = Console.ReadLine();
                if (input == "y" || input == "j")
                {
                    return result;
                }
                else if (input == "n")
                {
                    getInt();
                }
            }
            return result;
        }
    }

    public class EndScreen
    {
        public static void createEndScreen()
        {
            string input = Console.ReadLine().ToLower().Trim();
            if (input == "y" || input == "j")
            {
                StartScreen.createStartScreen();
            }
            else if (input == "m")
            {
                Console.Clear();
                StartScreen.createStartScreen();
            }
            else
            {
                Console.Clear();
            }
        }
    }
}
