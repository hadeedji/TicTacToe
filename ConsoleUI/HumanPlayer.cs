using System;
using TicTacToeEngine;

namespace ConsoleUI {
public class HumanPlayer : Player {
    public override CellLocation MakeMove(Board board) {
        while (true) {
            try {
                (int rowIndex, int columnIndex) = PromptAndRead();
                var location = new CellLocation(rowIndex, columnIndex);
                if (board.GetCell(location) != Cell.E) {
                    Console.WriteLine("Location is filled already.");
                    continue;
                }

                return location;
            } catch (ArgumentException e) {
                Console.WriteLine(e.Message);
            }
        }
    }

    private (int, int) PromptAndRead() {
        Console.Write("Enter the cell:\n> ");
        var input = Console.ReadLine();
        var rowIndex = input[0] switch {
            'a' => 0,
            'b' => 1,
            'c' => 2,
            _ => -1
        };
        var columnIndex = Convert.ToInt32(input[1].ToString());
        return (rowIndex, columnIndex - 1);
    }
}
}
