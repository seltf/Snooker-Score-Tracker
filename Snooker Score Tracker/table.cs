using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snooker_Score_Tracker
{
    class Table
    {
        public List<Ball> tableState { get; set; } = new List<Ball>(); // ball, quantity

        public int redsRemaining { get; set; }
        
        public void respotBall(Ball ball, int quantity)
        {
            for (int i = 0; i < quantity; i++)
            {
                tableState.Add(ball);
            }
        }
        public int count(Ball ball)
        {
            return this.tableState.Where(b=>b.colour == ball.colour).Count();
        }
        /// <summary>
        /// Returns true if the table has been cleared.
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public bool isTableClear(Table table)
        {
            bool isClear = false;
            return isClear;
        }
        public bool searchTable(Ball ball)
        {
            bool ballPresent = false;

            if (this.tableState.Contains(ball))
            {
                ballPresent = true;
            }
            else
            {
                ballPresent = false;
            }

            return ballPresent;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="player"></param>
        /// <param name="table"></param>
        /// <param name="ball"></param>
        public void potBall(Player player, Ball ball)
        {
            // check if ball is on table
            bool ballPresent = searchTable(ball);
            if (ballPresent)
            {
                // add points to totals
                player.currentBreak += ball.value;
                player.score += ball.value;

                // remove red ball from table
                if (ball.colour == "red")
                {
                    this.tableState.Remove(ball);
                }
                int reds = this.tableState.Where(b => b.colour == "red").Count();

                if (reds == 0 && ball.value != 1)
                {
                    this.tableState.Remove(ball);
                }
            }
            else
            {
                Console.WriteLine("Ball not on table.");
            }
        }
    }
}
