using NORWEGIAN;
using ENGLISH;
using GAME;
using SCREEN;

namespace LANGUAGE
{
    public class DifferentLanguages
    {
        public static ApplicationStrings appText = LangEN.appTextEN;
        public static ApplicationStrings chooseLanguage()
        {
            Game.Clear();
            ANSI_COLORS.Colors.AddColor("Choose a language:", ANSI_COLORS.Colors.Bold);
            Game.Print("1: Norwegian (no)");
            Game.Print("2: English (en)");
            string chosenLanguage = Console.ReadLine().ToLower().Trim();
            if (chosenLanguage == "no" || chosenLanguage == "1")
            {
                ANSI_COLORS.Colors.AddColor("Du valgte Norsk!\n", ANSI_COLORS.Colors.Bold);
                return LangNO.appTextNO;
            }
            else
            {
                ANSI_COLORS.Colors.AddColor("You chose english!\n", ANSI_COLORS.Colors.Bold);
                return LangEN.appTextEN;
            }
        }
    }
}


public class ApplicationStrings
{
    public string? Word { get; set; }
    public string? GuessLetter { get; set; }
    public string? YouWon { get; set; }
    public string? YouLost { get; set; }
    public string? DisplayHighscore { get; set; }
    public string? WantAHint { get; set; }
    public string? ThereMayBeA { get; set; }
    public string? SomewhereInThere { get; set; }
    public string? ChooseDifficulty { get; set; }
    public string? Easy { get; set; }
    public string? Extreme { get; set; }
    public string? AlreadyGuessedChar { get; set; }


    public string? PickAMode { get; set; }
    public string? Game { get; set; }
    public string? ChooseLanguage { get; set; }
    public string? ExitGame { get; set; }
    public string? GetInfo { get; set; }
    public string? ThanksForPlaying { get; set; }
    public string? CurrentScore { get; set; }

    public string? DifficultyExplained { get; set; }
    public string? EasyExplained { get; set; }
    public string? ExtremeExplained { get; set; }
    public string? Enter { get; set; }

    public string? ChosenDifficulty { get; set; }

    
}