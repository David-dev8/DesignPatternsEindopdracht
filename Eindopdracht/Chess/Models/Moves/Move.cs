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
        private Square _start;
        private Square _destination;
        
        public Move(Square start, Square destination)
        {
            _affectedPieces = new List<AffectedPieceData>();
            _start = start;
            _destination = destination;
        }

        public void Make(Game game)
        {
            _destination.Piece = _start.Piece;
            _affectedPieces.Add(new AffectedPieceData(_start, _destination, _start.Piece));
        }

        public void Undo(Game game)
        {
            foreach(AffectedPieceData affectedPieceData in _affectedPieces)
            {
                affectedPieceData.Start.Piece = affectedPieceData.MovedPiece;
                affectedPieceData.Destination.Piece = null;
                _affectedPieces.Remove(affectedPieceData);
            }
        }
    }
}
