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
            IList<Move> possibleMoves = new List<Move>();
            Square currentSquare = piece.Square;
            Location currentLocation = GetCurrentLocation(grid, currentSquare);

            Square upperAdjacentSquare = GetDestination(grid, currentLocation, 1, 0); // TODO opties voor promotion
            if(upperAdjacentSquare != null && !upperAdjacentSquare.IsOccupied())
            {
                possibleMoves.Add(moveFactory.CreateMove(currentSquare, upperAdjacentSquare));
            }


            // TODO mustOccupied

            Square leftUpperAdjacentSquare = grid[currentLocation.Row + 1][currentLocation.Column - 1];
            if (leftUpperAdjacentSquare.IsOccupied())
            {
                possibleMoves.Add(moveFactory.CreateMove(currentSquare, leftUpperAdjacentSquare));
            }

            Square rightUpperAdjacentSquare = grid[currentLocation.Row + 1][currentLocation.Column + 1];
            if (rightUpperAdjacentSquare.IsOccupied())
            {
                possibleMoves.Add(moveFactory.CreateMove(currentSquare, rightUpperAdjacentSquare));
            }

            return possibleMoves;
        }

        private Move GetPossibleMoveForSpecificDirection(Square[][] grid, Square start, Location currentLocation, int rowDifference, int columnDifference)
        {
            Square destination = GetDestination(grid, currentLocation, rowDifference, columnDifference);
            return destination != null ? moveFactory.CreateMove(start, destination) : null;
        }

        private IEnumerable<Square> GetAllPossibleDestinations()
        {
            IList<Square> possibleDestinations = new List<Square>();
            possibleDestinations
        }
    }
}
