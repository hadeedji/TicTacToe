using System;
using System.Collections.Generic;
using TicTacToeEngine;

namespace ArtificialIntelligenceEngine {
public class RandomPlayer : Player {
    private Random randomNumberGenerator { get; }

    public RandomPlayer(Random randomNumberGenerator){
        this.randomNumberGenerator = randomNumberGenerator;
    }

    public override CellLocation MakeMove(Board board) {
        var validMoves = new List<CellLocation>();

        for (int i = 0; i < 3; i++) {
            for (int j = 0; j < 3; j++) {
                var cellLocation = new CellLocation(i, j);
                if (board.GetCell(cellLocation) == Cell.E) {
                    validMoves.Add(cellLocation);
                }
            }
        }

        int moveIndex = randomNumberGenerator.Next(validMoves.Count);
        return validMoves[moveIndex];
    }
}
}
