using Chess.Models.Movement;
using Chess.Models.Moves;
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
        public RegularPieceFactory(Color color) : base(color, new MoveFactory())
        {
            
        }

        public override Piece CreateBischop()
        {
            return new Piece("", color, new DiagonalMovement(moveFactory));
        }

        public override Piece CreateKing()
        {
            CompositeMovement movementPattern = new CompositeMovement(moveFactory);
            movementPattern.AddMovementPattern(new OneAdjacentMovement(moveFactory));
            movementPattern.AddMovementPattern(new CastleMovement(moveFactory));
            return new Piece("", color, movementPattern);

        }

        public override Piece CreateKnight()
        {
            return new Piece("", color, new KnightMovement(moveFactory));

        }

        public override Piece CreatePawn()
        {
            return new Piece("", color, new SingleAdvanceMovement(moveFactory));

        }

        public override Piece CreateQueen()
        {
            CompositeMovement movementPattern = new CompositeMovement(moveFactory);
            movementPattern.AddMovementPattern(new DiagonalMovement(moveFactory));
            movementPattern.AddMovementPattern(new StraightLineMovement(moveFactory));
            return new Piece("", color, movementPattern);
        }

        public override Piece CreateRook()
        {
            return new Piece("", color, new StraightLineMovement(moveFactory));

        }
    }
}
