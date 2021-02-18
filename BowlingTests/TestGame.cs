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
            game.RollBowling(Frame.NumberOfPins - 1, 0);

            var frames = game.GetFrames();
            Assert.AreEqual(1, frames.Count);
        }  
        
        [Test]
        public void TestStrikeFrameUpdatedWithBonus()
        {
            var game = new Game();
            game.RollBowling(Frame.NumberOfPins, 0);
            game.RollBowling(Frame.NumberOfPins - 1, 0);

            var frames = game.GetFrames();
            Assert.AreEqual(Frame.NumberOfPins * 2 - 1, frames[0].GetScore());
        }  
        
        [Test]
        public void TestSpareFrameUpdatedWithBonus()
        {
            var game = new Game();
            game.RollBowling(Frame.NumberOfPins - 1, 1);
            game.RollBowling(2, 0);

            var frames = game.GetFrames();
            Assert.AreEqual(Frame.NumberOfPins + 2, frames[0].GetScore());
        }   
        
        [Test]
        public void TestTwoStrikesFrameUpdatedWithBonus()
        {
            var game = new Game();
            game.RollBowling(Frame.NumberOfPins, 0);
            game.RollBowling(Frame.NumberOfPins, 0);
            game.RollBowling(1, 0);
            
            var frames = game.GetFrames();
            Assert.AreEqual(Frame.NumberOfPins + Frame.NumberOfPins + 1, frames[0].GetScore());
            Assert.AreEqual(Frame.NumberOfPins + 1, frames[1].GetScore());
            Assert.AreEqual(1, frames[2].GetScore());
        }

        [Test]
        public void TestThreeStrikesFrameUpdatedWithBonus()
        {
            var game = new Game();
            game.RollBowling(Frame.NumberOfPins, 0);
            game.RollBowling(Frame.NumberOfPins, 0);
            game.RollBowling(Frame.NumberOfPins, 0);

            var frames = game.GetFrames();
            Assert.AreEqual(Frame.NumberOfPins * 3, frames[0].GetScore());
            Assert.AreEqual(Frame.NumberOfPins * 2, frames[1].GetScore());
            Assert.AreEqual(Frame.NumberOfPins, frames[2].GetScore());
        }

        [Test]
        public void TestGameover()
        {
            var game = new Game();
            for(int i = 0; i < Game.maxFrames; i++)
            {
                game.RollBowling(1, 0);
            }

            Assert.Throws<GameoverException>(() => game.RollBowling(1, 0));
        }

        [Test]
        public void TestStrikeInLastFrame()
        {
            var game = new Game();
            for(int i = 0; i < Game.maxFrames - 1; i++)
            {
                game.RollBowling(1, 0);
            }
            game.RollBowling(Frame.NumberOfPins, 0);
            
            Assert.DoesNotThrow(() => game.RollBowling(1, 1));
            Assert.AreEqual(game.GetFrames()[^1].GetScore(), Frame.NumberOfPins + 2);
        }

        [Test]
        public void TestSpareInLastFrame()
        {
            var game = new Game();
            for (int i = 0; i < Game.maxFrames - 1; i++)
            {
                game.RollBowling(1, 0);
            }
            game.RollBowling(0, Frame.NumberOfPins);

            Assert.DoesNotThrow(() => game.RollBowling(1, 0));
            Assert.AreEqual(Frame.NumberOfPins + 1, game.GetFrames()[^1].GetScore());
        }

        [Test]
        public void TestPerfectGame()
        {
            var game = new Game();
            for (int i = 0; i < Game.maxFrames; i++)
            {
                game.RollBowling(Frame.NumberOfPins, 0);
            }
            game.RollBowling(Frame.NumberOfPins, Frame.NumberOfPins);
            
            Assert.AreEqual(Game.maxFrames * (Frame.NumberOfPins * 3), game.GetScore());
        }
    }
}