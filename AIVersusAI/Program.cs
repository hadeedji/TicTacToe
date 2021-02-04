using System;
using System.Diagnostics;
using ArtificialIntelligenceEngine;
using TicTacToeEngine;

namespace AIVersusAI {
class Program {
    static void Main() {
        Random randomNumberGenerator = new Random();
        Player player1 = new MiniMaxPlayer(randomNumberGenerator);
        Player player2 = new RandomPlayer(randomNumberGenerator);

        GameController gameController = new GameController(player1, player2);

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        do {
            switch (gameController.StartGame()) {
                case Result.PlayerOneWon:
                    Console.WriteLine("Player 1 won!");
                    break;
                case Result.PlayerTwoWon:
                    Console.WriteLine("Player 2 won!");
                    break;
                case Result.Draw:
                    Console.WriteLine("The game was drawn.");
                    break;
            }
        } while (stopwatch.Elapsed < TimeSpan.FromSeconds(60));

        Console.WriteLine("\nResults: ");
        Console.WriteLine($"Player 1 wins: {gameController.scores.player1Score}");
        Console.WriteLine($"Player 2 wins: {gameController.scores.player2Score}");
        Console.WriteLine($"Draws: {gameController.scores.draws}");

        stopwatch.Stop();
    }
}
}
