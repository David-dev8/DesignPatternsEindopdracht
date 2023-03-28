using Chess.Extensions;
using Chess.Models.Games;
using Chess.Models.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Models.Moves
{
    /// <summary>
    /// A class representing a move
    /// </summary>
    public class Move
    {
        private const int SCORE_PER_AFFECTED_PIECE = 5;
        protected IList<AffectedPieceData> affectedPieces;
        public Square Start { get; private set; }
        public Square Destination { get; private set; }
        public int Score
        {
            get
            {
                return affectedPieces.Count * SCORE_PER_AFFECTED_PIECE;
            }
        }
        
        /// <summary>
        /// Creates a move
        /// </summary>
        /// <param name="start">The square that started this move</param>
        /// <param name="destination">The square this movement ends on</param>
        public Move(Square start, Square destination)
        {
            affectedPieces = new List<AffectedPieceData>();
            Start = start;
            Destination = destination;
        }

        /// <summary>
        /// Makes the move happen in a game
        /// </summary>
        /// <param name="game">The game to make the move happen in</param>
        public virtual void Make(Game game)
        {
            affectedPieces.Add(new AffectedPieceData(Start, Destination, Start.Piece));
            if(Destination.Piece != null)
            {
                // There is a piece to be captured
                affectedPieces.Add(new AffectedPieceData(Destination, null, Destination.Piece));
            }

            Destination.Piece = Start.Piece;
            Start.Piece = null;
        }

        /// <summary>
        /// Undoes this move if it has been done
        /// </summary>
        /// <param name="game"></param>
        public virtual void Undo(Game game)
        {
            foreach(AffectedPieceData affectedPieceData in affectedPieces)
            {
                affectedPieceData.Reverse();
            }
            affectedPieces.Clear();
        }

        /// <summary>
        /// Clone this movement
        /// </summary>
        /// <param name="start">The square that started this move</param>
        /// <param name="destination">The square this movement ends on</param>
        /// <returns>A cloned movement</returns>
        public Move Clone(Square start, Square destination)
        {
            return new Move(start, destination);
        }

        /// <summary>
        /// Checks if a piece is affected by this movement
        /// </summary>
        /// <param name="piece">The piece to check for</param>
        /// <returns>A boolean value indicating wether the given piece is affected by the movement </returns>
        public bool IsAffected(Piece piece)
        {
            foreach(AffectedPieceData affectedPieceData in affectedPieces)
            {
                if (affectedPieceData.IsMovedPiece(piece))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Checks if it is posible to make this move
        /// </summary>
        /// <param name="game">The game to check for possibilities in</param>
        /// <returns>A boolean value indicating wether this move is possible</returns>
        public virtual bool CanBeMade(Game game)
        {
            return true;
        }
    }
}
