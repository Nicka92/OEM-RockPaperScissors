using OEM_RockPaperScissors;
using System.Runtime.CompilerServices;

internal class Program
{
    private static void Main(string[] args)
    {
        bool playGame = true;
        

        Console.WriteLine("Rock, Paper, Scissors!\n");

        Console.WriteLine("Would you like to play standard mode(1) or advanced mode(2)?\n");

        string input = Console.ReadLine();
        if (!int.TryParse(input, out int userInputValue))
        {
            Console.WriteLine("Invalid choice provided. \n");
            Console.WriteLine();

        }
        IRockPaperScissors game = (userInputValue == 1) ? new RockPaperScissors() : new RockPaperScissorsLizardSpock();

        while (playGame)
        {
            
            game.ResetGame();

            game.PlayGame();

            Console.WriteLine("Would you like to play again? (Y / N)");

            playGame = Console.ReadLine().ToUpper() == "Y";
        }

        Console.WriteLine("Thanks for playing!\n");
        Console.ReadLine();
    }
}