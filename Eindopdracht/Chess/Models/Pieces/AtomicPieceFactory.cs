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
    /// <summary>
    /// A factory that creates atomic chess pieces
    /// </summary>
    public class AtomicPieceFactory : PieceFactory
    {
        /// <summary>
        /// Creates the atomic chess piece factory
        /// </summary>
        /// <param name="color">The color of the pieces to create</param>
        /// <param name="direction">The direction the created pieces will considder forward</param>
        public AtomicPieceFactory(Color color, AdvanceDirections direction) : base(color, direction, new MoveFactory())
        {

        }

        public override Piece CreateBishop()
        {
            return new Piece("bishop.svg", Color, new DiagonalMovement(moveFactory));
        }

        public override Piece CreateKing()
        {
            CompositeMovement movementPattern = new CompositeMovement(moveFactory);
            movementPattern.AddMovementPattern(new OneAdjacentMovement(moveFactory));
            movementPattern.AddMovementPattern(new CastleMovement(moveFactory, Direction));
            return new Piece("king.svg", Color, movementPattern);
        }

        public override Piece CreateKnight()
        {
            return new Piece("knight.svg", Color, new KnightMovement(moveFactory));

        }

        public override Piece CreatePawn(AdvanceDirections direction)
        {
            return new Piece("pawn.svg", Color, new SingleAdvanceMovement(moveFactory, direction));
        }

        public override Piece CreateQueen()
        {
            CompositeMovement movementPattern = new CompositeMovement(moveFactory);
            movementPattern.AddMovementPattern(new DiagonalMovement(moveFactory));
            movementPattern.AddMovementPattern(new StraightLineMovement(moveFactory));
            return new Piece("queen.svg", Color, movementPattern);
        }

        public override Piece CreateRook()
        {
            return new Piece("rook.svg", Color, new StraightLineMovement(moveFactory));

        }

    }
}
