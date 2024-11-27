using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinesweeperGame.Game
{
    public class Board
    {
        public int Rows { get; }
        public int Cols { get; }
        private readonly bool[,] _mines;
        private readonly bool[,] _steppedOnMines;

        public Board(int rows, int cols, int mineCount)
        {
            Rows = rows;
            Cols = cols;
            _mines = new bool[rows, cols];
            _steppedOnMines = new bool[rows, cols];
            PlaceMines(mineCount);
        }
        public bool IsMine(int row, int col) => _mines[row, col];

        public void MarkMineHit(int row, int col)
        {
            _steppedOnMines[row, col] = true;
        }

        public void DisplayBoard(int playerRow, int playerCol)
        {
            Console.Clear();
            Console.Write("  ");
            for (int c = 0; c < Cols; c++)
            {
                Console.Write($"{c + 1} "); 
            }
            Console.WriteLine();
            for (int r = 0; r < Rows; r++)
            {
                Console.Write($"{(char)('A' + r)} "); 
                for (int c = 0; c < Cols; c++)
                {
                    if (r == playerRow && c == playerCol)
                    {
                        Console.Write("P "); 
                    }
                    else if (_steppedOnMines[r, c])
                    {
                        Console.Write("X "); 
                    }
                    else
                    {
                        Console.Write("- "); 
                    }
                }
                Console.WriteLine();
            }
        }

        private void PlaceMines(int mineCount)
        {
            var random = new Random();
            int placed = 0;

            while (placed < mineCount)
            {
                int row = random.Next(Rows);
                int col = random.Next(Cols);

                if (!_mines[row, col])
                {
                    _mines[row, col] = true;
                    placed++;
                }
            }
        }
        public void SetMine(int row, int col)
        {
            if (row >= 0 && row < Rows && col >= 0 && col < Cols)
            {
                _mines[row, col] = true;
            }
        }

        public static string ConvertPositionAsChess(int row, int col)
        {
            char letter = (char)('A' + row); 
            int number = col + 1;            
            return $"{letter}{number}";
        }
    }
}