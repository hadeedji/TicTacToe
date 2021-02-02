using System;
using TicTacToeEngine;

namespace ConsoleUI {
class Program {
    static void Main() {
        Player player1 = new HumanPlayer(PromptAndInput("Enter player 1 name: "));
        Player player2 = new HumanPlayer(PromptAndInput("Enter player 2 name: "));
        var gameController = new GameController(player1, player2);

        var result = gameController.StartGame();
        string message = result switch {
            Result.Draw => "The game was draw.",
            Result.PlayerOneWon => $"{player1.name} won!!!",
            Result.PlayerTwoWon => $"{player2.name} won!!!",
            _ => throw new ArgumentOutOfRangeException()
        };
        Console.WriteLine(message);

        Console.WriteLine($"{player1.name} wins: {gameController.player1Score}");
        Console.WriteLine($"{player2.name} wins: {gameController.player2Score}");
        Console.WriteLine($"Draws: {gameController.draws}");
    }

    static void Drawboard(Board board) {
        Console.WriteLine("\n");
        PrintRow(board.Row(0));
        PrintRow(board.Row(1));
        PrintRow(board.Row(2));
    }

    static void PrintRow(Cell[] row) {
        Console.WriteLine($"[{CharacterFromCellState(row[0])} " +
                          $"{CharacterFromCellState(row[1])} " +
                          $"{CharacterFromCellState(row[2])}]");
    }

    static char CharacterFromCellState(Cell state) {
        return state switch {
            Cell.E => '_',
            Cell.X => 'X',
            Cell.O => 'O',
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, null)
        };
    }

    static string PromptAndInput(string prompt) {
        Console.Write(prompt);
        return Console.ReadLine();
    }
}
}
