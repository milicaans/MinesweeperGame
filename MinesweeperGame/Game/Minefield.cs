using MinesweeperGame.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Game
{
    public class Minefield
    {
        private readonly Board _board;
        private readonly Player _player;
        private int _movesTaken;

        public Minefield(int rows, int cols, int mineCount, int lives)
        {
            _board = new Board(rows, cols, mineCount);
            _player = new Player(0, 0, lives);
        }

        public Player GetPlayer()
        {
            return _player;
        }

        public Board GetBoard()
        {
            return _board;
        }
        public void Start()
        {
            Console.WriteLine("Welcome to Minesweeper!");
            Console.WriteLine($"Navigate from A1 to {Board.ConvertPositionAsChess(_board.Rows - 1, _board.Cols - 1)}");

            while (!_player.HasLost && !_player.HasWon(_board.Rows - 1, _board.Cols - 1))
            {
                _board.DisplayBoard(_player.PositionX, _player.PositionY);
                string playerPosition = Board.ConvertPositionAsChess(_player.PositionX, _player.PositionY);
                Console.WriteLine($"Position: {playerPosition}, Lives: {_player.Lives}, Moves: {_movesTaken}");
                Console.Write("Enter move (up, down, left, right): ");
                string? input = Console.ReadLine()?.ToLower();

                if (string.IsNullOrWhiteSpace(input) || !TryMove(input)) continue;

                _movesTaken++;
                if (_board.IsMine(_player.PositionX, _player.PositionY))
                {
                    _board.MarkMineHit(_player.PositionX, _player.PositionY); 
                    _player.LoseLife();
                    Console.WriteLine("Oh no! You hit a mine!");
                }
            }

            Console.WriteLine(_player.HasLost ? "Game Over! You lost all your lives." : "Congratulations! You made it!");
            Console.WriteLine($"Total moves taken: {_movesTaken}");
        }
        private bool TryMove(string direction)
        {
            return direction switch
            {
                "up" => _player.Move(-1, 0, _board.Rows, _board.Cols),
                "down" => _player.Move(1, 0, _board.Rows, _board.Cols),
                "left" => _player.Move(0, -1, _board.Rows, _board.Cols),
                "right" => _player.Move(0, 1, _board.Rows, _board.Cols),
                _ => false  
            };
        }
    }
}
