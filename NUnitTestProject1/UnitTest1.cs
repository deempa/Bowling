using NUnit.Framework;
using Bowling;


namespace NUnitTestProject1
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            var game = new Game();
            game.RollBowling(7, 3);


            var frames = game.GetFrames();

            Assert.AreEqual(2, frames.Count);
        }
    }
}