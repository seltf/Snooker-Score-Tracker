using System;
using System.Linq;

namespace Snooker_Score_Tracker
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("sels snooker score tracker");
            Console.WriteLine("==========================");

            //creating players
            Player playerOne = new Player();
            Player playerTwo = new Player();

            Console.WriteLine("Enter player one's name: ");
            playerOne.name = Console.ReadLine();

            Console.WriteLine("Enter player two's name: ");
            playerTwo.name = Console.ReadLine();

            //creating balls
            Ball red = new Ball("red", 1);
            Ball yellow = new Ball("yellow", 2);
            Ball green = new Ball("green", 3);
            Ball brown = new Ball("brown", 4);
            Ball blue = new Ball("blue", 5);
            Ball pink = new Ball("pink", 6);
            Ball black = new Ball("black", 7);

            //create table
            Table table = new Table();
            table.respotBall(red, 15);
            table.respotBall(yellow, 1);
            table.respotBall(green, 1);
            table.respotBall(brown, 1);
            table.respotBall(blue, 1);
            table.respotBall(pink, 1);
            table.respotBall(black, 1);
            
            //creating game
            Game game = new Game();
            game.table = table;

            int redsRemaining = table.count(red);
            Console.WriteLine($"Max Remaining: {game.calcRemainingPoints(redsRemaining)}");
            

            Parser parser = new Parser();
            while (game.table.isTableClear(table) == false) // ??
            {
                var input = Console.ReadLine().Split(' ');

                // string -> Ball.colour
                var activePlayer = playerOne;

                switch (input[0])
                {
                    case "pot":
                        game.table.potBall(activePlayer, game.table.tableState.First(b => b.colour == input[1]));
                        break;
                    case "stats":
                        break;
                    default:
                        Console.WriteLine("Command not found.");
                        break;
                }

            }
            
            
        }
    }
}
