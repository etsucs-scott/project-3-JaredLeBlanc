using System;
using Minesweeper.Core.HighScoreServices;
using Minesweeper.Core.Interfaces;
using Minesweeper.Core.GameServices.Game;
using Minesweeper.Core.GameServices;


namespace Minesweeper.ConsoleApp

{
    public class GameApp
    {
        private readonly IHighScoreManager _highScores;
        private readonly Renderer _renderer = new Renderer();
        private readonly InputHandler _inputHandler = new InputHandler();

        public GameApp(IHighScoreManager highscores)
        {
            _highScores = highscores;
        }

        public void Run()
        {

            while (true)
            {
                var config = ShowMenu();

                if (config == null)
                {
                    return;
                }

                int seed = PromptForSeed();

                var game = new Game(config.Value.rows, config.Value.cols, config.Value.mines, seed);

                RunGame(game, config.Value.size, seed);

            }
        }

        private (int rows, int cols, int mines, string size)? ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("=== MINESWEEPER ===\n");
            Console.WriteLine("MENU: ");
            Console.WriteLine("1. 8x8 - 10 Mines");
            Console.WriteLine("2. 12x12 - 25 Mines");
            Console.WriteLine("3. 16x16 - 40 Mines");
            Console.WriteLine("q. Quit");

            var input = Console.ReadLine();

            return input switch
            {
                "1" => (8, 8, 10, "8x8"),
                "2" => (12, 12, 25, "12x12"),
                "3" => (16, 16, 40, "16x16"),
                "q" => null,
                _ => ShowMenu()
            };
        }

        private int PromptForSeed()
        {
            Console.WriteLine("Seed (Blank = Random): ");
            var input = Console.ReadLine();

            return int.TryParse(input, out int seed)
                ? seed
                : DateTime.Now.GetHashCode();
        }

        private void RunGame(Game game, string size, int seed)
        {
            var startTime = DateTime.UtcNow;

            while(game.State == GameState.InProgress)
            {
                Console.Clear();
                Console.WriteLine($"Seed: {seed} | Moves: {game.Moves}\n");

                Console.WriteLine("Commands: r row col | f row col | q\n");
                _renderer.Render(game);

                Console.Write("\n> ");
                var command = _inputHandler.ReadCommand(game);

                if (command != null)
                {
                    command.Execute(game);
                }
            }

            EndGame(game, size, seed, startTime);
        }

        private void EndGame(Game game, string size, int seed, DateTime startTime)
        {
            Console.Clear();
            _renderer.Render(game, revealAll:  true);

            int seconds = (int)(DateTime.UtcNow - startTime).TotalSeconds;

            if (game.State == GameState.Won)
            {
                Console.WriteLine($"You Win! {seconds}s");

                _highScores.AddScore(new HighScore
                {
                    Size = size,
                    Seconds = seconds,
                    Moves = game.Moves,
                    Seed = seed,
                    TimeStamp = DateTime.UtcNow
                });
            }
            else
            {
                Console.WriteLine("You Lose! :(");
            }

            Console.WriteLine("\nPress any key to return to the menu...");
            Console.ReadKey();
        }
    }
}
