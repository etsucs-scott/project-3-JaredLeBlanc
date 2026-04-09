using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Core.GameServices
{
    public class HighScore
    {
        public string Size { get; set; } = "";
        public int Seconds { get; set; } 
        public int Moves { get; set; }
        public int Seed { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
