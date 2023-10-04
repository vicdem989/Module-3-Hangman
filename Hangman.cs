using System.Data;
using System.Net;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using LANGUAGE;
using Microsoft.VisualBasic;
using SCREEN;

namespace GAME
{
    public class Game
    {
        private const bool DEBUG = true;
        private static string[] WORD_LIST = new[] { "car", "cat", "dog", "elephant", "fish", "giraffe", "horse", "monkey", "panda", "sheep", "tiger", "zebra", "ant", "bee", "marmelade", "computer", "dax", "sjobanan" };
        private static int MAX_ATTEMPTS = Graphics.HANGMAN_STATE_DRAWINGS.Length - 1;
        private static int currentAttemptsAtGuessingWord = 0;
        private static string word = PickRandomItemFromList(WORD_LIST);
        private static string wordDisplay = CreateWordDisplay(word);
        private static string currentDrawing = Graphics.HANGMAN_STATE_DRAWINGS[currentAttemptsAtGuessingWord];
        private static bool isPlaying = true;
        private static List<char> charGuessed = new List<char>();
        private static char guess = '\0';
        private static Random randomNumber = new Random();
        private static char letterHint = '\0';


        static void Main(string[] args)
        {
            StartScreen.createStartScreen();
        }

        public static void GameLogic()
        {

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
                }
                else
                {
                    Clear();
                    currentAttemptsAtGuessingWord++;
                    currentDrawing = Graphics.HANGMAN_STATE_DRAWINGS[currentAttemptsAtGuessingWord];
                }
                GuessedChars();

                if (currentAttemptsAtGuessingWord == 1) 
                {
                    Console.WriteLine("Hint?");
                    string response = Console.ReadLine();

                    if (response == "yes")
                    {
                        Print("kldasjkldjaskldja     " + LetterHint().ToString());
                    }
                    else
                    {
                        checkPlayStatus();
                        return;
                    }
                }
                checkPlayStatus();



            }
        }



        private static char LetterHint()
        {
            //Get a random letter from final word
            //Check if letter is already guesses, aka found in charGuessed
            //If found, get new letter
            //else return char
            char chosenLetter;
            bool charGuessedCheck;
            do
            {
                chosenLetter = word[randomNumber.Next(0, word.Length)];
                charGuessedCheck = charGuessed.Contains(chosenLetter);//Any(x => x == chosenLetter);
                if (charGuessedCheck)
                    LetterHint();
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


