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
    /// A factory that creates normal pieces
    /// </summary>
    public class RegularPieceFactory : PieceFactory
    {
        /// <summary>
        /// Creates a normal piece factory
        /// </summary>
        /// <param name="color">The color of the pieces to produce</param>
        /// <param name="direction">The direction the created pieces will consider forward</param>
        public RegularPieceFactory(Color color, AdvanceDirections direction) : base(color, direction, new MoveFactory())
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
            movementPattern.AddMovementPattern(new CastleMovement(moveFactory, Direction, true));
            return new Piece("king.svg", Color, movementPattern);
        }

        public override Piece CreateKnight()
        {
            return new Piece("knight.svg", Color, new KnightMovement(moveFactory));

        }

        public override Piece CreatePawn()
        {
            CompositeMovement movementPattern = new CompositeMovement(moveFactory);
            movementPattern.AddMovementPattern(new SingleAdvanceMovement(moveFactory, Direction));
            movementPattern.AddMovementPattern(new EnPassantMovement(moveFactory, Direction));
            return new Piece("pawn.svg", Color, movementPattern);
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
            CompositeMovement movementPattern = new CompositeMovement(moveFactory);
            movementPattern.AddMovementPattern(new StraightLineMovement(moveFactory));
            movementPattern.AddMovementPattern(new CastleMovement(moveFactory, Direction));
            return new Piece("rook.svg", Color, movementPattern);
        }
    }
}
