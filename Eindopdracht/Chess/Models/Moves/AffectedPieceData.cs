using Chess.Models.Games;
using Chess.Models.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Models.Moves
{
    /// <summary>
    /// This class stores data on wich and how pieces get affected by a moce
    /// </summary>
    public class AffectedPieceData
    {
        public Square Start { get; set; }
        public Square Destination { get; set; }
        public Piece MovedPiece { get; set; }

        /// <summary>
        /// Creates a affectedPieceData object
        /// </summary>
        /// <param name="start">The startpossition of the move</param>
        /// <param name="destination">The destination of the move</param>
        /// <param name="movedPiece">The piece that is doing the movement</param>
        public AffectedPieceData(Square start, Square destination, Piece movedPiece)
        {
            this.Start = start;
            this.Destination = destination;
            MovedPiece = movedPiece;
        }
        
        /// <summary>
        /// Checks wether a given piece is the piece that moves in this movedate object
        /// </summary>
        /// <param name="piece">The piece to check</param>
        /// <returns>A boolean value indicating wether the given pieces moves in this date</returns>
        public bool IsMovedPiece(Piece piece)
        {
            return MovedPiece.Equals(piece);
        }

        /// <summary>
        /// Reverses this movement
        /// </summary>
        public void Reverse()
        {
            Start.Piece = MovedPiece;
            if (Destination != null)
            {
                Destination.Piece = null;
            }
        }
    }
}
