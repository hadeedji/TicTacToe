using System;
using System.Diagnostics;
using NUnit.Framework;
using TicTacToeEngine;

namespace TicTacToeTests {
public partial class BoardTests {
    [SetUp]
    public void Setup() {
        board = new Board();
    }

    [Test]
    public void InitializeBoard_RowsShouldBeEmpty() {
        Array.TrueForAll(board.Row(1), (state) => state == CellState.E);
        Array.TrueForAll(board.Row(2), (state) => state == CellState.E);
        Array.TrueForAll(board.Row(3), (state) => state == CellState.E);
    }

    [Test]
    public void InitializeBoard_ColumnsShouldBeEmpty() {
        Array.TrueForAll(board.Column(1), (state) => state == CellState.E);
        Array.TrueForAll(board.Column(2), (state) => state == CellState.E);
        Array.TrueForAll(board.Column(3), (state) => state == CellState.E);
    }

    [Test]
    public void FillBoard_ReadRows() {
        var stateString = "eoo" +
                          "oxe" +
                          "eoo";
        FillBoard(stateString);
        var (r1, r2, r3) = Rows(stateString);

        Assert.AreEqual(r1, board.Row(1));
        Assert.AreEqual(r2, board.Row(2));
        Assert.AreEqual(r3, board.Row(3));
    }

    [Test]
    public void FillBoard_ReadColumns() {
        var stateString = "eoo" +
                          "oxe" +
                          "eoo";
        FillBoard(stateString);
        var (c1, c2, c3) = Columns(stateString);
        Assert.AreEqual(c1, board.Column(1));
        Assert.AreEqual(c2, board.Column(2));
        Assert.AreEqual(c3, board.Column(3));
    }

    [Test]
    public void FillBoard_ReadDiagonals() {
        var stateString = "eoe" +
                          "oxe" +
                          "oox";
        FillBoard(stateString);
        var principalExpected = new[] {
            CellStateFromCharacter('e'),
            CellStateFromCharacter('x'),
            CellStateFromCharacter('x')
        };
        var nonPrincipalExpected = new[] {
            CellStateFromCharacter('o'),
            CellStateFromCharacter('x'),
            CellStateFromCharacter('e')
        };
        
        Assert.AreEqual(principalExpected,board.Diagonal(true));
        Assert.AreEqual(nonPrincipalExpected,board.Diagonal(false));
    }
}
}
