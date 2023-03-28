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
    /// This is a factory that creates chess pieces
    /// </summary>
    public abstract class PieceFactory
    {
        protected MoveFactory moveFactory;

        public Color Color { get; set; }
        public AdvanceDirections Direction { get; set; }

        /// <summary>
        /// Creates a chess piece factory
        /// </summary>
        /// <param name="color">The color of the pieces to create</param>
        /// <param name="direction">The direction the created peices consider forward</param>
        /// <param name="moveFactory">?</param>
        public PieceFactory(Color color, AdvanceDirections direction, MoveFactory moveFactory) 
        { 
            Color = color;
            this.moveFactory = moveFactory;
        }

        /// <summary>
        /// Creates a King piece
        /// </summary>
        /// <returns>A piece that acts and looks like king</returns>
        public abstract Piece CreateKing();
        /// <summary>
        /// Creates a queen piece
        /// </summary>
        /// <returns>A piece that acts and looks like queen</returns>
        public abstract Piece CreateQueen();
        /// <summary>
        /// Creates a pawn piece
        /// </summary>
        /// <param name="direction">The direction the pawn will move towards</param>
        /// <returns>A piece that looks acts and looks like a pawn</returns>
        public abstract Piece CreatePawn(AdvanceDirections direction);
        /// <summary>
        /// Creates a rook piece
        /// </summary>
        /// <returns>A piece that acts and looks like rook</returns>
        public abstract Piece CreateRook();
        /// <summary>
        /// Creates a knight piece
        /// </summary>
        /// <returns>A piece that acts and looks like knight</returns>
        public abstract Piece CreateKnight();
        /// <summary>
        /// Creates a bishop piece
        /// </summary>
        /// <returns>A piece that acts and looks like a bishop</returns>
        public abstract Piece CreateBishop();
    }
}
