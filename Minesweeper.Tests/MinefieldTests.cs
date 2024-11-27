using Xunit;
using Minesweeper.Game;

namespace Minesweeper.Tests.Game
{
    public class MinefieldTests
    {
        [Fact]
        public void PlayerShouldNotLoseLife()
        {
            var minefield = new Minefield(8, 8, 1, 3); 
            var player = minefield.GetPlayer();       
            var board = minefield.GetBoard();

            player.Move(0, 0, board.Rows, board.Cols); 

            Assert.Equal(3, player.Lives); 
        }
    }
}
