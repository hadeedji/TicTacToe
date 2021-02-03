using System;

namespace TicTacToeEngine {
public class GameController {
    private Player player1 { get; }
    private Player player2 { get; }
    private Round round { get; set; }

    public Board board => round.board;
    public int player1Score { get; private set; }
    public int player2Score { get; private set; }
    public int draws { get; private set; }

    public event Action DrawBoard;
    public event Action RoundStarted;
    public event Action RoundEnded;

    public GameController(Player player1, Player player2) {
        (this.player1, this.player2) = (player1, player2);
        (this.player1.mark, this.player2.mark) = (Cell.X, Cell.O);
    }

    public Result StartGame() {
        round = new Round();
        RoundStarted?.Invoke();

        round.WinnerFound += player => {
            if (player == player1) {
                round.result = Result.PlayerOneWon;
                player1Score++;
            }

            if (player == player2) {
                round.result = Result.PlayerTwoWon;
                player2Score++;
            }
        };

        DrawBoard?.Invoke();
        do {
            round.Move(player1);
            DrawBoard?.Invoke();

            if (round.inPlay) {
                round.Move(player2);
                DrawBoard?.Invoke();
            }
        } while (round.inPlay);

        if (round.result == Result.Draw) {
            draws++;
        }

        RoundEnded?.Invoke();
        return round.result;
    }
}

public enum Result {
    PlayerOneWon,
    PlayerTwoWon,
    Draw
}
}
