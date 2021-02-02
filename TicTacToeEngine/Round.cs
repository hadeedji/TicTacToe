using System;
using System.Linq;

namespace TicTacToeEngine {
internal class Round {
    private Board _board;
    public bool inPlay { get; set; }
    public Result result;

    public event Action<Player> WinnerFound;

    public Board boardCopy {
        get => _board.GetCopy();
    }

    public Round() {
        _board = new Board();
        inPlay = true;
    }

    public void Move(Player player) {
        _board.MakeMark(player.MakeMove(boardCopy), player.mark);
        if (FindWinner()) {
            WinnerFound(player);
            inPlay = false;
        }

        if (boardCopy.numberOfEmptyCells == 0) {
            result = Result.Draw;
            inPlay = false;
        }
    }

    //TODO: Refactor FindWinner() please.
    private bool FindWinner() {
        for (int i = 0; i < 3; i++) {
            if (_board.Row(i).All(state => state == _board.Row(i)[0] && state != Cell.E)) {
                return true;
            }
        }

        for (int i = 0; i < 3; i++) {
            if (_board.Column(i).All(state => state == _board.Column(i)[0] && state != Cell.E)) {
                return true;
            }
        }

        foreach (bool isPrincipal in new[] {true, false}) {
            if (_board.Diagonal(isPrincipal).All(state => state == _board.Diagonal(isPrincipal)[0] && state != Cell.E)) {
                return true;
            }
        }

        return false;
    }
}
}
