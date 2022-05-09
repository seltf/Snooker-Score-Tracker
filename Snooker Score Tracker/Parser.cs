using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snooker_Score_Tracker
{
    public class Parser
    {
        public Parser() { }

        private string[] splittedInput;

        //public string parse(string input)
        //{
        //    string[] splittedInput = input.Split(' ');

        //    //Global Command
        //    switch (splittedInput[0])
        //    {
        //        case "pot":
        //            return splittedInput[1];
        //            break;
        //        case "stats":
        //            break;
        //        default:
        //            Console.WriteLine("Command not found.");
        //            break;
        //    }
        //}
        private void handlePot(string[] args)
        {
            var ball = args[1];
            switch (ball)
            {
                case "":
                    
                    break;
            }
        }

    }
}
