using System;
using System.Collections.Generic;

namespace TicTacToeEngine {
public class Board {
    private readonly Cell[,] _grid;

    public int numberOfEmptyCells { get; private set; }

    public Board() {
        _grid = new Cell[3, 3];
        numberOfEmptyCells = 9;
    }

    internal void MakeMark(CellLocation location, Cell mark) {
        _grid[location.rowIndex, location.columnIndex] = mark;
        numberOfEmptyCells--;
    }

    public Cell GetCell(CellLocation location) {
        return _grid[location.rowIndex, location.columnIndex];
    }

    public Cell GetCell(int rowIndex, int columnIndex) {
        return _grid[rowIndex, columnIndex];
    }

    public Cell[][] WinningArrangements() {
        Cell[][] winningArrangements = new Cell[8][];

        for (int i = 0; i < 3; i++) {
            winningArrangements[i] = Row(i);
            winningArrangements[i + 3] = Column(i);
            if (i != 2)
                winningArrangements[i + 6] = Diagonal(i);
        }

        return winningArrangements;
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

    public Cell[] Diagonal(int isPrincipal) {
        return Diagonal(Convert.ToBoolean(isPrincipal));
    }
}

public enum Cell {
    E,
    X,
    O
}
}
