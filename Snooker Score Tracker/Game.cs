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
        public Player otherPlayer(Player currentPlayer)
        {
            if (currentPlayer == playerOne)
            {
                return playerTwo;
            }
            if (currentPlayer == playerTwo)
            {
                return playerOne;
            }
            Console.WriteLine("otherPlayer is broken.");
            return currentPlayer;
        }
        public int calcPointsRequiredToWin(Player player) // 74 points to win frame
        {
            return 74 - player.score;
        }
        public void ballHandler(Player currentPlayer, Ball ball) // :^)
        {
            // pots ball
            table.potBall(ball);

            // is first ball in the break?
            if (currentPlayer.ballLastPotted == 0)
            {
                // is it red?
                if (currentPlayer.ballLastPotted == Ball.RED)
                {
                    currentPlayer.score += ball.value;
                }
                //no
                else
                {
                    // foul
                    if (currentPlayer.ballLastPotted > 4)
                    {
                        otherPlayer(currentPlayer).score += ball.value;
                    }
                    else
                    {
                        otherPlayer(currentPlayer).score += 4;
                    }
                }
            }

            // foul if pot two reds in a row
            if  (currentPlayer.ballLastPotted == Ball.RED && ball.value != Ball.RED)
            {
                otherPlayer(currentPlayer).score += 4;
            }

            currentPlayer.ballLastPotted = ball.value;

            // add points to totals
            //player.currentBreak += ball.value;
            //player.score += ball.value;
        }
        
    }
}
