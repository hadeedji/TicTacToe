using System.Linq;

namespace TicTacToeEngine {
internal class Round {
    private Board _board;
    public int movesMade { get; private set; }
    public bool haveWinner { get; private set; }

    public Board board {
        get => _board.grid;
    }

    public Round() {
        _board = new Board();
        movesMade = 0;
    }


    public void Move(Player player, (int rowIndex, int columnIndex) move) {
        _board[move.rowIndex, move.columnIndex] = player.mark;
        movesMade++;
    }

    public bool HasEnded() {
        return movesMade == 9 || FindWinner();
    }

    private bool FindWinner() {
        for (int i = 1; i <= 3; i++) {
            if (_board.Row(i).All(state => state == _board.Row(i)[0] && state != CellState.E)) {
                haveWinner = true;
                return true;
            }
        }

        for (int i = 1; i <= 3; i++) {
            if (_board.Column(i).All(state => state == _board.Column(i)[0] && state != CellState.E)) {
                haveWinner = true;
                return true;
            }
        }

        foreach (bool isPrincipal in new[] {true, false}) {
            if (_board.Diagonal(isPrincipal).All(state => state == _board.Diagonal(isPrincipal)[0] && state != CellState.E)) {
                haveWinner = true;
                return true;
            }
        }

        return false;
    }
}
}
