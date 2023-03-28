using Chess.Models.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Models.Moves
{
    public class Move
    {
        private IList<AffectedPieceData> _affectedPieces;
        public Square Start { get; private set; }
        public Square Destination { get; private set; }
        
        public Move(Square start, Square destination)
        {
            _affectedPieces = new List<AffectedPieceData>();
            Start = start;
            Destination = destination;
        }

        public void Make(Game game)
        {
            _affectedPieces.Add(new AffectedPieceData(Start, Destination, Start.Piece));
            if(Destination.Piece != null)
            {
                // There is a piece to be captured
                _affectedPieces.Add(new AffectedPieceData(Destination, null, Destination.Piece));
            }

            Destination.Piece = Start.Piece;
            Start.Piece = null;
        }

        public void Undo(Game game)
        {
            foreach(AffectedPieceData affectedPieceData in _affectedPieces)
            {
                affectedPieceData.Start.Piece = affectedPieceData.MovedPiece;
                if(affectedPieceData.Destination != null)
                {
                    affectedPieceData.Destination.Piece = null;
                }
            }
            _affectedPieces.Clear();
        }
    }
}
