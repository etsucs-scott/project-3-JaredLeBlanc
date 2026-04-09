using Xunit;
using Minesweeper.Core.GameServices;
using Minesweeper.Core.GameServices.Game;
using Minesweeper.Core.Game.Game;


namespace Minesweeper.Tests
{
    public class BoardSizeTest
    {
        [Fact]
        public void Board_Correct_Size()
        {
            var game = new Game(8, 8, 10, seed: 123);
            Assert.Equal(8, game.Board.Rows);
            Assert.Equal(8, game.Board.Cols);
        }
    }
}
