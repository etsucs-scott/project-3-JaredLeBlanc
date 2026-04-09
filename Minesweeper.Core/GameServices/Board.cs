using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Core.GameServices.Game
{
    public class Board
    {
        public int Rows { get; }
        public int Cols { get; }
        public Tile[,] Tiles { get; }

        public Board(int rows, int cols)
        {
            Rows = rows;
            Cols = cols;

            Tiles = new Tile[rows, cols];

            for (int r = 0; r < rows; r++)
            {
                for (int c  = 0; c < cols; c++)
                {
                    Tiles[r, c] = new Tile();
                }
            }
        }
    }
}
