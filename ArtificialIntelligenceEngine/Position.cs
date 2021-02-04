using System.Collections.Generic;
using TicTacToeEngine;

namespace ArtificialIntelligenceEngine {
internal readonly struct Position {
    private Cell[,] grid { get; }

    public Position(Board board) {
        grid = new Cell[3, 3];
        for (int rowIndex = 0; rowIndex < 3; rowIndex++) {
            for (int columnIndex = 0; columnIndex < 3; columnIndex++) {
                grid[rowIndex, columnIndex] = board.GetCell(rowIndex, columnIndex);
            }
        }
    }

    private Position(Cell[,] grid) {
        this.grid = grid;
    }


    public int StaticEvaluation(Cell mark) {
        var winner = FindWinner();
        if (winner == Cell.E)
            return 0;

        if (winner == mark)
            return 1;

        return -1;
    }

    public bool IsOver() {
        if (FindWinner() != Cell.E)
            return true;

        for (int rowIndex = 0; rowIndex < 3; rowIndex++) {
            for (int columnIndex = 0; columnIndex < 3; columnIndex++) {
                if (grid[rowIndex, columnIndex] == Cell.E)
                    return false;
            }
        }

        return true;
    }

    public Position PlaceMark(Cell mark, CellLocation location) {
        var newGrid = new Cell[3, 3];
        for (int rowIndex = 0; rowIndex < 3; rowIndex++) {
            for (int columnIndex = 0; columnIndex < 3; columnIndex++) {
                if ((rowIndex, columnIndex) == (location.rowIndex, location.columnIndex)) {
                    newGrid[rowIndex, columnIndex] = mark;
                } else {
                    newGrid[rowIndex, columnIndex] = grid[rowIndex, columnIndex];
                }
            }
        }

        return new Position(newGrid);
    }

    public Position[] GetBranchingPositions(Cell mark) {
        var positionsAcc = new List<Position>();
        for (int rowIndex = 0; rowIndex < 3; rowIndex++) {
            for (int columnIndex = 0; columnIndex < 3; columnIndex++) {
                if (grid[rowIndex, columnIndex] == Cell.E) {
                    positionsAcc.Add(PlaceMark(mark, new CellLocation(rowIndex, columnIndex)));
                }
            }
        }

        return positionsAcc.ToArray();
    }

    private Cell FindWinner() {
        for (int i = 0; i < 3; i++) {
            var row = GetRow(i);
            if (row[0] != Cell.E)
                if (row[0] == row[1] && row[1] == row[2])
                    return row[0];

            var column = GetColumn(i);
            if (column[0] != Cell.E)
                if (column[0] == column[1] && column[1] == column[2])
                    return column[0];

            if (i != 2) {
                var diagonal = GetDiagonal(i == 0);
                if (diagonal[0] != Cell.E)
                    if (diagonal[0] == diagonal[1] && diagonal[1] == diagonal[2])
                        return diagonal[0];
            }
        }

        return Cell.E;
    }

    private Cell[] GetRow(int rowIndex) {
        Cell[] row = new Cell[3];
        for (int columnIndex = 0; columnIndex < 3; columnIndex++) {
            row[rowIndex] = grid[rowIndex, columnIndex];
        }

        return row;
    }

    private Cell[] GetColumn(int columnIndex) {
        Cell[] column = new Cell[3];
        for (int rowIndex = 0; rowIndex < 3; rowIndex++) {
            column[rowIndex] = grid[rowIndex, columnIndex];
        }

        return column;
    }

    private Cell[] GetDiagonal(bool isPrincipal) {
        Cell[] diagonal = new Cell[3];
        for (int i = 0; i < 3; i++) {
            diagonal[i] = grid[isPrincipal ? i : 2 - 1, i];
        }

        return diagonal;
    }
}
}
