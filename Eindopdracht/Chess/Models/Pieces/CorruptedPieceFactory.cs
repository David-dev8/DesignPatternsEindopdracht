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
    public class CorruptedPieceFactory : PieceFactory
    {
        public CorruptedPieceFactory(Color color, AdvanceDirections direction) : base(color, direction, new MoveFactory())
        {

        }

        public override Piece CreateBishop()
        {
            return new Piece("corruptedBishop.svg", Color, new SingleAdvanceMovement(moveFactory, Direction));
        }

        public override Piece CreateKing()
        {
            return new Piece("corruptedKing.svg", Color, new KnightMovement(moveFactory));
        }

        public override Piece CreateKnight()
        {
            CompositeMovement movementPattern = new CompositeMovement(moveFactory);
            movementPattern.AddMovementPattern(new KnightMovement(moveFactory));
            movementPattern.AddMovementPattern(new StraightLineMovement(moveFactory));
            return new Piece("corruptedKnight.svg", Color, movementPattern);

        }

        public override Piece CreatePawn(AdvanceDirections direction)
        {
            return new Piece("corruptedPawn.svg", Color, new DiagonalMovement(moveFactory));
        }

        public override Piece CreateQueen()
        {
            CompositeMovement movementPattern = new CompositeMovement(moveFactory);
            movementPattern.AddMovementPattern(new OneAdjacentMovement(moveFactory));
            movementPattern.AddMovementPattern(new KnightMovement(moveFactory));
            return new Piece("corruptedQueen.svg", Color, movementPattern);
        }

        public override Piece CreateRook()
        {
            return new Piece("corruptedRook.svg", Color, new OneAdjacentMovement(moveFactory));
        }

    }
}