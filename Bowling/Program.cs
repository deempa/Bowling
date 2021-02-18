using System;
using System.Collections.Generic;

namespace Bowling
{
    class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();
            var game = new Game();
            for(int i = 0; i < Game.maxFrames; i++)
            {
                int firstShot = random.Next(0, Frame.NumberOfPins);
                int secondShot = random.Next(0, Frame.NumberOfPins - firstShot + 1);
                game.RollBowling(firstShot, secondShot);
            }

            game.PrintScoreboard();
        }
    }
}
