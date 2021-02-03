using System;
using System.Linq;

namespace TicTacToeEngine {
internal class Round {
    public Board board { get; }
    public bool inPlay { get; set; }
    public Result result { get; set; }

    public event Action<Player> WinnerFound;

    public Round() {
        board = new Board();
        inPlay = true;
    }

    public void Move(Player player) {
        board.MakeMark(player.MakeMove(board), player.mark);
        if (FindWinner()) {
            WinnerFound?.Invoke(player);
            inPlay = false;
            return;
        }

        if (board.numberOfEmptyCells == 0) {
            result = Result.Draw;
            inPlay = false;
        }
    }

    //TODO: Refactor FindWinner() please.
    private bool FindWinner() {
        for (int i = 0; i < 3; i++) {
            if (board.Row(i).All(state => state == board.Row(i)[0] && state != Cell.E)) {
                return true;
            }
        }

        for (int i = 0; i < 3; i++) {
            if (board.Column(i).All(state => state == board.Column(i)[0] && state != Cell.E)) {
                return true;
            }
        }

        foreach (bool isPrincipal in new[] {true, false}) {
            if (board.Diagonal(isPrincipal).All(state => state == board.Diagonal(isPrincipal)[0] && state != Cell.E)) {
                return true;
            }
        }

        return false;
    }
}
}
