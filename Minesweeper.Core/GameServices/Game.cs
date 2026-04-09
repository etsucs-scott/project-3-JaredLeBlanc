using Minesweeper.Core.Game.Game;

namespace Minesweeper.Core.GameServices.Game
{
    public class Game
    {
        public Board Board {  get; }
        public GameState State { get; private set; } = GameState.InProgress;
        public int Moves { get; private set; } = 0;
        public int Seed { get; }

        private readonly RevealService _revealService = new RevealService();
        private readonly WinChecker _winChecker = new WinChecker();

        public Game(int rows, int cols, int mines, int seed)
        {
            Seed = seed;

            Board = new Board(rows, cols);

            var generator = new MineGenerator();
            generator.PlaceMines(Board.Tiles, rows, cols, mines, seed);

            var adjacency = new AdjacencyCalculator();
            adjacency.Calculate(Board.Tiles, rows, cols);
        }

        public void Reveal(int r, int c)
        {
            if (State != GameState.InProgress) return;

            var tile = Board.Tiles[r, c];

            if (tile.IsFlagged || tile.IsRevealed) return;

            _revealService.Reveal(Board.Tiles, Board.Rows, Board.Cols, r, c);
            Moves++;

            if (tile.IsMine)
            {
                State = GameState.Lost;
                return;
            }

            if (_winChecker.IsWin(Board.Tiles))
            {
                State = GameState.Won;
            }
        }

        public void ToggleFlag(int r, int c)
        {
            var tile = Board.Tiles[r, c];

            if (!tile.IsRevealed)
            {
                tile.IsFlagged = !tile.IsFlagged;
            }
        }
    }
}
