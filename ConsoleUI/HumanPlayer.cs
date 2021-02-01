using System;
using TicTacToeEngine;

namespace ConsoleUI {
public class HumanPlayer : Player {
    public HumanPlayer(string name) : base(name) { }

    public override (int, int) MakeMove(Board board) {
        Console.WriteLine("Enter the comma separated coordinates:\n> ");
        string input = Console.ReadLine();
        int rowIndex = Convert.ToInt32(input.Split(',')[0]);
        int columnIndex = Convert.ToInt32(input.Split(',')[1]);

        return (rowIndex, columnIndex);
    }
}
}
