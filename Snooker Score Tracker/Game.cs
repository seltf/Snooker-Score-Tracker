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
            Console.WriteLine($"It is {activePlayer.name}'s turn.");
        }
        public int calcPointsRequiredToWin(Player player) 
        {
            // 74 points to win frame
            return 74 - player.score;
        }
        public void score(Player player, Ball ball)
        {
            player.currentBreak += ball.value;
            player.score += ball.value;
        }
        public void foul(Player currentPlayer, Ball ball)
        {
            // high colours award the value of the colour
            if (ball.value > 4) 
            {
                otherPlayer(currentPlayer).score += ball.value;
                Console.WriteLine($"{otherPlayer(currentPlayer).name} has been awarded {ball.value} points.");
            }
            // low colours award 4 points
            else
            {
                otherPlayer(currentPlayer).score += 4;
                Console.WriteLine($"{otherPlayer(currentPlayer).name} has been awarded 4 points.");
            }
            switchPlayer();
        }
        public void foul(Player currentPlayer)
        {
            otherPlayer(currentPlayer).score += 4;
            Console.WriteLine($"{otherPlayer(currentPlayer).name} has been awarded 4 points.");
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
                    score(currentPlayer, ball);
                }
                //no
                else
                {                    
                    Console.WriteLine($"{currentPlayer.name} potted a ball not on.");
                    foul(currentPlayer, ball);
                    return;
                }
            }

            // foul if pot two reds in a row
            if  (currentPlayer.ballLastPotted == Ball.RED && ball.value == Ball.RED)
            {
                Console.WriteLine("You must pot a colour after potting a red.");
                foul(currentPlayer);
                return;
            }

            // did you pot a red before a colour?
            if (ball.value > 1 && currentPlayer.ballLastPotted != 1)
            {
                Console.WriteLine("You must pot a red before potting a colour.");
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
