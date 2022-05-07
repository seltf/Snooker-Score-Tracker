using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snooker_Score_Tracker
{
    internal class game
    {
        public player playerOne { get; set; }
        public player playerTwo { get; set; }
        public table table { get; set; }


        public int calcRemainingPoints(int reds)
        {
            //value of each red remaining
            int score = reds * table.RED;

            //value of each subsequent black
            score += reds * table.BLACK;

            //value of clearing remaining colours
            score += table.YELLOW;
            score += table.GREEN;
            score += table.BROWN;
            score += table.BLUE;
            score += table.PINK;
            score += table.BLACK;
            return score;
        }
    }
}
