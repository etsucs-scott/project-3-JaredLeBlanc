using Minesweeper.Core.Game.Game;
using Minesweeper.Core.GameServices;
using Minesweeper.Core.GameServices.Game;
using Minesweeper.Core.HighScoreServices;
using Xunit;
using static Minesweeper.Tests.HighScoreManagerTest;


namespace Minesweeper.Tests
{
    public class HsmApplyTieTest // hsm = HighScoreManager
    {
        [Fact]
        public void HighScoreManager_Should_Apply_TieBreaker_By_Moves()
        {
            var repo = new InMemoryHighScoreRepository();
            var manager = new HighScoreManager(repo);

            manager.AddScore(new HighScore { Size = "8x8", Seconds = 10, Moves = 10, Seed = 1, TimeStamp = System.DateTime.UtcNow });
            manager.AddScore(new HighScore { Size = "8x8", Seconds = 10, Moves = 5, Seed = 2, TimeStamp = System.DateTime.UtcNow });

            var top = manager.GetScores("8x8").First();
            Assert.Equal(5, top.Moves); // fewer moves wins tie
        }
    }
}
