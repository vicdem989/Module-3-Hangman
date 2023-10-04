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
            chooseMode();

        }

        static void startScreenText(string outputString, string color, int sleepTime)
        {
            char letterToBeOutputted;
            for (int i = 0; i < outputString.Length; i++)
            {
                letterToBeOutputted = outputString[i];
                ANSI_COLORS.Colors.AddColorChar(letterToBeOutputted, color, true);
                Thread.Sleep(sleepTime);
            }
        }


        public static void chooseMode()
        {
            Console.Clear();
            Console.WriteLine("Pick a mode");
            Console.WriteLine("1 = Game");
            string input = Console.ReadLine().ToLower().Trim();
            if (input == "1")
            {
                Game.GameLogic();
                return;
            }
            else if (input == "2")
            {
                DifferentLanguages.appText = DifferentLanguages.chooseLanguage();
                Console.Clear();
                return;
            }
            else if (input == "3")
            {
                return;
            }
            else if (input == "4")
            {
            }
            else
            {
                chooseMode();
            }
        }

        public static void startMenuLogic(string input)
        {
            if (input == "1")
            {
                chooseMode();
            }
            else if (input == "2")
            {
                Console.Clear();

                createStartScreen();
            }
            else if (input == "3")
            {
                Console.Clear();
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
                StartScreen.chooseMode();
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
