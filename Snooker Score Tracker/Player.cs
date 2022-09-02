using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snooker_Score_Tracker
{
    class Player
    {
        public int playerNumber { get; set; }
        public string name { get; set; }
        public int score { get; set; }
        public int currentBreak { get; set; }
        public int ballLastPotted { get; set; } = 0;
    }
}
