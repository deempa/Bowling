using System;
using System.Collections.Generic;
using System.Text;

namespace Bowling
{
    public class Game
    {
        List<Frame> frames;
        public static int maxFrames = 10;
        int extraShots = 0;

        public Game()
        {
            frames = new List<Frame>();
        }

        public void RollBowling(int firstShot, int secondShot)
        {
            if (extraShots == 1)
            {
                frames[^1].AddExtra(firstShot);
                return;
            }
            else if (extraShots == 2)
            {
                frames[^1].AddExtra(firstShot + secondShot);
                frames[^2].AddExtra(firstShot);
                return;
            }

            if (frames.Count == maxFrames)
            {
                throw new GameoverException("Game is over");
            }

            var frame = new Frame(firstShot, secondShot);
            frames.Add(frame);

            if(frames.Count == maxFrames)
            {
                if (frame.IsSpare())
                {
                    extraShots = 1;
                }
                else if (frame.IsStrike())
                {
                    extraShots = 2;
                }
            }
        }

        private void UpdateFrames()
        {
            for(int i = 0; i < frames.Count; i++)
            {
                int points = 0;
                if (frames[i].IsStrike())
                {
                    points = PointsOfNextTwoRolls(i);
                }
                else if (frames[i].IsSpare())
                {
                    points = PointsOfNextRoll(i);
                }
                frames[i].AddExtra(points);
            }
        }

        public void PrintScoreboard()
        {
            UpdateFrames();
            foreach (Frame f in frames)
            {
                Console.WriteLine(String.Format("{0,3} | {1,3} | {2,3}", f.GetFirstShot(), f.GetSecondShot(), f.GetScore()));
            }
        }

        public int PointsOfNextTwoRolls(int currentFrame)
        {
            if(frames.Count <= currentFrame + 1)
            {
                return 0;
            }

            int nextRoll = frames[currentFrame + 1].GetFirstShot();
            int nextNextRoll = frames[currentFrame + 1].GetSecondShot();
            if(nextRoll != Frame.NumberOfPins)
            {
                return (nextRoll + nextNextRoll);
            }

            if(frames.Count <= currentFrame + 2)
            {
                return nextRoll;
            }

            nextNextRoll = frames[currentFrame + 2].GetFirstShot();
            return (nextRoll + nextNextRoll);
        }

        public int PointsOfNextRoll(int currentFrame)
        {
            if (frames.Count <= currentFrame + 1)
            {
                return 0;
            }

            return frames[currentFrame + 1].GetFirstShot();
        }

        public int GetScore()
        {
            UpdateFrames();
            int sum = 0;
            foreach(Frame f in frames)
            {
                sum += f.GetScore();
            }
            return sum;
        }

        public List<Frame> GetFrames()
        {
            UpdateFrames();
            return frames;
        }

        
        
        
    }
}
