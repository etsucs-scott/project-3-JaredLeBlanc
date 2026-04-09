using Xunit;
using Minesweeper.Core.GameServices;
using Minesweeper.Core.GameServices.Game;
using Minesweeper.Core.Game.Game;


namespace Minesweeper.Tests
{
    public class FlaggingToggleTest
    {
        [Fact]
        public void Flagging_Should_Toggle()
        {
            var game = new Game(8, 8, 10, seed: 123);
            game.ToggleFlag(0, 0);
            Assert.True(game.Board.Tiles[0, 0].IsFlagged);
            game.ToggleFlag(0, 0);
            Assert.False(game.Board.Tiles[0, 0].IsFlagged);
        }
    }
}
