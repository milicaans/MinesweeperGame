using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Game
{
    public class Player
    {
        public int PositionX { get; private set; }
        public int PositionY { get; private set; }
        public int Lives { get; private set; }
        public bool HasLost => Lives <= 0;

        public Player(int startX, int startY, int lives)
        {
            PositionX = startX;
            PositionY = startY;
            Lives = lives;
        }

        public bool Move(int deltaX, int deltaY, int maxRows, int maxCols)
        {
            int newX = PositionX + deltaX;
            int newY = PositionY + deltaY;

            if (newX < 0 || newX >= maxRows || newY < 0 || newY >= maxCols)
            {
                Console.WriteLine("Invalid move!");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }

            PositionX = newX;
            PositionY = newY;
            return true;
        }

        public void LoseLife() 
        {
            Lives--;
        }

        public bool HasWon(int goalRow, int goalCol)
        {
            return PositionX == goalRow && PositionY == goalCol;
        }
    }
}