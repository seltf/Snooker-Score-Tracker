using System;

namespace Snooker_Score_Tracker
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("sels snooker score tracker");
            Console.WriteLine("==========================");

            //creating players
            player playerOne = new player();
            player playerTwo = new player();

            Console.WriteLine("Enter player one's name: ");
            playerOne.name = Console.ReadLine();

            Console.WriteLine("Enter player two's name: ");
            playerTwo.name = Console.ReadLine();

            //create table
            table table = new table();
            table.redRemaining = 15;

            //creating game
            game game = new game();
            game.table = table;


            Console.WriteLine($"Max Remaining: {game.calcRemainingPoints(table.redRemaining)}");
        }
    }
}
