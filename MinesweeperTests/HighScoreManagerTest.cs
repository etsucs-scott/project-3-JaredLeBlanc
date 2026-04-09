using Minesweeper.Core.Game.Game;
using Minesweeper.Core.GameServices;
using Minesweeper.Core.GameServices.Game;
using Minesweeper.Core.HighScoreServices;
using Minesweeper.Core.Interfaces;
using Xunit;


namespace Minesweeper.Tests
{
    public class HighScoreManagerTest
    {
        [Fact]
        public void HighScoreManager_Should_Add_And_Get_TopScores()
        {
            var repo = new InMemoryHighScoreRepository();
            var manager = new HighScoreManager(repo);

            for (int i = 0; i < 6; i++)
            {
                manager.AddScore(new HighScore
                {
                    Size = "8x8",
                    Seconds = 10 + i,
                    Moves = 5 + i,
                    Seed = 123,
                    TimeStamp = System.DateTime.UtcNow
                });
            }

            var topScores = manager.GetScores("8x8").ToList();
            Assert.Equal(5, topScores.Count);
            Assert.True(topScores.All(s => s.Size == "8x8"));
        }

        public class InMemoryHighScoreRepository : IHighScoreRepository
        {
            private List<HighScore> _store = new();
            public List<HighScore> Load() => _store.ToList();
            public void Save(List<HighScore> scores) => _store = scores.ToList();
        }
    }
}
