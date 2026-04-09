using Minesweeper.Core.GameServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Core.Game.Game
{
    public class RevealService
    {
        public void Reveal(Tile[,] tiles, int rows, int cols, int r, int c)
        {
            if (!InBounds(r, c, rows, cols)) return;

            var tile = tiles[r, c];

            // stop if already flagged or revealed
            if (tile.IsRevealed || tile.IsFlagged) return;

            // reveal this tile
            tile.IsRevealed = true;

            // if tile has adjacent mines, stop recursion
            if (tile.AdjacentMines == 0 && !tile.IsMine)
            {
                foreach (var (nr, nc) in GetNeighbors(r, c, rows, cols))
                {
                    Reveal(tiles, rows, cols, nr, nc);
                }
            }
        }

        private bool InBounds(int r, int c, int rows, int cols) 
            => r >= 0 && r < rows && c >= 0 && c < cols;

        private IEnumerable<(int, int)> GetNeighbors(int r, int c, int rows, int cols)
        {
            for (int dr = -1; dr <= 1; dr++)
            {
                for (int dc = -1; dc <= 1; dc++)
                {
                    if (dr == 0 && dc == 0) continue;

                    int nr = r + dr;
                    int nc = c + dc;

                    if (nr >= 0 && nr < rows && nc >= 0 && nc < cols)
                    {
                        yield return (nr, nc);
                    }
                }
            }
        }
    }
}
