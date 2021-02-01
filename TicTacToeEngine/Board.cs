namespace TicTacToeEngine {
public class Board {
    private CellState[,] _grid;

    public Board() {
        _grid = new CellState[3, 3];
    }

    public CellState this[int rowIndex, int columnIndex] {
        get => _grid[rowIndex, columnIndex];
        set => _grid[rowIndex, columnIndex] = value;
    }

    public CellState[] Row(int rowIndex) {
        return new[] {this[rowIndex - 1, 0], this[rowIndex - 1, 1], this[rowIndex - 1, 2]};
    }

    public CellState[] Column(int columnIndex) {
        return new[] {this[0, columnIndex - 1], this[1, columnIndex - 1], this[2, columnIndex - 1]};
    }

    public CellState[] Diagonal(bool isPrincipal) {
        return isPrincipal
            ? new CellState[] {this[0, 0], this[1, 1], this[2, 2]}
            : new CellState[] {this[2, 0], this[1, 1], this[0, 2]};
    }
}

public enum CellState {
    E,
    X,
    O
}
}
