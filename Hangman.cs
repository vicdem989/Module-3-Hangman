using System.Data;
using System.Net;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using LANGUAGE;
using Microsoft.VisualBasic;
using STATS;
using SCREEN;

namespace GAME
{
    public class Game
    {
        private const bool DEBUG = true;
        private static string[] WORD_LIST = new[] { "car", "cat", "dog", "elephant", "fish", "giraffe", "horse", "monkey", "panda", "sheep", "tiger", "zebra", "ant", "bee", "marmelade", "computer", "dax", "sjobanan" };
        private static List<string> wordsFromFile = new List<string>();
        private static int MAX_ATTEMPTS = Graphics.HANGMAN_STATE_DRAWINGS.Length - 1;
        private static int currentAttemptsAtGuessingWord = 0;
        private static string word = String.Empty;
        private static string wordDisplay = CreateWordDisplay(word);
        private static string currentDrawing = Graphics.HANGMAN_STATE_DRAWINGS[currentAttemptsAtGuessingWord];
        private static bool isPlaying = true;
        private static List<char> charGuessed = new List<char>();
        private static char guess = '\0';
        private static Random randomNumber = new Random();
        public static int correctGuesses = 0;
        public static List<GameTracker> amountGames = new List<GameTracker>();


        static void Main(string[] args)
        {
            createNewList();
            StartScreen.createStartScreen();
        }

        public static void GameLogic()
        {
            word = PickRandomItemFromList(wordsFromFile);
            while (isPlaying)
            {

                if (DEBUG)
                {
                    Print(DifferentLanguages.appText.Word + $"{word}");
                }
                Print(DifferentLanguages.appText.Word + $"{wordDisplay}");
                Print(currentDrawing);
                Print(DifferentLanguages.appText.GuessLetter, newLine: false);

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
                    correctGuesses++;
                }
                else
                {
                    Clear();
                    currentAttemptsAtGuessingWord++;
                    currentDrawing = Graphics.HANGMAN_STATE_DRAWINGS[currentAttemptsAtGuessingWord];
                }
                GuessedChars();

                if (currentAttemptsAtGuessingWord >= word.Length / 2)
                {
                    Console.WriteLine("Hint?");
                    GetHint(Console.ReadLine().ToLower());
                }
                checkPlayStatus();
            }

            amountGames.Add(new GameTracker
            {
                gameID = 1,
                gameWord = word,
                amountCharGuessedCorrect = correctGuesses
            });
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

        private static void GetHint(string response)
        {
            if (response == "yes" || response == "j")
            {
                Print("kldasjkldjaskldja     " + LetterHint().ToString());
            }
            else
            {
                checkPlayStatus();
            }
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
                Print(DifferentLanguages.appText.YouWon + $"{word}");
                isPlaying = false;
            }
            else if (currentAttemptsAtGuessingWord == MAX_ATTEMPTS)
            {

                Print(currentDrawing);
                Print(DifferentLanguages.appText.YouLost + $"{word}");
                isPlaying = false;
            }
        }

        private static void GuessedChars()
        {
            Print("", true);
            Print("Already guessed chars: ", false);
            if (!charGuessed.Contains(guess))
                charGuessed.Add(Convert.ToChar(guess));
            for (int i = 0; i < charGuessed.Count; i++)
            {
                Print(charGuessed[i] + " ", false);
            }
            Console.WriteLine();
        }


        private static char ReadChar()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            return keyInfo.KeyChar;
        }

        private static void Clear()
        {
            Console.Clear();
        }

        private static void Print(string text, bool newLine = true)
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


