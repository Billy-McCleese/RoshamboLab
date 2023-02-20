using RoshamboLab;
using System.ComponentModel;

Console.WriteLine("Welcome to Roshambo!");

// Create a HumanPlayer using the human player class
Console.Write("Enter your name: ");
string playerName = Console.ReadLine();
HumanPlayer humanPlayer = new HumanPlayer(playerName);

Player Opponent = null;
while (Opponent == null)
{
    Console.WriteLine("Who would you like to play against, RockPlayer(1) or RandomPlayer(2): (1/2)?");
    string OpponentNum = Console.ReadLine();

    if (OpponentNum == "1")
    {
        Opponent = new RockPlayer("RockPlayer");
    }
    else if (OpponentNum == "2")
    {
        Opponent = new RandomPlayer("RandomPlayer");
    }
    else Console.WriteLine("Invalid input, please try again");
}


while (true)
{
    // Get the players' choices by calling the inherrited classes
    RoshamboEnum humanChoice = humanPlayer.GenerateRoshambo();
    RoshamboEnum opponentChoice = Opponent.GenerateRoshambo();

    Console.WriteLine($"{humanPlayer.PlayerName} chose {humanChoice}.");
    Console.WriteLine($"{Opponent.PlayerName} chose {opponentChoice}.");

    // Determine the winner using if loop
    if (humanChoice == opponentChoice)
    {
        Console.WriteLine("It's a tie!");
    }
    else if (humanChoice == RoshamboEnum.rock && opponentChoice == RoshamboEnum.scissors ||
             humanChoice == RoshamboEnum.paper && opponentChoice == RoshamboEnum.rock ||
             humanChoice == RoshamboEnum.scissors && opponentChoice == RoshamboEnum.paper)
    {
        Console.WriteLine($"{playerName} wins!");
    }
    else
    {
        Console.WriteLine($"{Opponent.PlayerName} wins!");
    }

    // Ask the user if they want to play again
    Console.WriteLine("Play again? (Y/N)");
    string playAgain = Console.ReadLine().ToLower();
    if (playAgain != "y")
        break;
}

Console.WriteLine("Thanks for playing Roshambo!");
