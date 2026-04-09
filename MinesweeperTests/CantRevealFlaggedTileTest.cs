using Xunit;
using Minesweeper.Core.GameServices;
using Minesweeper.Core.GameServices.Game;
using Minesweeper.Core.Game.Game;


namespace Minesweeper.Tests
{
    public class CantRevealFlaggedTileTest
    {
        [Fact]
        public void Cannot_Reveal_Flagged_Tile()
        {
            var game = new Game(8, 8, 10, seed: 123);
            game.ToggleFlag(0, 0);
            game.Reveal(0, 0);
            Assert.False(game.Board.Tiles[0, 0].IsRevealed);
        }
    }
}
