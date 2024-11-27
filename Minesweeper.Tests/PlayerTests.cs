using Minesweeper.Game;
using System.Numerics;
using Xunit;

namespace Minesweeper.Tests.Game
{
    public class PlayerTests
    {
        [Fact]
        public void CreatePlayerSuccessfully()
        {
            var player = new Player(0, 0, 3); 

            Assert.Equal(0, player.PositionX);
            Assert.Equal(0, player.PositionY);
            Assert.Equal(3, player.Lives);
            Assert.False(player.HasLost);
        }

        [Fact]
        public void PlayerChangePosition()
        {
            var player = new Player(0, 0, 3);

            bool moved = player.Move(1, 0, 5, 5); 

            Assert.True(moved);
            Assert.Equal(1, player.PositionX);
            Assert.Equal(0, player.PositionY);
        }
    }
}