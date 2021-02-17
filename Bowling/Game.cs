using System;
using System.Collections.Generic;
using System.Text;

namespace Bowling
{
    public class Game
    {
        List<Frame> frames;

        public Game()
        {
            frames = new List<Frame>();
        }

        public void RollBowling(int firstShot, int secondShot)
        {
            var frame = new Frame(firstShot, secondShot);
            if (frames.Count > 0)
            {
                var lastFrame = frames[^1];
                if (lastFrame.IsSpare())
                {
                    lastFrame.AddExtra(firstShot);
                }
                else if(lastFrame.IsStrike())
                {
                    lastFrame.AddExtra(firstShot + secondShot);
                }
            }
            frames.Add(frame);
        }

        public void PrintScoreboard()
        {
            foreach(Frame f in frames)
            {
                Console.WriteLine(String.Format("{0,3} | {1,3} | {2,3}", f.GetFirstShot(), f.GetSecondShot(), f.GetScore()));
            }
        }

        public List<Frame> GetFrames()
        {
            return frames;
        }

        
        
        
    }
}
