using Minesweeper.Core.GameServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Core.Game.Game
{
    public class WinChecker
    {
        public bool IsWin(Tile[,] tiles)
        {
            foreach (var tile in tiles)
            {
                if (!tile.IsMine && !tile.IsRevealed)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
