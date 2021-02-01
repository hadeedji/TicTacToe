using System;

namespace TicTacToeEngine {
public abstract class Player {
    public string name { get; }
    public CellState mark { get; }

    protected Player(string name, CellState mark) {
        this.name = name;
        if (mark != CellState.E) {
            this.mark = mark;
        } else {
            throw new ArgumentException("Mark cannot be Empty.");
        }
    }

    public abstract (int, int) MakeMove(CellState[,] board);
}
}
