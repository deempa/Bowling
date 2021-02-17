using System;
using System.Collections.Generic;
using System.Text;

namespace Bowling
{
    public class Frame
    {
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
            return firstShot + secondShot == 10 && firstShot != 10;
        }

        public bool IsStrike()
        {
            return firstShot == 10;
        }

        public void AddExtra(int points)
        {
            this.score += points;
        }



    }
}
