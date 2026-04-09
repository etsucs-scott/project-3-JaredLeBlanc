using System;
using Minesweeper.Core.GameServices.Game;

namespace Minesweeper.ConsoleApp
{
    public class Renderer
    {
        public void Render(Game game, bool revealAll = false)
        {
            var board = game.Board;

            // Column headers
            Console.Write("   ");
            for (int c = 0; c < board.Cols; c++)
            {
                Console.Write($"{c,2} ");
            }
            Console.WriteLine();

            for (int r = 0; r < board.Rows; r++)
            {
                Console.Write($"{r,2} ");
                for (int c = 0; c < board.Cols; c++)
                {
                    var t = board.Tiles[r, c];

                    char ch = '#';

                    if (t.IsFlagged && !revealAll)
                    {
                        ch = 'f'; // flagged tile
                    }
                    else if (t.IsRevealed || revealAll)
                    {
                        if (t.IsMine)
                        {
                            ch = 'b'; // bomb
                        }
                        else if (t.AdjacentMines == 0)
                        {
                            ch = '.'; // empty 
                        }
                        else
                        {
                            ch = t.AdjacentMines.ToString()[0]; // number 1-8
                        }
                    }
                    Console.Write($"{ch,2} ");
                }

                Console.WriteLine();
            }
        }

    }
}
