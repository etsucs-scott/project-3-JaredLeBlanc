using Minesweeper.Core.HighScoreServices;
using Minesweeper.Core.Interfaces;

namespace Minesweeper.ConsoleApp
{

    public class Program
    {
        static void Main()
        {
            //Create the CSV parser for high scores
            IHighScoreParser parser = new CsvParser();

            //Create the repository
            IHighScoreRepository repo = new HighScoreRepository("data/highscores.csv", parser);

            //Create the high score manager
            IHighScoreManager highScores = new HighScoreManager(repo);

            var app = new GameApp(highScores);
            app.Run();
        }
    }
}