using System.Diagnostics.Contracts;
using System.Dynamic;
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
            startScreenText();

        }

        static void startScreenText()
        {            
            Game.Clear();
            Colors.AddColor(DifferentLanguages.appText.PickAMode, Colors.Bold);
            Game.Print(DifferentLanguages.appText.Game);
            Game.Print(DifferentLanguages.appText.ChooseLanguage);
            Game.Print(DifferentLanguages.appText.GetInfo);
            Colors.AddColor(DifferentLanguages.appText.ExitGame, Colors.Red);
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
                DifferentLanguages.appText = DifferentLanguages.chooseLanguage();
                startScreenText();
            } else if (input == "3") {
                Game.Clear();
                getInfo();
            }
            else if (input == "4")
            {
                Game.Clear();
                Game.Print("Thanks for playing");
                System.Environment.Exit(1);
            }
            else
            {
                createStartScreen();
            }
        }

        private static void getInfo() {

            Game.Print(DifferentLanguages.appText.DifficultyExplained);
            Game.Print(DifferentLanguages.appText.EasyExplained);
            Game.Print(DifferentLanguages.appText.ExtremeExplained);
            Game.Print(DifferentLanguages.appText.Enter);
            Console.ReadLine();
            startScreenText();

        }

        private static int getInt()
        {
            Game.Clear();
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
                Game.Clear();
                StartScreen.createStartScreen();
            }
            else
            {
                Game.Clear();
            }
        }
    }
}
