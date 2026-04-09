using Xunit;
using Minesweeper.Core.GameServices;
using Minesweeper.Core.GameServices.Game;
using Minesweeper.Core.Game.Game;


namespace Minesweeper.Tests
{
    public class RevealMineLoseGameTest
    {
        [Fact]
        public void Reveal_Mine_Should_Lose_Game()
        {
            var game = new Game(8, 8, 10, seed: 123);

            // Find coordinates of a mine
            int r = -1, c = -1;
            for (int i = 0; i < game.Board.Rows; i++)
            {
                for (int j = 0; j < game.Board.Cols; j++)
                {
                    if (game.Board.Tiles[i, j].IsMine)
                    {
                        r = i;
                        c = j;
                        break;
                    }
                }
                if (r != -1) break;
            }

            Assert.NotEqual(-1, r); // sanity check, must find a mine

            game.Reveal(r, c);
            Assert.Equal(GameState.Lost, game.State);
        }
    }
}
