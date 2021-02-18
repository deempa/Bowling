using System;
using System.Collections.Generic;

namespace Bowling
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Welcome To The Bowling");
            var game = new Game();
            game.RollBowling(10, 0);
            game.RollBowling(10, 0);
            game.RollBowling(10, 0);
            game.RollBowling(10, 0);
            game.RollBowling(10, 0);
            game.RollBowling(10, 0);
            game.RollBowling(10, 0);
            game.RollBowling(10, 0);
            game.RollBowling(10, 0);
            game.RollBowling(10, 0);
            game.RollBowling(10, 10);

            game.PrintScoreboard();
        }
    }
}
