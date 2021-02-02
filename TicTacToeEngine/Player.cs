namespace TicTacToeEngine {
public abstract class Player {
    public string name { get; }
    public Cell mark { get; internal set; }

    protected Player(string name) {
        this.name = name;
    }

    public abstract CellLocation MakeMove(Board board);
}
}
