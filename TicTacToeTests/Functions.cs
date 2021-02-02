using System;
using TicTacToeEngine;

namespace TicTacToeTests {
public static class Functions {
    public static CellState CellStateFromCharacter(char stateCharacter) {
        CellState state = stateCharacter switch {
            'e' => CellState.E,
            'x' => CellState.X,
            'o' => CellState.O,
            _ => throw new ArgumentOutOfRangeException(nameof(stateCharacter), stateCharacter, null)
        };
        return state;
    }

    public static void FillBoard(string stateString, Board board) {
        int rowIndex = 0;
        int columnIndex = 0;
        foreach (char stateCharacter in stateString) {
            board[rowIndex, columnIndex++] = CellStateFromCharacter(stateCharacter);
            if (columnIndex == 3) {
                rowIndex++;
                columnIndex = 0;
            }
        }
    }

    public static (CellState[] r1, CellState[] r2, CellState[] r3) Rows(string stateString) {
        int i = 0;
        CellState[] r1 = new CellState[3];
        foreach (char state in stateString.Substring(0, 3)) {
            r1[i++] = CellStateFromCharacter(state);
        }

        int j = 0;
        CellState[] r2 = new CellState[3];
        foreach (char state in stateString.Substring(3, 3)) {
            r2[j++] = CellStateFromCharacter(state);
        }

        int k = 0;
        CellState[] r3 = new CellState[3];
        foreach (char state in stateString.Substring(6, 3)) {
            r3[k++] = CellStateFromCharacter(state);
        }

        return (r1, r2, r3);
    }

    public static (CellState[] c1, CellState[] c2, CellState[] c3) Columns(string stateString) {
        int i = 0;
        var c1 = new CellState[3];
        var c2 = new CellState[3];
        var c3 = new CellState[3];

        for (var j = 0; j < stateString.Length; j++) {
            char state = stateString[j];
            switch (j % 3) {
                case 0:
                    c1[i] = CellStateFromCharacter(state);
                    break;
                case 1:
                    c2[i] = CellStateFromCharacter(state);
                    break;
                case 2:
                    c3[i++] = CellStateFromCharacter(state);
                    break;
            }
        }

        return (c1, c2, c3);
    }
}
}
