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

namespace Chess.Models.Movement
{
    /// <summary>
    /// A class for the special en passant move
    /// </summary>
    public class EnPassantMovement : MovementPattern
    {
        private static readonly MoveOptions[] _moveOptions = { MoveOptions.ENPASSANT };
        private AdvanceDirections _direction;

        public EnPassantMovement(MoveFactory moveFactory, AdvanceDirections direction) : base(moveFactory)
        {
            _direction = direction;
        }

        /// <summary>
        /// Gets the possibilities for en passant moves
        /// </summary>
        /// <param name="piece">The piece to perform the move</param>
        /// <param name="grid">The grid to perform it on</param>
        /// <returns></returns>
        public override IEnumerable<Move> GetPossibleMoves(Piece piece, Square[][] grid)
        {
            IList<Move> possibleMoves = new List<Move>();
            Square currentSquare = grid.GetCurrentSquare(piece);
            Location currentLocation = grid.GetCurrentLocation(currentSquare);

            possibleMoves.Add(moveFactory.CreateMove(currentSquare, GetDestination(grid, currentLocation, -2, 0, _direction), _moveOptions));

            RegisterPossibleEnPassantCapture(grid, currentSquare, currentLocation, 1, possibleMoves);
            RegisterPossibleEnPassantCapture(grid, currentSquare, currentLocation, -1, possibleMoves);

            return possibleMoves;
        }

        private void RegisterPossibleEnPassantCapture(Square[][] grid, Square start, Location currentLocation, int columnDifference,
            IList<Move> possibleMoves)
        {
            // Is there a piece next to us with en passant movement as well?
            Square adjacentSquare = GetDestination(grid, currentLocation, 0, columnDifference, _direction);
            if(adjacentSquare?.Piece != null && adjacentSquare.Piece.Movement.HasAbility(movement => movement is EnPassantMovement)
                && adjacentSquare.Piece.Color != start.Piece.Color)
            {
                possibleMoves.Add(moveFactory.CreateMove(start, GetDestination(grid, currentLocation, -1, columnDifference, _direction), _moveOptions));
            }
        }
    }
}
