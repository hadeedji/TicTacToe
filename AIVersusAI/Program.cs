using System;
using System.Diagnostics;
using System.Threading;
using ArtificialIntelligenceEngine;
using TicTacToeEngine;

namespace AIVersusAI {
class Program {
    public static Player player1 { get; set; }
    public static Player player2 { get; set; }
    public static int player1Score { get; set; }
    public static int player2Score { get; set; }
    public static int draws { get; set; }

    static void Main() {
        Random randomNumberGenerator = new Random();
        player1 = new MiniMaxPlayer(randomNumberGenerator);
        player2 = new MiniMaxPlayer(randomNumberGenerator);

        var numberOfThreads = 8;
        Thread[] threads = new Thread[numberOfThreads];  
        for (int i = 0; i < numberOfThreads; i++) {
            threads[i] = new Thread(new ThreadStart(StartGame));
            threads[i].Start();
        }

        for (int i = 0; i < numberOfThreads; i++) {
            threads[i].Join();
        }
        
        

        Console.WriteLine("\nResults: ");
        Console.WriteLine($"Player 1 wins: {player1Score}");
        Console.WriteLine($"Player 2 wins: {player2Score}");
        Console.WriteLine($"Draws: {draws}");

    }

    static void StartGame() {
        GameController gameController = new GameController(player1,player2);
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        do {
            switch (gameController.StartGame()) {
                case Result.PlayerOneWon:
                    Console.WriteLine("Player 1 won!");
                    player1Score++;
                    break;
                case Result.PlayerTwoWon:
                    Console.WriteLine("Player 2 won!");
                    player2Score++;
                    break;
                case Result.Draw:
                    Console.WriteLine("The game was drawn.");
                    draws++;
                    break;
            }
        } while (stopwatch.Elapsed < TimeSpan.FromSeconds(60));

        stopwatch.Stop();
    }
}
}
