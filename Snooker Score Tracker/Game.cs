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
        public Player activePlayer { get; set; }


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
        public void switchPlayer()
        {
            activePlayer.currentBreak = 0;
            activePlayer = otherPlayer(activePlayer);     
        }
        public int calcPointsRequiredToWin(Player player) 
        {
            // 74 points to win frame
            return 74 - player.score;
        }
        public void foul(Player currentPlayer, Ball ball)
        {
            // high colours award the value of the colour
            if (ball.value > 4) 
            {
                otherPlayer(currentPlayer).score += ball.value;
            }
            // low colours award 4 points
            else
            {
                otherPlayer(currentPlayer).score += 4;
            }
            switchPlayer();
        }
        public void foul(Player currentPlayer)
        {
            otherPlayer(currentPlayer).score += 4;
            switchPlayer();
        }
        public void ballHandler(Player currentPlayer, Ball ball) // :^)
        {
            // pots ball
            table.potBall(ball);

            // is first ball in the break?
            if (currentPlayer.ballLastPotted == 0)
            {
                // is it red?
                if (ball.value == Ball.RED)
                {
                    currentPlayer.score += ball.value;
                }
                //no
                else
                {
                    foul(currentPlayer, ball);
                    Console.WriteLine($"{currentPlayer.name} potted a ball not on.");
                    return;
                }
            }

            // foul if pot two reds in a row
            if  (currentPlayer.ballLastPotted == Ball.RED && ball.value == Ball.RED)
            {
                foul(currentPlayer);
                return;
            }

            // did you pot a red before a colour?
            if (ball.value > 1 && currentPlayer.ballLastPotted != 1)
            {
                foul(currentPlayer,ball);
                return;
            }

            // update last ball potted
            currentPlayer.ballLastPotted = ball.value;

            // add points to totals
            //player.currentBreak += ball.value;
            //player.score += ball.value;
        }      
    }
}
