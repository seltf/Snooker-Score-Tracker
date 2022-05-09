using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snooker_Score_Tracker
{
    internal class Ball
    {
      
        public string colour { get; set; }
        public int value { get; set; }
        public Ball(string s,int i)
        {
            colour = s;
            value = i;
        }
        public void createBalls() 
        {
            Ball red = new Ball("red", 1);
            Ball yellow = new Ball("yellow", 2);
            Ball green = new Ball("green", 3);
            Ball brown = new Ball("brown", 4);
            Ball blue = new Ball("blue", 5);
            Ball pink = new Ball("pink", 6);
            Ball black = new Ball("black", 7);
        }
    }
}
