using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Chess.Models.Pieces
{
    public class RegularPieceFactory : PieceFactory
    {
        public RegularPieceFactory(Color color) : base(color)
        {
        }

        public override Piece CreateBishop()
        {
            throw new NotImplementedException();
        }

        public override Piece CreateKing()
        {
            throw new NotImplementedException();
        }

        public override Piece CreateKnight()
        {
            throw new NotImplementedException();
        }

        public override Piece CreatePawn()
        {
            throw new NotImplementedException();
        }

        public override Piece CreateQueen()
        {
            throw new NotImplementedException();
        }

        public override Piece CreateRook()
        {
            throw new NotImplementedException();
        }
    }
}
