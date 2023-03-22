using Chess.Models.Games;
using Chess.Models.Moves;
using Chess.Models.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Models.Movement
{
    public class SingleAdvanceMovement : MovementPattern
    {
        public SingleAdvanceMovement(MoveFactory moveFactory) : base(moveFactory)
        {
        }

        public override IEnumerable<Move> GetPossibleMoves(Piece piece, Square[][] grid)
        {
            List<Move> possibleMoves = new List<Move>();
            Square currentSquare = piece.Square;
            Location currentLocation = GetCurrentLocation(grid, currentSquare);

            Square upperAdjacentSquare = grid[currentLocation.Row + 1][currentLocation.Column];
            if(!upperAdjacentSquare.IsOccupied())
            {
                possibleMoves.Add(moveFactory.CreateMove(currentSquare, upperAdjacentSquare));
            }

            Square leftUpperAdjacentSquare = grid[currentLocation.Row + 1][currentLocation.Column - 1];
            if (upperAdjacentSquare.IsOccupied())
            {
                possibleMoves.Add(moveFactory.CreateMove(currentSquare, leftUpperAdjacentSquare));
            }

            Square rightUpperAdjacentSquare = grid[currentLocation.Row + 1][currentLocation.Column + 1];
            if (upperAdjacentSquare.IsOccupied())
            {
                possibleMoves.Add(moveFactory.CreateMove(currentSquare, rightUpperAdjacentSquare));
            }

            return possibleMoves;
        }
    }
}
