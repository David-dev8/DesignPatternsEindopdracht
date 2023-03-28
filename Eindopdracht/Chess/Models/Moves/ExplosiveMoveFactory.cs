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
    /// A factory to create movements that end with explosions
    /// </summary>
    public class ExplosiveMoveFactory: MoveFactory
    {
        public override Move CreateMove(Square start, Square destination, MoveOptions[] options = null, AdvanceDirections? direction = null)
        {
            Move move = base.CreateMove(start, destination, options, direction);
            move = new ExplosionCaptureDecorator(move);
            return move;
        }
    }
}
