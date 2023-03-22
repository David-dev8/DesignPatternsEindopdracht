using Chess.Models.Games;
using Chess.Models.Moves;
using Chess.Models.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Chess.Models.Movesment
{
    public class StraightLineMovement : ContinuousMovement
    {
        public StraightLineMovement(MoveFactory moveFactory) : base(moveFactory)
        {
        }

        public override IEnumerable<Move> GetPossibleMoves(Piece piece, Square[][] grid)
        {
            List<Move> possibleMoves = new List<Move>();
            Square currentSquare = piece.Square;
            Location currentLocation = GetCurrentLocation(grid, currentSquare);

            possibleMoves.AddRange(GetPossibleMovesForSpecificDirection(grid, currentSquare, currentLocation, -1, 0));
            possibleMoves.AddRange(GetPossibleMovesForSpecificDirection(grid, currentSquare, currentLocation, 1, 0));
            possibleMoves.AddRange(GetPossibleMovesForSpecificDirection(grid, currentSquare, currentLocation, 0, -1));
            possibleMoves.AddRange(GetPossibleMovesForSpecificDirection(grid, currentSquare, currentLocation, 0, 1));

            return possibleMoves;
        }
    }
}
