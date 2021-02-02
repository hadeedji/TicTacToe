using System;
using System.Linq;
using TicTacToeEngine;

namespace ConsoleUI {
public class HumanPlayer : Player {
    public HumanPlayer(string name) : base(name) { }

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
        Console.Write("Enter the coordinates:\n> ");
        var input = Console.ReadLine().Split(',').Select(x => Convert.ToInt32(x)).ToArray();
        return (input[0] - 1, input[1] - 1);
    }
}
}
