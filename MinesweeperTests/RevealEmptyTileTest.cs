using Xunit;
using Minesweeper.Core.GameServices;
using Minesweeper.Core.GameServices.Game;
using Minesweeper.Core.Game.Game;


namespace Minesweeper.Tests
{
    public class RevealEmptyTileTest
    {
        [Fact]
        public void Reveal_EmptyTile_Should_Cascade()
        {
            // Arrange: 3x3 board with all tiles initialized
            var tiles = new Tile[3, 3];
            for (int r = 0; r < 3; r++)
                for (int c = 0; c < 3; c++)
                    tiles[r, c] = new Tile();

            // Place a mine in bottom-right corner
            tiles[2, 2].IsMine = true;

            // Calculate adjacency numbers
            var calculator = new AdjacencyCalculator();
            calculator.Calculate(tiles, 3, 3);

            var revealService = new RevealService();

            // Act: reveal top-left corner (0,0)
            revealService.Reveal(tiles, 3, 3, 0, 0);

            // Assert: cascade should reveal all non-mine tiles
            int revealedCount = tiles.Cast<Tile>().Count(t => t.IsRevealed);
            Assert.Equal(8, revealedCount); // all except the mine

            // Mine itself should NOT be revealed
            Assert.False(tiles[2, 2].IsRevealed);
        }
    }
}
