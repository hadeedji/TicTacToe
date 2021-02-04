using System;
using System.Linq;
using System.Threading;
using TicTacToeEngine;

namespace ArtificialIntelligenceEngine {
public class MiniMaxPlayer : AiPlayer {
    private Random randomNumberGenerator { get; }

    public MiniMaxPlayer(Random randomNumberGenerator) {
        this.randomNumberGenerator = randomNumberGenerator;
    }

    public override CellLocation MakeMove(Board board) {
        var position = new Position(board);
        var branches = position.GetBranchingPositions(mark);
        var scores = new int[branches.Length];

        var threads = new Thread[branches.Length];
        for (var index = 0; index < branches.Length; index++) {
            var i = index;
            threads[i] = new Thread(new ThreadStart(delegate {
                scores[i] = MiniMax(branches[i], Int32.MinValue, Int32.MaxValue, false);
            }));
            threads[i].Start();
        }

        for (int i = 0; i < branches.Length; i++) {
            threads[i].Join();
        }
        
        var maxScores = scores.Select((score, index) => score == scores.Max() ? index : -1).Where(index => index != -1).ToArray();
        return position.EmptyCells()[maxScores[randomNumberGenerator.Next(maxScores.Length)]];
    }

    int MiniMax(Position position, int alpha, int beta, bool myTurn) {
        if (position.IsOver()) {
            return position.StaticEvaluation(mark);
        }

        if (myTurn) {
            var branches = position.GetBranchingPositions(mark);
            var bestScore = Int32.MinValue;
            foreach (Position branch in branches) {
                var score = MiniMax(branch, alpha, beta, false);
                bestScore = new[] {bestScore, score}.Max();
                alpha = new[] {alpha, score}.Max();
                if (beta <= alpha) break;
            }

            return bestScore;
        } else {
            var branches = position.GetBranchingPositions(GetOppositeMark(mark));
            var bestScore = Int32.MaxValue;
            foreach (Position branch in branches) {
                var score = MiniMax(branch, alpha, beta, true);
                bestScore = new[] {bestScore, score}.Min();
                beta = new[] {beta, score}.Min();
                if (beta <= alpha) break;
            }

            return bestScore;
        }
    }

    Cell GetOppositeMark(Cell ofMark) {
        return ofMark switch {
            Cell.O => Cell.X,
            Cell.X => Cell.O,
            _ => throw new ArgumentOutOfRangeException(nameof(ofMark), ofMark, null)
        };
    }
}
}
