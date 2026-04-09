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
    public class CsvParser : IHighScoreParser
    {
        private const string Header = "size,seconds,moves,seed,timestamp";

        public string GetHeader() => Header;

        public HighScore? Parse(string line)
        {
            try
            {
                var parts = line.Split(',');

                if (parts.Length != 5)
                {
                    return null;
                }

                return new HighScore
                {
                    Size = parts[0],
                    Seconds = int.Parse(parts[1]),
                    Moves = int.Parse(parts[2]),
                    Seed = int.Parse(parts[3]),
                    TimeStamp = DateTime.Parse(parts[4], null, DateTimeStyles.RoundtripKind)
                };
            }

            catch
            {
                return null;
            }
        }

        public string Format(HighScore score)
        {
            return $"{score.Size},{score.Seconds},{score.Moves},{score.Seed},{score.TimeStamp}";
        }
    }
}
