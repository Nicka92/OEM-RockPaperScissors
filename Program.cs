using System.Runtime.CompilerServices;

internal class Program
{
    static Random rndNumber = new Random();
    static Dictionary<string, int> scoreBoard;
    static Dictionary<int, string> availMoves = new Dictionary<int, string>
    {
            { 1, "ROCK" },
            { 2, "PAPER" },
            { 3, "SCISSORS" }

    };

    static int numOfWins = 0;
    static string playerName = string.Empty;

    private static void Main(string[] args)
    {
        StartGame();
        Console.ReadLine();
    }

    private static void ResetGame()
    {
        scoreBoard = new Dictionary<string, int>
       {
            { "Computer", 0 }
       };

        numOfWins = 0;

        Console.WriteLine("Please enter your name:");

        playerName = Console.ReadLine();

        scoreBoard.Add(playerName, 0);

        while (numOfWins <= 0)
        {
            Console.WriteLine("Number of rounds to win the game: ");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out numOfWins) && numOfWins > 0)
            {
                Console.WriteLine("Please provide a number of wins required.");
            }
        }
        Console.WriteLine();
    }

    private static void PlayGame()
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
                Console.WriteLine("Incorrect choice provided, please provide the number value of the move. E.g 1, 3 etc.");
                Console.WriteLine();
                continue;
            }

            string userInputText = availMoves[userInputValue];
            Console.WriteLine($"you have chosen {userInputText}!");


            int cpuInputValue = rndNumber.Next(1, availMoves.Count);
            string cpuInputText = availMoves[cpuInputValue];

            Console.WriteLine($"Computer has Chosen {cpuInputText}!");
            Console.WriteLine();

            if (userInputValue != cpuInputValue)
            {
                int algorithm = ((userInputValue - cpuInputValue) % availMoves.Count) % 2;
                if (algorithm == 1)
                {
                    Console.WriteLine($"You Win!");
                    scoreBoard[playerName] += 1;
                }
                else
                {
                    Console.WriteLine("Computer Wins!");
                    scoreBoard["Computer"] += 1;
                }

            }
            else
            {
                Console.WriteLine("It's a draw!");
            }
            Console.WriteLine();

            Console.WriteLine($"Scoreboard: {playerName} {scoreBoard[playerName]} - Computer {scoreBoard["Computer"]}");
            Console.WriteLine();

            if (scoreBoard.Any(score => score.Value >= numOfWins))
                gameOver = true;
        }
    }

    private static void StartGame()
    {
        
        Console.WriteLine("Rock, Paper, Scissors!");

        ResetGame();

        PlayGame();
        

        Console.WriteLine($"Game Over! {scoreBoard.Single(score => score.Value >= numOfWins).Key } is the winner!");
    }


 
}