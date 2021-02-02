namespace TicTacToeEngine {
public abstract class Player {
    internal Cell mark { get; set; }

    public abstract CellLocation MakeMove(Board board);
}
}
