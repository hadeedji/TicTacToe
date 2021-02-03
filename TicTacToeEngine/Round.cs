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

    private bool FindWinner() {
        var winningArangements = board.WinningArrangements();
        foreach (Cell[] arangement in winningArangements) {
            if (arangement.Contains(Cell.E))
                continue;

            if (arangement[0] == arangement[1] && arangement[1] == arangement[2]) {
                return true;
            }
        }

        return false;
    }
}
}
