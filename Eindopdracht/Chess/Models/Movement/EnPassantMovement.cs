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
        private static readonly MoveOptions[] _moveOptions = { MoveOptions.ENPASSANT_CAPTURE };
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

            possibleMoves.Add(moveFactory.CreateMove(currentSquare, GetDestination(grid, currentLocation, 2, 0, _direction)));

            //// Is there a piece next to us with en passant movement as well?
            //if(destination.Piece.Movement.HasAbility(movement => movement is CastleMovement))
            //    possibleMoves.Add(moveFactory.CreateMove(currentSquare, GetDestination(grid, currentLocation, 2, 0, _direction)));



            return possibleMoves;

            

            //IList<Move> possibleMoves = new List<Move>();
            //Square currentSquare = grid.GetCurrentSquare(piece);
            //Location currentLocation = grid.GetCurrentLocation(currentSquare);

            //Square destination = GetDestination(grid, currentLocation, 0, 2);
            //if (destination != null)
            //{
            //    possibleMoves.Add(moveFactory.CreateMove(currentSquare, destination));
            //}

            //return possibleMoves;
        }
    }
}
