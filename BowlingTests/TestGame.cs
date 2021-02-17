using Bowling;
using NUnit.Framework;

namespace BowlingTests
{
    public class Tests
    {
        [Test]
        public void TestRollingChangeFrameSizeToOne()
        {
            var game = new Game();
            game.RollBowling(7, 2);

            var frames = game.GetFrames();
            Assert.AreEqual(1, frames.Count);
        }  
        
        [Test]
        public void TestStrikeFrameUpdatedWithBonus()
        {
            var game = new Game();
            game.RollBowling(10, 0);
            game.RollBowling(7, 2);
            
            var frames = game.GetFrames();
            Assert.AreEqual(19, frames[0].GetScore());
        }  
        
        [Test]
        public void TestSpareFrameUpdatedWithBonus()
        {
            var game = new Game();
            game.RollBowling(5, 5);
            game.RollBowling(7, 2);
            
            var frames = game.GetFrames();
            Assert.AreEqual(17, frames[0].GetScore());
        }   
        
        [Test]
        public void TestTwoStrikesFrameUpdatedWithBonus()
        {
            var game = new Game();
            game.RollBowling(10, 0);
            game.RollBowling(10, 0);
            game.RollBowling(5, 4);
            
            var frames = game.GetFrames();
            Assert.AreEqual(25, frames[0].GetScore());
            Assert.AreEqual(15, frames[1].GetScore());
            Assert.AreEqual(9, frames[2].GetScore());
        }
    }
}