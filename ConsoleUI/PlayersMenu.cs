using System;
using ArtificialIntelligenceEngine;
using TicTacToeEngine;

namespace ConsoleUI {
public class PlayersMenu {
    private int selectedIndex { get; set; }
    private string[] playerNames { get; set; }
    private Player[] players { get; set; }
    public event Action ToggleHelp;

    private bool playersCorrectlyInput {
        get => players[0] != null && players[1] != null;
    }

    public PlayersMenu() {
        selectedIndex = 0;
        players = new Player[2];
        playerNames = new[] {string.Empty, string.Empty};
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

        Random randomNumberGenerator = new Random();
        var consoleInputController = new ConsoleInputController();

        consoleInputController.AddKeybind(ConsoleKey.DownArrow, delegate {
            if (selectedIndex < playerNames.Length - 1) {
                selectedIndex++;
                DisplayMenu();
            }
        });

        consoleInputController.AddKeybind(ConsoleKey.UpArrow, delegate {
            if (selectedIndex > 0) {
                selectedIndex--;
                DisplayMenu();
            }
        });

        consoleInputController.AddKeybind(ConsoleKey.H, delegate {
            var humanPlayer = new HumanPlayer();
            humanPlayer.ToggleHelp += ToggleHelp;
            players[selectedIndex] = humanPlayer;
            playerNames[selectedIndex] = "Human";
            DisplayMenu();
        });

        consoleInputController.AddKeybind(ConsoleKey.A, delegate {
            players[selectedIndex] = new RandomPlayer(randomNumberGenerator);
            playerNames[selectedIndex] = "Artificial Intelligence";
            DisplayMenu();
        });
        
        consoleInputController.AddKeybind(ConsoleKey.R, delegate {
            players[selectedIndex] = null;
            playerNames[selectedIndex] = string.Empty;
            DisplayMenu();
        });

        consoleInputController.AddKeybind(ConsoleKey.Enter, delegate { });

        consoleInputController.AddKeybind(ConsoleKey.E, delegate { Environment.Exit(0); });


        do {
            consoleInputController.Run();
        } while (!(playersCorrectlyInput && consoleInputController.lastKeyPressed == ConsoleKey.Enter));

        return players;
    }
}
}
