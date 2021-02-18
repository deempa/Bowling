using System;
using System.Collections.Generic;
using System.Text;

namespace Bowling
{
    public class Frame
    {
        public static int NumberOfPins = 10;

        int firstShot;
        int secondShot;
        int score;

        public Frame(int firstShot, int secondShot)
        {
            this.firstShot = firstShot;
            this.secondShot = secondShot;
            this.score = firstShot + secondShot;
        }

        public int GetFirstShot()
        {
            return firstShot;
        }   
        
        public int GetSecondShot()
        {
            return secondShot;
        }     
        
        public int GetScore()
        {
            return score;
        }

        public bool IsSpare()
        {
            return firstShot + secondShot == NumberOfPins && firstShot != NumberOfPins;
        }

        public bool IsStrike()
        {
            return firstShot == NumberOfPins;
        }

        public void AddExtra(int points)
        {
            this.score += points;
        }



    }
}
