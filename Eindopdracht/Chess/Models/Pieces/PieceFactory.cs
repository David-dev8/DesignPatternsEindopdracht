using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Chess.Models.Pieces
{
    public abstract class PieceFactory
    {
        private Color _color;

        public PieceFactory(Color color) 
        { 
            _color = color;
        }

        public abstract Piece CreateKing();
        public abstract Piece CreateQueen();
        public abstract Piece CreatePawn();
        public abstract Piece CreateRook();
        public abstract Piece CreateKnight();
        public abstract Piece CreateBischop();
    }
}
