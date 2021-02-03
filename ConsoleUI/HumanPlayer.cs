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
        var consoleInputController = new ConsoleInputController();

        consoleInputController.AddKeybind(ConsoleKey.H, delegate {
            ToggleHelp?.Invoke();
            var helpInputController = new ConsoleInputController();
            helpInputController.AddKeybind(ConsoleKey.H, delegate { ToggleHelp?.Invoke(); });
            helpInputController.Run();
            consoleInputController.Run();
        });

        (int, int) result = (-1, -1);
        AddKeybind(ConsoleKey.D1, ConsoleKey.NumPad1, () => result = (2, 0));
        AddKeybind(ConsoleKey.D2, ConsoleKey.NumPad2, () => result = (2, 1));
        AddKeybind(ConsoleKey.D3, ConsoleKey.NumPad3, () => result = (2, 2));
        AddKeybind(ConsoleKey.D4, ConsoleKey.NumPad4, () => result = (1, 0));
        AddKeybind(ConsoleKey.D5, ConsoleKey.NumPad5, () => result = (1, 1));
        AddKeybind(ConsoleKey.D6, ConsoleKey.NumPad6, () => result = (1, 2));
        AddKeybind(ConsoleKey.D7, ConsoleKey.NumPad7, () => result = (0, 0));
        AddKeybind(ConsoleKey.D8, ConsoleKey.NumPad8, () => result = (0, 1));
        AddKeybind(ConsoleKey.D9, ConsoleKey.NumPad9, () => result = (0, 2));

        consoleInputController.Run();
        return result;

        void AddKeybind(ConsoleKey key1, ConsoleKey key2, Action action) {
            consoleInputController.AddKeybind(key1, action);
            consoleInputController.AddKeybind(key2, action);
        }
    }
}
}
