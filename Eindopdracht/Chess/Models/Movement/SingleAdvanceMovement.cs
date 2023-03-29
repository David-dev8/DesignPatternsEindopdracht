using Chess.Extensions;
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
    /// <summary>
    /// The movementpatern for a single move forward like a pawn
    /// </summary>
    public class SingleAdvanceMovement : MovementPattern
    {
        private static readonly MoveOptions[] _moveOptions = { MoveOptions.PROMOTION };
        private AdvanceDirections _direction;

        public SingleAdvanceMovement(MoveFactory moveFactory, AdvanceDirections direction) : base(moveFactory)
        {
            _direction = direction;
        }

        public override IEnumerable<Move> GetPossibleMoves(Piece piece, Square[][] grid)
        {
            IList<Move> possibleMoves = new List<Move>();
            Square currentSquare = grid.GetCurrentSquare(piece);
            Location currentLocation = grid.GetCurrentLocation(currentSquare);

            RegisterPossibleMoveForSpecificDirection(grid, currentSquare, currentLocation, 0, possibleMoves, false);
            RegisterPossibleMoveForSpecificDirection(grid, currentSquare, currentLocation, -1, possibleMoves, true);
            RegisterPossibleMoveForSpecificDirection(grid, currentSquare, currentLocation, 1, possibleMoves, true);

            return possibleMoves;
        }

        /// <summary>
        /// Registers all possible moves for a specific direction for a specific piece 
        /// </summary>
        /// <param name="grid">The grid to perform it on</param>
        /// <param name="start">The current square of the piece</param>
        /// <param name="currentLocation">The current location of the piece</param>
        /// <param name="columnDifference">The difference to the column this piece has started in</param>
        /// <param name="possibleMoves">A list with all possible moves</param>
        /// <param name="shouldBeOccupied">Indicates whether the destination should be occupied</param>
        private void RegisterPossibleMoveForSpecificDirection(Square[][] grid, Square start, Location currentLocation, int columnDifference, 
            IList<Move> possibleMoves, bool shouldBeOccupied)
        {
            Square adjacentSquare = GetDestination(grid, currentLocation, -1, columnDifference, _direction);
            if (adjacentSquare != null && adjacentSquare.IsOccupied == shouldBeOccupied)
            {
                possibleMoves.Add(moveFactory.CreateMove(start, adjacentSquare, _moveOptions, _direction));
            }
        }
    }
}
