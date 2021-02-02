using System;

namespace TicTacToeEngine {
public class Board {
    private readonly Cell[,] _grid;

    public int numberOfEmptyCells {
        get {
            int acc = 0;
            for (int i = 0; i < 3; i++) {
                for (int j = 0; j < 3; j++) {
                    if (this.GetCell(new CellLocation(i,j)) == Cell.E) {
                        acc++;
                    }
                }
            }

            return acc;
        }
    }

    public Board() => _grid = new Cell[3, 3];

    public void MakeMark(CellLocation location, Cell mark) {
        _grid[location.rowIndex, location.columnIndex] = mark;
    }

    public Cell GetCell(CellLocation location) {
        return _grid[location.rowIndex, location.columnIndex];
    }

    public Board GetCopy() {
        var board = new Board();
        for (int i = 0; i < 3; i++) {
            for (int j = 0; j < 3; j++) {
                var cellLocation = new CellLocation(i, j);
                board.MakeMark(cellLocation, this.GetCell(cellLocation));
            }
        }

        return board;
    }

    public Cell[] Row(int rowIndex) {
        Cell[] row = new Cell[3];
        for (int i = 0; i < 3; i++) {
            row[i] = this.GetCell(new CellLocation(rowIndex, i));
        }

        return row;
    }

    public Cell[] Column(int columnIndex) {
        Cell[] column = new Cell[3];
        for (int i = 0; i < 3; i++) {
            column[i] = this.GetCell(new CellLocation(i, columnIndex));
        }

        return column;
    }

    public Cell[] Diagonal(bool isPrincipal) {
        Cell[] diagonal = new Cell[3];
        for (int i = 0; i < 3; i++) {
            var location = new CellLocation(isPrincipal ? i : 2 - i, i);

            diagonal[i] = GetCell(location);
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
