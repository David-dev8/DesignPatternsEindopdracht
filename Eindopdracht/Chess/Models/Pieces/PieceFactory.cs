using Chess.Models.Moves;
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
        protected MoveFactory moveFactory;

        public Color Color { get; set; }

        public PieceFactory(Color color, MoveFactory moveFactory) 
        { 
            Color = color;
            this.moveFactory = moveFactory;
        }

        public abstract Piece CreateKing();
        public abstract Piece CreateQueen();
        public abstract Piece CreatePawn();
        public abstract Piece CreateRook();
        public abstract Piece CreateKnight();
        public abstract Piece CreateBishop();
    }
}
