namespace TicTacToeEngine {
public abstract class Player {
    public string name { get; }
    public CellState mark { get; internal set; }

    protected Player(string name) {
        this.name = name;
    }

    public abstract (int, int) MakeMove(Board board);
}
}
