using System;
using System.Threading;
using ArtificialIntelligenceEngine;
using TicTacToeEngine;

namespace ConsoleUI {
class Program {
    private static GameController gameController { get; set; }

    static void Main() {
        ConsoleKey key;
        do {
            SetUp();
            do {
                ShowResult(gameController.StartGame());
                key = GetKey();
            } while (key == ConsoleKey.A);
        } while (key == ConsoleKey.M);
    }

    private static ConsoleKey GetKey() {
        while (true) {
            var key = Console.ReadKey(true).Key;
            switch (key) {
                case ConsoleKey.A:
                case ConsoleKey.M:
                case ConsoleKey.E:
                    return key;
            }
        }
    }

    private static void ShowResult(Result result) {
        Console.WriteLine();
        switch (result) {
            case Result.Draw:
                Console.WriteLine("The game has drawn.");
                break;
            case Result.PlayerOneWon:
                Console.WriteLine("Player 1 has won.");
                break;
            case Result.PlayerTwoWon:
                Console.WriteLine("Player 2 has won.");
                break;
        }
    }

    private static void SetUp() {
        BoardDrawer boardDrawer = new BoardDrawer();
        PlayersMenu playersMenu = new PlayersMenu();

        playersMenu.ToggleHelp += boardDrawer.ToggleHelp;

        var players = playersMenu.GetPlayers();
        gameController = new GameController(players[0], players[1]);

        boardDrawer.scores = gameController.scores;

        gameController.RoundStarted += delegate {
            boardDrawer.board = gameController.board;
            gameController.DrawBoard += boardDrawer.DrawBoard;
        };

        if (players[0] is RandomPlayer && players[1] is RandomPlayer) {
            gameController.DrawBoard += () => Thread.Sleep(300);
        }

        gameController.RoundEnded += delegate { gameController.DrawBoard -= boardDrawer.DrawBoard; };
    }
}
}
