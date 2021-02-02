using System;

namespace TicTacToeEngine {
public struct CellLocation {
    private int _rowIndex;
    private int _columnIndex;

    public int rowIndex => _rowIndex;
    public int columnIndex => _columnIndex;

    public CellLocation(int rowIndex, int columnIndex) {
        (_rowIndex, _columnIndex) = (0, 0);
        if (0 <= rowIndex && rowIndex < 3 && 0 <= columnIndex && columnIndex < 3) {
            _rowIndex = rowIndex;
            _columnIndex = columnIndex;
        } else {
            throw new ArgumentException($"Cell Location ({rowIndex}, {columnIndex}) is out of range.");
        }
    }
}
}
