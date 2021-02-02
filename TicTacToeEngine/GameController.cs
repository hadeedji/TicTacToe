using System;

namespace TicTacToeEngine {
public class GameController {
    private Player player1 { get; }
    private Player player2 { get; }
    private Round round { get; set; }

    public event Action<Board> DrawBoard;

    public GameController(Player player1, Player player2) {
        (this.player1, this.player2) = (player1, player2);
        (this.player1.mark, this.player2.mark) = (Cell.X, Cell.O);
    }

    public Result StartGame() {
        round = new Round();
        
        round.WinnerFound += player => {
            if (player == player1) round.result = Result.PlayerOneWon;
            if (player == player2) round.result = Result.PlayerTwoWon;
        };
        
        do {
            DrawBoard?.Invoke(round.boardCopy);
            round.Move(player1);
            DrawBoard?.Invoke(round.boardCopy);
            
            if (round.inPlay)
                round.Move(player2);
            
        } while (round.inPlay);

        return round.result;
    }
}

public enum Result {
    PlayerOneWon,
    PlayerTwoWon,
    Draw
}
}
