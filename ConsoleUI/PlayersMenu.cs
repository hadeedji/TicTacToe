using System;
using ArtificialIntelligenceEngine;
using TicTacToeEngine;

namespace ConsoleUI {
public class PlayersMenu {
    private int selectedIndex { get; set; }
    private string[] playerNames { get; set; }
    public event Action ToggleHelp;

    public PlayersMenu() {
        selectedIndex = 0;
        playerNames = new[] {"", ""};
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

        Player[] players = new Player[2];
        Random randomNumberGenerator = new Random();
        
        var conditional = true;
        while (conditional) {
            var keyPressed = Console.ReadKey(true).Key;
            switch (keyPressed) {
                case ConsoleKey.DownArrow:
                    if (selectedIndex < playerNames.Length - 1) {
                        selectedIndex++;
                        DisplayMenu();
                    }

                    break;
                case ConsoleKey.UpArrow:
                    if (selectedIndex > 0) {
                        selectedIndex--;
                        DisplayMenu();
                    }

                    break;
                case ConsoleKey.H:
                    var humanPlayer = new HumanPlayer();
                    humanPlayer.ToggleHelp += ToggleHelp;
                    players[selectedIndex] = humanPlayer;
                    playerNames[selectedIndex] = "Human";
                    DisplayMenu();
                    break;
                case ConsoleKey.A:
                    players[selectedIndex] = new RandomPlayer(randomNumberGenerator);
                    playerNames[selectedIndex] = "Artificial Intelligence";
                    DisplayMenu();
                    break;
                case ConsoleKey.Enter:
                    if (players[0] != null && players[1] != null) {
                        conditional = false;
                    }

                    break;
            }
        }


        return players;
    }
}
}
