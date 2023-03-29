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
        public AtomicPieceFactory(Color color, AdvanceDirections direction) : base(color, direction, new ExplosiveMoveFactory())
        {

        }

        public override Piece CreateBishop()
        {
            return new Piece("explosiveBishop.svg", Color, new DiagonalMovement(moveFactory));
        }

        public override Piece CreateKing()
        {
            // A king cannot explode, therefore do not use the factory for explosive moves
            MoveFactory moveFactory = new MoveFactory();
            return new Piece("forbiddenExplosionKing.svg", Color, new OneAdjacentMovement(moveFactory));
        }

        public override Piece CreateKnight()
        {
            return new Piece("explosiveKnight.svg", Color, new KnightMovement(moveFactory));

        }

        public override Piece CreatePawn(AdvanceDirections direction)
        {
            return new Piece("explosivePawn.svg", Color, new SingleAdvanceMovement(moveFactory, direction));
        }

        public override Piece CreateQueen()
        {
            CompositeMovement movementPattern = new CompositeMovement(moveFactory);
            movementPattern.AddMovementPattern(new DiagonalMovement(moveFactory));
            movementPattern.AddMovementPattern(new StraightLineMovement(moveFactory));
            return new Piece("explosiveQueen.svg", Color, movementPattern);
        }

        public override Piece CreateRook()
        {
            return new Piece("explosiveRook.svg", Color, new StraightLineMovement(moveFactory));
        }
    }
}
