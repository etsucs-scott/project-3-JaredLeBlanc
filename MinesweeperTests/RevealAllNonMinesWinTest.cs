using Xunit;
using Minesweeper.Core.GameServices;
using Minesweeper.Core.GameServices.Game;
using Minesweeper.Core.Game.Game;


namespace Minesweeper.Tests
{
    public class RevealAllNonMineWinTest
    {
        [Fact]
        public void Reveal_All_NonMines_Should_WinGame()
        {
            var game = new Game(8, 8, 1, seed: 123);
            // Reveal all non-mine tiles
            for (int r = 0; r < game.Board.Rows; r++)
            {
                for (int c = 0; c < game.Board.Cols; c++)
                {
                    if (!game.Board.Tiles[r, c].IsMine)
                        game.Reveal(r, c);
                }
            }
            Assert.Equal(GameState.Won, game.State);
        }
    }
}
