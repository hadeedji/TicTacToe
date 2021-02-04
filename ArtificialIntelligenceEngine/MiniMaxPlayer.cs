using System;
using System.Collections.Generic;
using System.Linq;
using TicTacToeEngine;

namespace ArtificialIntelligenceEngine {
public class MiniMaxPlayer : Player {
    public override CellLocation MakeMove(Board board) {
        var emptyCells = new List<CellLocation>();
        for (int rowIndex = 0; rowIndex < 3; rowIndex++) {
            for (int columnIndex = 0; columnIndex < 3; columnIndex++) {
                if (board.GetCell(rowIndex, columnIndex) == Cell.E) {
                    emptyCells.Add(new CellLocation(rowIndex, columnIndex));
                }
            }
        }

        var position = new Position(board);
        var scores = new int[emptyCells.Count];
        for (int i = 0; i < scores.Length; i++) {
            scores[i] = MiniMax(position.PlaceMark(mark, emptyCells.ToArray()[i]), false);
        }
        
        return emptyCells.ToArray()[scores.ToList().IndexOf(scores.Max())];
    }

    int MiniMax(Position position, bool myTurn) {
        if (position.IsOver()) {
            return position.StaticEvaluation(mark);
        }

        if (myTurn) {
            var branches = position.GetBranchingPositions(mark);
            var scores = branches.Select(position => MiniMax(position, false)).ToArray();
            return scores.Max();
        } else {
            var branches = position.GetBranchingPositions(GetOppositeMark(mark));
            var scores = branches.Select(position => MiniMax(position, true)).ToArray();
            return scores.Min();
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
