using System;
using System.Linq;
using System.Threading;
using ArtificialIntelligenceEngine;
using TicTacToeEngine;

namespace ConsoleUI {
class Program {
    private static GameController gameController { get; set; }

    static void Main() {
        SetUpAndStartGame();
        var consoleInputController = new ConsoleInputController();

        consoleInputController.AddKeybind(ConsoleKey.A, () => ShowResult(gameController.StartGame()));
        consoleInputController.AddKeybind(ConsoleKey.M, () => SetUpAndStartGame());
        consoleInputController.AddKeybind(ConsoleKey.E, () => { });

        while (consoleInputController.key != ConsoleKey.E) {
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

    private static void SetUpAndStartGame() {
        BoardDrawer boardDrawer = new BoardDrawer();
        PlayersMenu playersMenu = new PlayersMenu();

        playersMenu.ToggleHelp += boardDrawer.ToggleHelp;

        var players = playersMenu.GetPlayers();
        gameController = new GameController(players[0], players[1]);

        foreach (Player player in players) {
            if (player is HumanPlayer) {
                ((HumanPlayer) player).Restart += () => gameController.StartGame();
            }
        }

        boardDrawer.scores = gameController.scores;

        gameController.RoundStarted += delegate {
            boardDrawer.board = gameController.board;
            gameController.DrawBoard += boardDrawer.DrawBoard;
        };

        if (Array.TrueForAll(players, p => p is AiPlayer))
            gameController.DrawBoard += () => Thread.Sleep(300);

        gameController.RoundEnded += delegate { gameController.DrawBoard -= boardDrawer.DrawBoard; };

        ShowResult(gameController.StartGame());
    }
}
}
