using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Minesweeper.ConsoleApp.Interfaces;
using Minesweeper.ConsoleApp.Commands;
using Minesweeper.Core.GameServices.Game;

namespace Minesweeper.ConsoleApp
{
    public class InputHandler
    {
        public ICommands? ReadCommand(Game game)
        {
            
            var input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                return null;
            }

            var parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            try
            {
                if (parts[0] == "q")
                {
                    return null;
                }

                if (parts.Length != 3)
                {
                    throw new Exception();
                }

                int r = int.Parse(parts[1]);
                int c = int.Parse(parts[2]);

                return parts[0] switch
                {
                    "r" => new RevealCommand(r, c),
                    "f" => new FlagCommand(r, c),
                    _ => null
                };
            }
            catch
            {
                Console.WriteLine("Invalid Input! Format like: r 0 1 or f 1 3");
                Thread.Sleep(2000);
                return null;
            }
        }
    }
}
