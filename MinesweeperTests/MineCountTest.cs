using Xunit;
using Minesweeper.Core.GameServices;
using Minesweeper.Core.GameServices.Game;
using Minesweeper.Core.Game.Game;


namespace Minesweeper.Tests
{
    public class MineCountTest
    {
        [Fact]
        public void Mine_Count()
        {
            var game = new Game(8, 8, 10, seed: 123);
            int mineCount = game.Board.Tiles.Cast<Tile>().Count(t => t.IsMine);
            Assert.Equal(10, mineCount);
        }
    }
}
