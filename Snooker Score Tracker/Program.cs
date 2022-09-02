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
            //Player playerOne = new Player();
            //Player playerTwo = new Player();



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

            // creating players
            game.playerOne = new Player();
            game.playerTwo = new Player();
            game.activePlayer = game.playerOne;

            Console.WriteLine("Enter player one's name: ");
            game.playerOne.name = Console.ReadLine();

            Console.WriteLine("Enter player two's name: ");
            game.playerTwo.name = Console.ReadLine();

            // main loop, runs while table is not clear.            
            while (game.table.isTableClear(table) == false)
            {
                Console.Write("-> ");
                var input = Console.ReadLine().Split(' ');

                // string -> Ball.colour

                switch (input[0])
                {
                    case "pot": // pots a designated ball
                        game.ballHandler(game.activePlayer, game.table.tableState.First(b => b.colour == input[1]));
                        Console.WriteLine($"{game.activePlayer.name}'s break: {game.activePlayer.currentBreak} | score: {game.activePlayer.score}.");
                        break;
                    case "miss": // reset break and pass turn to other player
                        Console.WriteLine($"{game.activePlayer.name} missed!");
                        game.switchPlayer();
                        break;
                    case "score": // shows current scores
                        Console.WriteLine($"{game.playerOne.name} [{game.playerOne.score}] | [{game.playerTwo.score}] {game.playerTwo.name}");
                        break;
                    case "stats":
                        Console.WriteLine($"{game.playerOne.name} [{game.playerOne.score}] | [{game.playerTwo.score}] {game.playerTwo.name}");
                        Console.WriteLine($"There are {game.calcRemainingPoints(table.count(red))} points on the table.");
                        Console.WriteLine($"{game.activePlayer.name} needs {game.calcPointsRequiredToWin(game.activePlayer)} points to win the frame.");
                        break;
                    case "resign":
                        Console.WriteLine($"{game.activePlayer.name} has resigned!");
                        break;
                    case "help": // list commands
                    case "?":
                        Console.WriteLine("Commands: pot <ball colour> | miss | score | resign");
                        break;
                    default:
                        Console.WriteLine("Command not found.");
                        break;
                }
            }       
        }
    }
}
