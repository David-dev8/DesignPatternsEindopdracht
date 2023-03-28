using Chess.Models.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Models.Moves
{
    /// <summary>
    /// The decorator for the basic move
    /// </summary>
    public abstract class BaseMoveDecorator : Move
    {
        private Move _moveWrappee;

        public BaseMoveDecorator(Move move): base(move.Start, move.Destination)
        {
            _moveWrappee = move;
        }

        public override void Make(Game game)
        {
            _moveWrappee.Make(game);
        }

        public override void Undo(Game game)
        {
           base.Undo(game);
           _moveWrappee.Undo(game);
        }
    }
}
