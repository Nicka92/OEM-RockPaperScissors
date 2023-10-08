using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OEM_RockPaperScissors
{
    internal class RockPaperScissors : IRockPaperScissors
    {
        public int numOfWins = 0;
        public string playerName = string.Empty;

        public Random rndNumber = new Random();
        public Dictionary<string, int> scoreboard;
        public readonly Dictionary<int, string> availMoves = new Dictionary<int, string>
        {
            { 1, "ROCK" },
            { 2, "PAPER" },
            { 3, "SCISSORS" }

        };

        public RockPaperScissors() { }

        public void ResetGame()
        {
            scoreboard = new Dictionary<string, int>
       {
            { "Computer", 0 }
       };

            numOfWins = 0;

            Console.WriteLine("Please enter your name:");

            playerName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(playerName))
                playerName = "Player One";

            scoreboard.Add(playerName, 0);

            while (numOfWins <= 0)
            {
                Console.WriteLine("Number of rounds to win the game: ");
                string input = Console.ReadLine();

                if (!int.TryParse(input, out numOfWins) && numOfWins > 0)
                {
                    Console.WriteLine("Please provide a number of wins required.\n");
                }
            }
        }

        public void PlayGame()
        {
            bool gameOver = false;
            string winner = string.Empty;

            while (!gameOver)
            {
                Console.WriteLine("Choose Rock(1), Paper(2) or Scissors(3):");
                string input = Console.ReadLine().ToUpper();
                int userInputValue = 0;
                if (!int.TryParse(input, out userInputValue) || !availMoves.Any(move => move.Key == userInputValue))
                {
                    Console.WriteLine("Invalid choice provided, please provide the number value of the move. E.g 1, 3 etc. \n");
                    Console.WriteLine();
                    continue;
                }

                string userInputText = availMoves[userInputValue];
                Console.WriteLine($"you have chosen {userInputText}!");


                int cpuInputValue = rndNumber.Next(1, availMoves.Count);
                string cpuInputText = availMoves[cpuInputValue];

                Console.WriteLine($"Computer has Chosen {cpuInputText}!\n");

                if (userInputValue != cpuInputValue)
                {
                    int algorithm = ((userInputValue - cpuInputValue) % availMoves.Count) % 2;
                    if (algorithm == 1)
                    {
                        Console.WriteLine($"You Win!\n");
                        scoreboard[playerName] += 1;
                    }
                    else
                    {
                        Console.WriteLine("Computer Wins!\n");
                        scoreboard["Computer"] += 1;
                    }
                }
                else
                    Console.WriteLine("It's a draw!\n");

                Console.WriteLine($"Scoreboard: {playerName} {scoreboard[playerName]} - Computer {scoreboard["Computer"]}\n");

                if (scoreboard.Any(score => score.Value >= numOfWins))
                    gameOver = true;
            }
            Console.WriteLine($"Game Over! {scoreboard.Single(score => score.Value >= numOfWins).Key} is the winner!\n");
        }
    }
}
