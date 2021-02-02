using System;
using TicTacToeEngine;

namespace ConsoleUI {
class Program {
    static void Main() {
        var gameController = new GameController(new HumanPlayer("Hadeed"), new HumanPlayer("Hamza"));
        
        gameController.DrawBoard += delegate(Board board) {
            Console.WriteLine("\n");
            PrintRow(board.Row(1));
            PrintRow(board.Row(2));
            PrintRow(board.Row(3));
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

    static void PrintRow(CellState[] row) {
        Console.WriteLine($"[{CharacterFromCellState(row[0])} " +
                          $"{CharacterFromCellState(row[1])} " +
                          $"{CharacterFromCellState(row[2])}]"); 
    }

    static char CharacterFromCellState(CellState state) {
        return state switch {
            CellState.E => '_',
            CellState.X => 'X',
            CellState.O => 'O',
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, null)
        };
    }
}
}
