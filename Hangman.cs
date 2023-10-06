using LANGUAGE;
using SCREEN;
using ANSI_COLORS;
using FILEINTERACTION;
using SPLASHSCREEN;

namespace GAME
{
    public class Game
    {
        private const bool DEBUG = true;
        private static List<string> wordsFromFile = new List<string>();
        private static int MAX_ATTEMPTS = Graphics.HANGMAN_STATE_DRAWINGS.Length;
        private static int currentAttemptsAtGuessingWord = 0;
        private static string word = String.Empty;
        private static string wordDisplay = CreateWordDisplay(word);
        private static string currentDrawing = Graphics.HANGMAN_STATE_DRAWINGS[currentAttemptsAtGuessingWord];
        private static bool isPlaying = true;
        private static List<char> charGuessed = new List<char>();
        private static char guess = '\0';
        private static Random randomNumber = new Random();
        public static int amountHints = 0;
        public static int increaseInDrawing = 0;
        public static string chosenMode = String.Empty;
        public static bool startCheck;

        static void Main(string[] args)
        {
            FileItem.ReadFile();
            createNewList();
            Clear();
            //SplashSCreen.writeSplashScreen();
            StartScreen.createStartScreen();

        }

        public static void GameLogic()
        {
            word = PickRandomItemFromList(wordsFromFile);
            wordDisplay = CreateWordDisplay(word);
            while (isPlaying)
            {
                if (DEBUG)
                {
                    Print(DifferentLanguages.appText.Word + $"{word}");
                }
                Print(DifferentLanguages.appText.Word + $"{wordDisplay}");
                Print(currentDrawing);
                Print(DifferentLanguages.appText.GuessLetter, false);

                guess = ReadChar();
                if (word.Contains(guess) && !charGuessed.Contains(guess))
                {
                    Clear();
                    for (int i = 0; i < word.Length; i++)
                    {
                        if (word[i] == guess)
                        {
                            wordDisplay = wordDisplay.Remove(i, 1).Insert(i, guess.ToString());
                        }
                    }
                }
                else
                {
                    Clear();
                    currentAttemptsAtGuessingWord += increaseInDrawing;
                    currentDrawing = Graphics.HANGMAN_STATE_DRAWINGS[currentAttemptsAtGuessingWord];
                }
                GuessedChars();
                hintCheck();
                checkPlayStatus();
            }
            FileItem.OutputToFile(currentAttemptsAtGuessingWord.ToString());
            FileItem.ReadFile();
            Print(DifferentLanguages.appText.CurrentScore + currentAttemptsAtGuessingWord);
            Print(DifferentLanguages.appText.DisplayHighscore + FileItem.highScore);
        }

        private static void hintCheck()
        {
            if (amountHints == 0)
                return;
            if (currentAttemptsAtGuessingWord >= word.Length / 2)
            {
                Print(DifferentLanguages.appText.WantAHint, true || (currentAttemptsAtGuessingWord >= (word.Length - word.Length) + 2 && chosenMode == "easy"));
                GetHint(Console.ReadLine().ToLower());
                amountHints--;
            }
        }

        private static void GetHint(string response)
        {
            if (response == "yes" || response == "y" || response == "ja" || response == "j")
            {
                Print(DifferentLanguages.appText.ThereMayBeA, false);
                Colors.AddColor(LetterHint().ToString(), Colors.Green, true);
                Print(DifferentLanguages.appText.SomewhereInThere, true);
            }
            else
            {
                checkPlayStatus();
            }
        }

        public static void chooseDifficulty()
        {
            Clear();
            Print(DifferentLanguages.appText.ChooseDifficulty, true);
            Print(DifferentLanguages.appText.Easy, true);
            Print(DifferentLanguages.appText.Extreme, true);
            string difficulty = Console.ReadLine().ToLower();
            Clear();
            if (difficulty == DifferentLanguages.appText.Extreme || difficulty == 2.ToString())
            {
                extremeDifficulty();
            }
            else
            {
                easyDifficulty();
            }
            GameLogic();
        }

        private static void easyDifficulty()
        {

            chosenMode = "easy";
            amountHints = 2;
            increaseInDrawing = 1;
            startCheck = false;
            Colors.AddColor(DifferentLanguages.appText.ChosenDifficulty + chosenMode, Colors.Cyan);

        }

        private static void extremeDifficulty()
        {

            chosenMode = "extreme";
            amountHints = 1;
            increaseInDrawing = 2;
            startCheck = true;
            currentAttemptsAtGuessingWord = 1;
            Colors.AddColor(DifferentLanguages.appText.ChosenDifficulty + chosenMode, Colors.Magenta);

        }

        private static List<string> createNewList()
        {
            StreamReader sr = new StreamReader("words.txt");
            String line = string.Empty;
            line = sr.ReadLine();
            while (line != null)
            {
                line = sr.ReadLine();
                wordsFromFile.Add(line);
            }
            sr.Close();
            return wordsFromFile;
        }



        private static char LetterHint()
        {
            char chosenLetter;
            bool charGuessedCheck;
            do
            {
                chosenLetter = word[randomNumber.Next(0, word.Length)];
                charGuessedCheck = charGuessed.Contains(chosenLetter);
                if (charGuessedCheck)
                    chosenLetter = word[randomNumber.Next(0, word.Length)];
            } while (charGuessedCheck);
            return chosenLetter;
        }


        private static void checkPlayStatus()
        {
            if (wordDisplay == word)
            {
                Print(currentDrawing);
                Colors.AddColor(DifferentLanguages.appText.YouWon + $"{word}", Colors.Green);
                isPlaying = false;
            }
            else if (currentAttemptsAtGuessingWord == MAX_ATTEMPTS - 1)
            {
                Print(currentDrawing);
                Colors.AddColor(DifferentLanguages.appText.YouLost + $"{word}", Colors.Red);
                isPlaying = false;
            }
        }

        private static void GuessedChars()
        {
            Print("", true);
            Colors.AddColor(DifferentLanguages.appText.AlreadyGuessedChar, Colors.BoldRed, true);
            if (!charGuessed.Contains(guess))
                charGuessed.Add(Convert.ToChar(guess));
            for (int i = 0; i < charGuessed.Count; i++)
            {
                Print(charGuessed[i] + " ", false);
            }
            Print();
        }


        private static char ReadChar()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            return keyInfo.KeyChar;
        }

        public static void Clear()
        {
            Console.Clear();
        }

        public static void Print(string text = "", bool newLine = true)
        {
            if (newLine)
            {
                Console.WriteLine(text);
            }
            else
            {
                Console.Write(text);
            }
        }



        public static string PickRandomItemFromList(List<string> list)
        {
            return wordsFromFile[randomNumber.Next(wordsFromFile.Count - 2)];
        }

        private static string CreateWordDisplay(string word)
        {
            string wordDisplay = "";
            for (int i = 0; i < word.Length; i++)
            {
                wordDisplay += "_";
            }
            return wordDisplay;
        }
    }
}


