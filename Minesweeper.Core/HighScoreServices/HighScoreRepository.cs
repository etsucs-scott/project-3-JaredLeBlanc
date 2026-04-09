using Minesweeper.Core.GameServices;
using Minesweeper.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Core.HighScoreServices
{
    public class HighScoreRepository : IHighScoreRepository
    {
        private string _filepath { get; }
        private IHighScoreParser _parser { get; }

        public HighScoreRepository(string filepath, IHighScoreParser parser)
        {
            _filepath = filepath;
            _parser = parser;
        }

        public List<HighScore> Load()
        {
            var scores = new List<HighScore>();

            try
            {
                EnsureFileExist();

                var lines = File.ReadAllLines(_filepath);

                foreach (var line in lines.Skip(1))
                {
                    var score = _parser.Parse(line);

                    if (score != null)
                    {
                        scores.Add(score);
                    }
                }
            }

            catch
            {
                return new List<HighScore>();
            }

            return scores;
        }

        public void Save(List<HighScore> scores)
        {
            try
            {
                EnsureFileExist();

                var lines = new List<string>
                {
                    _parser.GetHeader()
                };

                lines.AddRange(scores.Select(s => _parser.Format(s)));

                File.WriteAllLines(_filepath, lines);
            }

            catch
            {
                // fail silently
            }
        }

        private void EnsureFileExist()
        {
            var dir = Path.GetDirectoryName(_filepath);

            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir!);
            }

            if (!File.Exists(_filepath))
            {
                File.WriteAllText(_filepath, _parser.GetHeader() + "\n");
            }
        }
    }
}
