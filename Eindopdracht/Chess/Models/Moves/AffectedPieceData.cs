using Chess.Models.Games;
using Chess.Models.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Models.Moves
{
    public class AffectedPieceData
    {
        public Square Start { get; set; }
        public Square Destination { get; set; }
        public Piece MovedPiece { get; set; }

        public AffectedPieceData(Square start, Square destination, Piece movedPiece)
        {
            this.Start = start;
            this.Destination = destination;
            MovedPiece = movedPiece;
        }   
    }
}
