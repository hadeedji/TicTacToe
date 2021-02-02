using System;

namespace TicTacToeEngine {
public class Board {
    private readonly CellState[,] _grid;

    public Board() {
        _grid = new CellState[3, 3];
    }

    private Board(CellState[,] grid) {
        if (grid.GetLength(0) == 3 && grid.GetLength(1) == 3) {
            _grid = grid;
        } else {
            throw new ArgumentException("Grid is not of the correct dimensions");
        }
    }


    public CellState this[int rowIndex, int columnIndex] {
        get => _grid[rowIndex, columnIndex];
        set => _grid[rowIndex, columnIndex] = value;
    }

    public Board grid {
        get {
            var copy = new CellState[3, 3];
            for (int i = 0; i < 3; i++) {
                for (int j = 0; j < 3; j++) {
                    copy[i, j] = this[i, j];
                }
            }

            return new Board(copy);
        }
    }

    public CellState[] Row(int rowIndex) {
        return new[] {this[rowIndex - 1, 0], this[rowIndex - 1, 1], this[rowIndex - 1, 2]};
    }

    public CellState[] Column(int columnIndex) {
        return new[] {this[0, columnIndex - 1], this[1, columnIndex - 1], this[2, columnIndex - 1]};
    }

    public CellState[] Diagonal(bool isPrincipal) {
        return isPrincipal
            ? new[] {this[0, 0], this[1, 1], this[2, 2]}
            : new[] {this[2, 0], this[1, 1], this[0, 2]};
    }
}

public enum CellState {
    E,
    X,
    O
}
}
