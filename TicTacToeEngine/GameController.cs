using System;

namespace TicTacToeEngine {
public class Scores {
    public int player1Score { get; internal set; }
    public int player2Score { get; internal set; }
    public int draws { get; internal set; }
}

public class GameController {
    private Player player1 { get; }
    private Player player2 { get; }
    private Round round { get; set; }

    public Board board => round.board;
    public Scores scores { get; }

    public event Action DrawBoard;
    public event Action RoundStarted;
    public event Action RoundEnded;

    public GameController(Player player1, Player player2) {
        (this.player1, this.player2) = (player1, player2);
        (this.player1.mark, this.player2.mark) = (Cell.X, Cell.O);
        scores = new Scores();
    }

    public Result StartGame() {
        round = new Round();
        RoundStarted?.Invoke();

        round.WinnerFound += player => {
            if (player == player1) {
                round.result = Result.PlayerOneWon;
                scores.player1Score++;
            }

            if (player == player2) {
                round.result = Result.PlayerTwoWon;
                scores.player2Score++;
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
            scores.draws++;
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
