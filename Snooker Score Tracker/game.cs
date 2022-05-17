using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snooker_Score_Tracker
{
    internal class Game
    {
        public Player playerOne { get; set; }
        public Player playerTwo { get; set; }
        public Table table { get; set; }


        public int calcRemainingPoints(int redsRemaining)
        {
            //value of each red remaining
            int score = redsRemaining * Ball.RED;

            //value of each subsequent black
            score += redsRemaining * Ball.BLACK;

            //value of clearing remaining colours
            score += Ball.YELLOW;
            score += Ball.GREEN;
            score += Ball.BROWN;
            score += Ball.BLUE;
            score += Ball.PINK;
            score += Ball.BLACK;
            return score;
        }      
        public void foul()
        {
            // not yet implemented
        }
        public int calcPointsRequiredToWin(Player player) // 74 points to win frame
        {
            return 74 - player.score;
        }
    }
}
