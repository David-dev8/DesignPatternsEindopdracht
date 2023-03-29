using Chess.Models.Games;
using Chess.Models.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Models.Moves
{
    /// <summary>
    /// A factory that creates moves
    /// </summary>
    public class MoveFactory
    {
        /// <summary>
        /// Creates a move
        /// </summary>
        /// <param name="start">The start location of the move to created</param>
        /// <param name="destination">The end location of the move to be made</param>
        /// <param name="options">The extra options for the movement</param>
        /// <param name="direction">The main direction in which the move takes place</param>
        /// <returns>The move created acording to the input</returns>
        public virtual Move CreateMove(Square start, Square destination, MoveOptions[] options = null, AdvanceDirections? direction = null)
        {
            if(destination == null)
            {
                Console.WriteLine("ja");
            }

            Move move = new Move(start, destination);

            options ??= new MoveOptions[0];
            if(options.Contains(MoveOptions.CASTLING))
            {
                move = new CastleDecorator(move);
            }
            if(options.Contains(MoveOptions.ENPASSANT))
            {
                move = new EnPassantDecorator(move);
            }
            if(options.Contains(MoveOptions.PROMOTION))
            {
                move = new PromotionDecorator(move, direction.Value);
            }

            return move;
        }
    }
}
