using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Core.GameServices
{
    public class AdjacencyCalculator
    {
        public void Calculate(Tile[,] tiles, int rows, int cols)
        {
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    if (tiles[r, c].IsMine) continue;

                    int count = 0;

                    foreach (var (nr, nc) in GetNeighbors(r, c, rows, cols))
                    {
                        if (tiles[nr, nc].IsMine)
                            count++;
                    }
                    tiles[r, c].AdjacentMines = count;
                }
            }
            
        }

        private IEnumerable<(int, int)> GetNeighbors(int r, int c, int rows, int cols)
        {
            for (int dr = -1; dr <= 1; dr++)
            {
                for (int dc = -1; dc <= 1; dc++)
                {
                    if (dr == 0 && dc == 0) continue;

                    int nr = r + dr;
                    int nc = c + dr;

                    if (nr >= 0 && nr < rows && nc >= 0 && nc < cols)
                    {
                        yield return(nr, nc);
                    }
                }
            }
        }
    }
}
