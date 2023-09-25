using ANSI_COLORS;
using LANGUAGE;

namespace SCREEN
{
    public class StartScreen
    {
        /*public static void createStartScreen(int sleepTime = 75)
        {
            Console.Clear();
            char letterToBeOutputted;
            /startScreenText(DifferentLanguages.appText.MenuOptions, ANSI_COLORS.Colors.BoldGreen, sleepTime);
            startScreenText(DifferentLanguages.appText.StartGame, ANSI_COLORS.Colors.White, sleepTime);
            startScreenText(DifferentLanguages.appText.changeLanguage, ANSI_COLORS.Colors.White, sleepTime);
            startScreenText(DifferentLanguages.appText.ExitGame, ANSI_COLORS.Colors.Red, sleepTime);

            string input = Console.ReadLine().ToLower().Trim();
            if (input == "1")
            {
                chooseMode();
            }
            else if (input == "2")
            {
                Console.Clear();

                DifferentLanguages.appText = DifferentLanguages.chooseLanguage();
                createStartScreen(0);
            }
            else if (input == "3")
            {
                Console.Clear();
                System.Environment.Exit(1);
            }
            else
            {
                createStartScreen(0);
            }
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
            ANSI_COLORS.Colors.AddColor(DifferentLanguages.appText.ChooseMode, ANSI_COLORS.Colors.Bold);
            ANSI_COLORS.Colors.AddColor(DifferentLanguages.appText.Singleplayer, ANSI_COLORS.Colors.Cyan);
            ANSI_COLORS.Colors.AddColor(DifferentLanguages.appText.SingleplayerBoX, ANSI_COLORS.Colors.Cyan);
            ANSI_COLORS.Colors.AddColor(DifferentLanguages.appText.TwoPlayer, ANSI_COLORS.Colors.Magenta);
            ANSI_COLORS.Colors.AddColor(DifferentLanguages.appText.TwoPlayerBoX, ANSI_COLORS.Colors.Magenta);
            string input = Console.ReadLine().ToLower().Trim();
            /*if (input == "1")
            {
                Game.gameLogic(false, false);
                return;
            }
            else if (input == "2")
            {
                Game.gameLogic(false, true, getInt());
            }
            else if (input == "3")
            {
                Game.gameLogic(true, false);
                return;
            }
            else if (input == "4")
            {
                Game.gameLogic(true, true, getInt());
            }
            else
            {
                chooseMode();
            }
        }

        public static int getInt()
        {
            Console.Clear();
            Console.WriteLine(DifferentLanguages.appText.Rounds);
            string inputRound = Console.ReadLine();
            int result = 0;
            while (!int.TryParse(inputRound, out result))
            {
                Colors.Error(DifferentLanguages.appText.RoundsError);
                inputRound = Console.ReadLine();
            }
            if (result >= 15)
            {
                double timeToComplete = (result * 5) / 60;
                Colors.Error(DifferentLanguages.appText.TimeEstimate + timeToComplete + DifferentLanguages.appText.Minutes);
                Colors.AddColor(DifferentLanguages.appText.WantToContinue + result + DifferentLanguages.appText.RoundsCheck, Colors.BoldYellow);
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
            Console.WriteLine(DifferentLanguages.appText.Replay + "\n");
            Console.WriteLine(DifferentLanguages.appText.Menu);
            string input = Console.ReadLine().ToLower().Trim();
            if (input == "y" || input == "j")
            {
                StartScreen.chooseMode();
            }
            else if (input == "m")
            {
                Console.Clear();
                StartScreen.createStartScreen(0);
            }
            else
            {
                Console.Clear();
                ANSI_COLORS.Colors.AddColor(DifferentLanguages.appText.ThanksForPlaying, ANSI_COLORS.Colors.BoldMagenta);
            }
        }*/
    }
}
