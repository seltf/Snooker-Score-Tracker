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
    }
}
