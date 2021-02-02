using System;
using TicTacToeEngine;

namespace ConsoleUI {
class Program {
    private static Action<object> _field;

    static void Main() {
        var gameController = new GameController(new HumanPlayer("Hadeed"), new HumanPlayer("Hamza"));
        
        gameController.DrawBoard += board => {
            Console.WriteLine("\n");
            PrintRow(board.Row(0));
            PrintRow(board.Row(1));
            PrintRow(board.Row(2));
        };

        var result = gameController.StartGame();
        string message = result switch {
            Result.Draw => "The game was draw.",
            Result.PlayerOneWon => "Hadeed won!!!",
            Result.PlayerTwoWon => "Hamza won!!!",
            _ => throw new ArgumentOutOfRangeException()
        };

        Console.WriteLine(message);
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
}
}
