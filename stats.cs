using GAME;
using LANGUAGE;

namespace STATS
{

    public class Processing
    {
        public static void submitHighScore() 
        {

        }

        public  static int getHighScore()
        {
            return 0;
        }


    }

    public class GameTracker
    {

        public int gameID { get; set; }
        public string gameWord { get; set; } = string.Empty;
        public int amountCharGuessedCorrect { get; set; }

    }

}