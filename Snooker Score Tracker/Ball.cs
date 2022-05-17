using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snooker_Score_Tracker
{
    internal class Ball
    {
        public const int RED = 1;
        public const int YELLOW = 2;
        public const int GREEN = 3;
        public const int BROWN = 4;
        public const int BLUE = 5;
        public const int PINK = 6;
        public const int BLACK = 7;

        public string colour { get; set; }
        public int value { get; set; }
        public Ball(string s,int i)
        {
            colour = s;
            value = i;
        }
    }
}
