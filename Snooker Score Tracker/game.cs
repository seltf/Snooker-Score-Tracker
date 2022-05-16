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
            int score = redsRemaining * Table.RED;

            //value of each subsequent black
            score += redsRemaining * Table.BLACK;

            //value of clearing remaining colours
            score += Table.YELLOW;
            score += Table.GREEN;
            score += Table.BROWN;
            score += Table.BLUE;
            score += Table.PINK;
            score += Table.BLACK;
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
