using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Minesweeper.ConsoleApp.Interfaces;
using Minesweeper.Core.GameServices.Game;

namespace Minesweeper.ConsoleApp.Commands
{
    public  class RevealCommand : ICommands
    {
        private readonly int _r;
        private readonly int _c;

        public RevealCommand(int r, int c)
        {
            _r = r;
            _c = c;
        }

        public void Execute(Game game)
        {
            game.Reveal(_r, _c);
        }
    }
}
