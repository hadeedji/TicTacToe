using System;
using System.Diagnostics;
using TicTacToeEngine;

namespace ConsoleUI {
public class BoardDrawer {
    public Board board { get; set; }
    public Scores scores { get; set; }
    private bool isHelpDrawn { get; set; }

    public BoardDrawer() { }

    public BoardDrawer(Board board) {
        this.board = board;
    }

    private void Draw(Func<int, int, string> getCharacter) {
        string padding = "        ";
        Console.CursorVisible = false;

        Console.Clear();
        Console.WriteLine("Player 1 score: " + scores.player1Score);
        Console.WriteLine("Player 2 score: " + scores.player2Score);
        Console.WriteLine("Draws: " + scores.draws);
        Console.WriteLine("\n");
        Console.Write(padding);
        Console.WriteLine("+---+---+---+");

        for (int rowIndex = 0; rowIndex < 3; rowIndex++) {
            Console.Write(padding);
            for (int columnIndex = 0; columnIndex < 3; columnIndex++) {
                Console.Write("| " + getCharacter(rowIndex, columnIndex) + " ");
            }

            Console.WriteLine("|\n" + padding + "+---+---+---+");
        }
    }

    public void DrawBoard() {
        Draw(CharacterAtLocation);
    }

    public void DrawHelpBoard() {
        Draw(delegate(int rowIndex, int columnIndex) {
            rowIndex = 2 - rowIndex;
            columnIndex++;

            return (3 * rowIndex + columnIndex).ToString();
        });
    }

    public void ToggleHelp() {
        if (!isHelpDrawn) {
            DrawHelpBoard();
            isHelpDrawn = true;
        } else {
            DrawBoard();
            isHelpDrawn = false;
        }
    }

    private string CharacterAtLocation(int rowIndex, int columnIndex) {
        return board.GetCell(rowIndex, columnIndex) switch {
            Cell.E => " ",
            Cell.X => "X",
            Cell.O => "O"
        };
    }
}
}
