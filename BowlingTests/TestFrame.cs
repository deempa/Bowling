using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bowling;

namespace BowlingTests
{
    [TestFixture]
    public class TestFrame
    {
        [Test]
        public void TestFrameIsSpare()
        {
            var frame = new Frame(4, 6);

            Assert.IsTrue(frame.IsSpare());
        }   
        
        [Test]
        public void TestFrameIsStrike()
        {
            var frame = new Frame(10, 0);

            Assert.IsTrue(frame.IsStrike());
        }   
        
        [Test]
        public void TestFrameIsNotStrikeAndNotSpare()
        {
            var frame = new Frame(5, 3);

            Assert.IsFalse(frame.IsStrike());
            Assert.IsFalse(frame.IsSpare());
        } 
    }
}
