using System;
using ArtificialIntelligenceEngine;
using TicTacToeEngine;

namespace ConsoleUI {
public class PlayersMenu {
    private int selectedIndex { get; set; }
    private string[] playerNames { get; set; }
    private Player[] players { get; set; }
    private Random randomNumberGenerator { get; set; }
    private ConsoleInputController consoleInputController { get; set; }
    public event Action ToggleHelp;

    private bool playersCorrectlyInput => players[0] != null && players[1] != null;

    public PlayersMenu() {
        selectedIndex = 0;
        players = new Player[2];
        playerNames = new[] {string.Empty, string.Empty};

        randomNumberGenerator = new Random();
        consoleInputController = new ConsoleInputController();
    }

    private void DisplayMenu() {
        Console.Clear();
        Console.CursorVisible = false;
        Console.WriteLine("Welcome to TicTacToe!!\n");
        for (var i = 0; i < playerNames.Length; i++) {
            string currentlySelectedPlayer = playerNames[i];

            if (i == selectedIndex) {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
            } else {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
            }

            Console.WriteLine($"Player {i + 1}: {currentlySelectedPlayer}");
        }

        Console.ResetColor();
    }

    public Player[] GetPlayers() {
        DisplayMenu();

        consoleInputController.AddKeybind(ConsoleKey.UpArrow, MoveSelectionUp);
        consoleInputController.AddKeybind(ConsoleKey.DownArrow, MoveSelectionDown);
        consoleInputController.AddKeybind(ConsoleKey.H, AddHumanPlayer);
        consoleInputController.AddKeybind(ConsoleKey.A, AddAiPlayer);
        consoleInputController.AddKeybind(ConsoleKey.R, AddRandomPlayer);
        consoleInputController.AddKeybind(ConsoleKey.X, RemovePlayer);
        consoleInputController.AddKeybind(ConsoleKey.Enter, () => { });
        consoleInputController.AddKeybind(ConsoleKey.E, () => { Environment.Exit(0); });

        do {
            consoleInputController.Run();
        } while (!(playersCorrectlyInput && consoleInputController.key == ConsoleKey.Enter));

        return players;
    }

    private void MoveSelectionUp() {
        if (selectedIndex > 0) {
            selectedIndex--;
            DisplayMenu();
        }
    }

    private void MoveSelectionDown() {
        if (selectedIndex < playerNames.Length - 1) {
            selectedIndex++;
            DisplayMenu();
        }
    }

    private void AddHumanPlayer() {
        var humanPlayer = new HumanPlayer();
        humanPlayer.ToggleHelp += ToggleHelp;
        players[selectedIndex] = humanPlayer;
        playerNames[selectedIndex] = "Human";
        MoveSelectionDown();
        DisplayMenu();
    }

    private void AddAiPlayer() {
        players[selectedIndex] = new MiniMaxPlayer(randomNumberGenerator);
        playerNames[selectedIndex] = "Artificial Intelligence";
        MoveSelectionDown();
        DisplayMenu();
    }

    private void AddRandomPlayer() {
        players[selectedIndex] = new RandomPlayer(randomNumberGenerator);
        playerNames[selectedIndex] = "Random Intelligence";
        MoveSelectionDown();
        DisplayMenu();
    }

    private void RemovePlayer() {
        players[selectedIndex] = null;
        playerNames[selectedIndex] = string.Empty;
        DisplayMenu();
    }
}
}
