using System;

namespace TicTacToeEngine {
public struct CellLocation {
    public int rowIndex { get; set; }
    public int columnIndex { get; set; }

    public CellLocation(int rowIndex, int columnIndex) {
        (this.rowIndex, this.columnIndex) = (0, 0);
        if (0 <= rowIndex && rowIndex < 3 && 0 <= columnIndex && columnIndex < 3) {
            this.rowIndex = rowIndex;
            this.columnIndex = columnIndex;
        } else {
            throw new ArgumentException($"Cell Location ({rowIndex}, {columnIndex}) is out of range.");
        }
    }

    public CellLocation((int rowIndex, int columnIndex) coordinates) :
        this(coordinates.rowIndex, coordinates.columnIndex) { }
}
}
