using Minesweeper.Core.GameServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Core.Interfaces
{
    public interface IHighScoreManager
    {
        List<HighScore> GetScores(string size);

        void AddScore(HighScore score);
    }
}
