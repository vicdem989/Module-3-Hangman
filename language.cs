using NORWEGIAN;
using ENGLISH;

namespace LANGUAGE
{
    public class DifferentLanguages
    {
        public static ApplicationStrings appText = LangEN.appTextEN;
        public static ApplicationStrings chooseLanguage()
        {
            Console.Clear();
            ANSI_COLORS.Colors.AddColor("Choose a language:", ANSI_COLORS.Colors.Bold);
            Console.WriteLine("1: Norwegian (no)");
            Console.WriteLine("2: English (en)");
            string chosenLanguage = Console.ReadLine().ToLower().Trim();
            Console.Clear();
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
   
}