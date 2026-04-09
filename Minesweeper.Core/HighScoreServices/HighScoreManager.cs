using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Minesweeper.Core.Interfaces;
using Minesweeper.Core.GameServices;

namespace Minesweeper.Core.HighScoreServices
{
    public class HighScoreManager : IHighScoreManager
    {
        private  IHighScoreRepository _repo { get; }

        public HighScoreManager(IHighScoreRepository repo)
        {
            _repo = repo;
        }

        public List<HighScore> GetScores(string size)
        {
            return _repo.Load()
                .Where(s => s.Size == size)
                .OrderBy(s => s.Seconds)
                .ThenBy(s => s.Moves)
                .ToList();
        }

        public void AddScore(HighScore newScore)
        {
            var allScores = _repo.Load();

            var updated = allScores
                .Where(s => s.Size != newScore.Size)
                .Concat(
                    allScores
                        .Where(s => s.Size == newScore.Size)
                        .Append(newScore)
                        .OrderBy(s => s.Seconds)
                        .ThenBy(s => s.Moves)
                        .Take(5)
                )
                .ToList();

            _repo.Save(updated);
        }

    }
}
