using Chess.Extensions;
using Chess.Models.Games;
using Chess.Models.Moves;
using Chess.Models.Pieces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Chess.Models.Movement
{
    /// <summary>
    /// This is a movementpatern for the castelling movement
    /// </summary>
    public class CastleMovement : MovementPattern
    {
        private static readonly MoveOptions[] _moveOptions = { MoveOptions.CASTLING };
        private AdvanceDirections _direction;
        private bool _intiatesCastling;

        /// <summary>
        /// Creates a castleing movement
        /// </summary>
        /// <param name="moveFactory">The factory to use to create this movement</param>
        /// <param name="direction">The direction to castle in</param>
        /// <param name="intiatesCastling">The piece that initiates the castleing move</param>
        public CastleMovement(MoveFactory moveFactory, AdvanceDirections direction, bool intiatesCastling = false) : base(moveFactory)
        {
            _direction = direction;
            _intiatesCastling = intiatesCastling;
        }

        public override IEnumerable<Move> GetPossibleMoves(Piece piece, Square[][] grid)
        {
            if(!_intiatesCastling)
            {
                return Enumerable.Empty<Move>();
            }

            IList<Move> possibleMoves = new List<Move>();
            Square square = grid.GetCurrentSquare(piece);
            Location currentLocation = grid.GetCurrentLocation(square);

            // Look to the right and to the left
            RegisterWhileLookingInDirection(grid, square, currentLocation, -1, possibleMoves);
            RegisterWhileLookingInDirection(grid, square, currentLocation, 1, possibleMoves);

            return possibleMoves;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="grid">The grid that represents the game board</param>
        /// <param name="start">The startpossition of the initiating piece</param>
        /// <param name="currentLocation"></param>
        /// <param name="columnDifference"></param>
        /// <param name="possibleMoves"></param>
        private void RegisterWhileLookingInDirection(Square[][] grid, Square start, Location currentLocation, int columnDifference, IList<Move> possibleMoves)
        {
            Square destination;
            int row = currentLocation.Row;
            int nextColumn = columnDifference;

            // Continue looking until we find another piece that has the ability for castleMovement
            while(IsWithinBounds(grid, row, currentLocation.Column + nextColumn))
            {
                destination = GetDestination(grid, currentLocation, 0, nextColumn, _direction);
                if(destination.IsOccupied)
                {
                    if(destination.Piece.Movement.HasAbility(movement => movement is CastleMovement))
                    {
                        possibleMoves.Add(moveFactory.CreateMove(start, GetDestination(grid, currentLocation, 0, columnDifference * 2, _direction), _moveOptions));
                    }
                    break;
                }
                nextColumn += columnDifference;
            }
        }
    }
}
