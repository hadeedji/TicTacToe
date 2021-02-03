namespace TicTacToeEngine {
public abstract class Player {
    public Cell mark { get; internal set; }

    public abstract CellLocation MakeMove(Board board);
}
}
