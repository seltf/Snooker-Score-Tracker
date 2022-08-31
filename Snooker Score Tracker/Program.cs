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
            var activePlayer = playerOne;
            

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

            // main loop, runs while table is not clear.            
            while (game.table.isTableClear(table) == false)
            {
                Console.Write("-> ");
                var input = Console.ReadLine().Split(' ');

                // string -> Ball.colour

                switch (input[0])
                {
                    case "pot": // pots a designated ball

                        game.ballHandler(activePlayer, game.table.tableState.First(b => b.colour == input[1]));
                        Console.WriteLine($"{activePlayer.name}'s break: {activePlayer.currentBreak} | score: {activePlayer.score}.");
                        break;
                    case "miss": // reset break and pass turn to other player
                        Console.WriteLine($"{activePlayer.name} missed!");
                        activePlayer.currentBreak = 0;
                        if (activePlayer == playerOne)
                        {
                            activePlayer = playerTwo;
                        }
                        else
                        {
                            activePlayer = playerOne;
                        }
                        Console.WriteLine($"It is now {activePlayer.name}'s turn.");
                        break;
                    case "score": // shows current scores
                        Console.WriteLine($"{playerOne.name} [{playerOne.score}] | [{playerTwo.score}] {playerTwo.name}");
                        break;
                    case "stats":
                        Console.WriteLine($"{playerOne.name} [{playerOne.score}] | [{playerTwo.score}] {playerTwo.name}");
                        Console.WriteLine($"There are {game.calcRemainingPoints(table.count(red))} points on the table.");
                        Console.WriteLine($"{activePlayer.name} needs {game.calcPointsRequiredToWin(activePlayer)} points to win the frame.");
                        break;
                    case "resign":
                        Console.WriteLine($"{activePlayer.name} has resigned!");
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
