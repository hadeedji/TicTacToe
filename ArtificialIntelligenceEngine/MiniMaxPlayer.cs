using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using TicTacToeEngine;

namespace ArtificialIntelligenceEngine {
public class MiniMaxPlayer : AiPlayer {
    public override CellLocation MakeMove(Board board) {
        var position = new Position(board);
        var branches = position.GetBranchingPositions(mark);
        var scores = new int[branches.Length];

        for (var i = 0; i < branches.Length; i++) {
            scores[i] = MiniMax(branches[i], Int32.MinValue, Int32.MaxValue, false);
        }

        return position.EmptyCells()[scores.ToList().IndexOf(scores.Max())];
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
                bestScore = new int[] {bestScore, score}.Max();
                alpha = new int[] {alpha, score}.Max();
                if (beta <= alpha) {
                    break;
                }
            }

            return bestScore;
        } else {
            var branches = position.GetBranchingPositions(GetOppositeMark(mark));
            var bestScore = Int32.MaxValue;
            foreach (Position branch in branches) {
                var score = MiniMax(branch, alpha, beta, true);
                bestScore = new int[] {bestScore, score}.Min();
                beta = new int[] {beta, score}.Min();
                if (beta <= alpha) {
                    break;
                }
            }

            return bestScore;
        }
    }

    Cell GetOppositeMark(Cell mark) {
        return mark switch {
            Cell.O => Cell.X,
            Cell.X => Cell.O
        };
    }
}
}
