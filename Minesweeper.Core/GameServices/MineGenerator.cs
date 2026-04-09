using Minesweeper.Core.GameServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Core.Game.Game
{
    public class MineGenerator
    {
        public void PlaceMines(Tile[,] tiles, int rows, int cols, int mineCount, int seed)
        {
            var rand = new Random(seed);
            int placed = 0;

            while (placed < mineCount)
            {
                int r = rand.Next(rows);
                int c = rand.Next(cols);

                if (!tiles[r, c].IsMine)
                {
                    tiles[r, c].IsMine = true;
                    placed++;
                }
            }

        }
    }
}
