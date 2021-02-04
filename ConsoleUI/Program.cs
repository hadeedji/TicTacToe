using System;
using System.Threading;
using ArtificialIntelligenceEngine;
using TicTacToeEngine;

namespace ConsoleUI {
class Program {
    private static GameController gameController { get; set; }

    static void Main() {
        SetUpAndStarGame();
        var consoleInputController = new ConsoleInputController();

        consoleInputController.AddKeybind(ConsoleKey.A, () => ShowResult(gameController.StartGame()));
        consoleInputController.AddKeybind(ConsoleKey.M, () => SetUpAndStarGame());
        consoleInputController.AddKeybind(ConsoleKey.E, () => Environment.Exit(0));

        while (true) {
           consoleInputController.Run(); 
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

    private static void SetUpAndStarGame() {
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

        if (players[0] is AiPlayer && players[1] is AiPlayer) {
            gameController.DrawBoard += () => Thread.Sleep(300);
        }

        gameController.RoundEnded += delegate { gameController.DrawBoard -= boardDrawer.DrawBoard; };

        ShowResult(gameController.StartGame());
    }
}
}
