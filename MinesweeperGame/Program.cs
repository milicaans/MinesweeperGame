using Minesweeper.Game;
using System;
namespace Minesweeper
{
    public class Program
    {
        static void Main(string[] args)
        {
            var game = new Minefield(8, 8, 10, 3); 
            game.Start();
        }
    }
}