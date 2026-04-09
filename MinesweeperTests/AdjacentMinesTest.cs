using Xunit;
using Minesweeper.Core.GameServices;
using Minesweeper.Core.GameServices.Game;
using Minesweeper.Core.Game.Game;


namespace Minesweeper.Tests
{
    public class AdjacentMinesTest
    {
        [Fact]
        public void Adjacent_Mines_Should_Be_Correct()
        {
            // Arrange: 3x3 board with all tiles initialized
            var tiles = new Tile[3, 3];
            for (int r = 0; r < 3; r++)
                for (int c = 0; c < 3; c++)
                    tiles[r, c] = new Tile();

            // Place a mine in the center
            tiles[1, 1].IsMine = true;

            var calculator = new AdjacencyCalculator();

            // Act: calculate adjacency numbers
            calculator.Calculate(tiles, 3, 3);

            // Assert: center mine should have 0 adjacent mines
            Assert.Equal(0, tiles[1, 1].AdjacentMines);

            // All surrounding tiles should have 1 adjacent mine
            Assert.Equal(1, tiles[0, 0].AdjacentMines);
            Assert.Equal(1, tiles[0, 1].AdjacentMines);
            Assert.Equal(1, tiles[0, 2].AdjacentMines);
            Assert.Equal(1, tiles[1, 0].AdjacentMines);
            Assert.Equal(1, tiles[1, 2].AdjacentMines);
            Assert.Equal(1, tiles[2, 0].AdjacentMines);
            Assert.Equal(1, tiles[2, 1].AdjacentMines);
            Assert.Equal(1, tiles[2, 2].AdjacentMines);
        }
    }
}
