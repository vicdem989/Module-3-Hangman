using System.Net;
using LANGUAGE;
using Microsoft.VisualBasic;

namespace GAME
{
    public class Game
    {
        private const bool DEBUG = true;
        private static string[] WORD_LIST = new[] { "car", "cat", "dog", "elephant", "fish", "giraffe", "horse", "monkey", "panda", "sheep", "tiger", "zebra", "ant", "bee", "marmelade", "computer", "dax", "sjøbanan" };
        private static int MAX_ATTEMPTS = Graphics.HANGMAN_STATE_DRAWINGS.Length - 1;
        private static int currentAttemptsAtGuessingWord = 0;
        private static string word = PickRandomItemFromList(WORD_LIST);
        private static string wordDisplay = CreateWordDisplay(word);
        private static string currentDrawing = Graphics.HANGMAN_STATE_DRAWINGS[currentAttemptsAtGuessingWord];
        private static bool isPlaying = true;
        private static List<char> charGuessed = new List<char>();


        static void Main(string[] args)
        {
            DifferentLanguages.appText = DifferentLanguages.chooseLanguage();
            StartGame();
        }

        private static void StartGame()
        {
            while (isPlaying)
            {
                //Clear();
                if (DEBUG)
                {
                    Print(DifferentLanguages.appText.Word + $"{word}");
                }
                Print(DifferentLanguages.appText.Word + $"{wordDisplay}");
                Print(currentDrawing);
                Print(DifferentLanguages.appText.GuessLetter, newLine: false);

                char guess = ReadChar();
                if (word.Contains(guess))
                {
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
                    currentAttemptsAtGuessingWord++;
                    currentDrawing = Graphics.HANGMAN_STATE_DRAWINGS[currentAttemptsAtGuessingWord];
                    charGuessed.Add(Convert.ToChar(guess));
                    for (int i = 0; i < charGuessed.Count; i++)
                    {
                        Console.Write(charGuessed[i] + " ");
                    }
                    Console.WriteLine();

                }

                if (wordDisplay == word)
                {
                    //Clear();
                    Print(DifferentLanguages.appText.YouWon + $"{word}");
                    isPlaying = false;
                }
                else if (currentAttemptsAtGuessingWord == MAX_ATTEMPTS)
                {
                    //clear();
                    Print(DifferentLanguages.appText.YouLost + $"{word}");
                    isPlaying = false;
                }
            }
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

        private static string PickRandomItemFromList(string[] list)
        {
            Random random = new Random();
            int randomIndex = random.Next(0, list.Length);
            return list[randomIndex];
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