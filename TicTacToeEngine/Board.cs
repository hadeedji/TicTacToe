namespace TicTacToeEngine {
public class Board {
    private readonly Cell[,] _grid;

    public int numberOfEmptyCells {
        get {
            int acc = 0;
            for (int i = 0; i < 3; i++) {
                for (int j = 0; j < 3; j++) {
                    if (this.GetCell(i,j) == Cell.E) {
                        acc++;
                    }
                }
            }

            return acc;
        }
    }

    public Board() => _grid = new Cell[3, 3];

    internal void MakeMark(CellLocation location, Cell mark) {
        _grid[location.rowIndex, location.columnIndex] = mark;
    }

    public Cell GetCell(CellLocation location) {
        return _grid[location.rowIndex, location.columnIndex];
    }

    public Cell GetCell(int rowIndex, int columnIndex) {
        return _grid[rowIndex, columnIndex];
    }

    public Cell[] Row(int rowIndex) {
        Cell[] row = new Cell[3];
        for (int i = 0; i < 3; i++) {
            row[i] = this.GetCell(rowIndex, i);
        }

        return row;
    }

    public Cell[] Column(int columnIndex) {
        Cell[] column = new Cell[3];
        for (int i = 0; i < 3; i++) {
            column[i] = this.GetCell(i, columnIndex);
        }

        return column;
    }

    public Cell[] Diagonal(bool isPrincipal) {
        Cell[] diagonal = new Cell[3];
        for (int i = 0; i < 3; i++) {
            diagonal[i] = GetCell(isPrincipal ? i : 2 - i, i);
        }

        return diagonal;
    }
}

public enum Cell {
    E,
    X,
    O
}
}
