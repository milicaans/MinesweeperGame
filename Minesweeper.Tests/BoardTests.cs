using MinesweeperGame.Game;
using MiNET.Entities.Vehicles;
using Xunit;

namespace Minesweeper.Tests.Game
{
    public class BoardTests
    {
        [Fact]
        public void BoardShouldBeCreatedSuccesfully()
        {
            var board = new Board(5, 5, 5); 

            var rows = board.Rows;
            var cols = board.Cols;

            Assert.Equal(5, rows);
            Assert.Equal(5, cols);
        }
        [Fact]
        public void MarkMineHit()
        {
            var board = new Board(5, 5, 1);
            var row = 2;
            var col = 2;
            board.SetMine(row, col); 

            board.MarkMineHit(row, col);

            Assert.True(board.IsMine(row, col), "Mark X for mine");
        }
    }
}
