using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snooker_Score_Tracker
{
    class table
    {
        public const int RED = 1;
        public const int YELLOW = 2;
        public const int GREEN = 3;
        public const int BROWN = 4;
        public const int BLUE = 5;
        public const int PINK = 6;
        public const int BLACK = 7;
        public Dictionary<string, int> ballsRemaining { get; set; }

        public int redRemaining { get; set; }

    }
}
