using System;
using TicTacToeEngine;

namespace ConsoleUI {
class Program {
    private static GameController gameController { get; set; }

    static void Main() {
        SetUp();

        ShowResult(gameController.StartGame());

        Console.ReadKey();
    }

    private static void ShowResult(Result result) {
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
        PlayersMenu playersMenu = new PlayersMenu();
        BoardDrawer boardDrawer = new BoardDrawer();
        
        var players = playersMenu.GetPlayers();
        gameController = new GameController(players[0], players[1]);

        gameController.RoundStarted += delegate {
            boardDrawer.board = gameController.board;
            gameController.DrawBoard += boardDrawer.DrawBoard;
        };

        gameController.RoundEnded += delegate { gameController.DrawBoard -= boardDrawer.DrawBoard; };
    }
}
}
