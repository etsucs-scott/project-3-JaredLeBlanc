using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Minesweeper.Core.GameServices.Game;

namespace Minesweeper.ConsoleApp.Interfaces
{
    public interface ICommands
    {
        void Execute(Game game);
    }
}
