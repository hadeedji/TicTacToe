using System;

namespace TicTacToeEngine {
public class GameController {
    private Player player1 { get; }
    private Player player2 { get; }
    private Round round { get; set; }

    public GameController(Player player1, Player player2) {
        (this.player1, this.player2) = (player1, player2);
        (this.player1.mark, this.player2.mark) = (CellState.X, CellState.O);
    }

    public event Action<Board> DrawBoard;

    public Result StartGame() {
        round = new Round();
        do {
            DrawBoard(round.board);
            Move(round.movesMade % 2 == 0 ? player1: player2);
        } while (!round.HasEnded());
        DrawBoard(round.board);

        if (!round.haveWinner) {
            return Result.Draw;
        }

        return round.movesMade % 2 != 0 ? Result.PlayerOneWon : Result.PlayerTwoWon;
    }

    private void Move(Player player) {
        var move = player.MakeMove(round.board);
        round.Move(player, move);
    }
}

public enum Result {
    PlayerOneWon,
    PlayerTwoWon,
    Draw
}
}
