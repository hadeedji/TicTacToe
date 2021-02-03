using System;
using TicTacToeEngine;

namespace ConsoleUI {
public class HumanPlayer : Player {
    public event Action ToggleHelp;

    public override CellLocation MakeMove(Board board) {
        CellLocation location;
        do {
            location = new CellLocation(GetInput());
        } while (board.GetCell(location) != Cell.E);

        return location;
    }

    private (int, int) GetInput() {
        var result = (-1, -1);
        while (result == (-1,-1)) {
            var key = Console.ReadKey(true).Key;
            if (key == ConsoleKey.H) {
                ToggleHelp?.Invoke();
                while (Console.ReadKey(true).Key != ConsoleKey.H) { }

                ToggleHelp?.Invoke();
            } else {
                switch (key) {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        result = (2, 0);
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        result = (2, 1);
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        result = (2, 2);
                        break;
                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        result = (1, 0);
                        break;
                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:
                        result = (1, 1);
                        break;
                    case ConsoleKey.D6:
                    case ConsoleKey.NumPad6:
                        result = (1, 2);
                        break;
                    case ConsoleKey.D7:
                    case ConsoleKey.NumPad7:
                        result = (0, 0);
                        break;
                    case ConsoleKey.D8:
                    case ConsoleKey.NumPad8:
                        result = (0, 1);
                        break;
                    case ConsoleKey.D9:
                    case ConsoleKey.NumPad9:
                        result = (0, 2);
                        break;
                }
            }
        }

        return result;
    }
}
}
