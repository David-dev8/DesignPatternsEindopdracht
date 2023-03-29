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

        public override bool IsAffected(Piece piece)
        {
            return base.IsAffected(piece) || _moveWrappee.IsAffected(piece);
        }

        public override void Undo(Game game)
        {
           base.Undo(game);
           _moveWrappee.Undo(game);
        }

        public override Move Clone(Square start, Square destination)
        {
            return ConstructCopy(_moveWrappee.Clone(start, destination));
        }

        public override int CalculateScore()
        {
            return base.CalculateScore() + _moveWrappee.CalculateScore();
        }

        protected abstract BaseMoveDecorator ConstructCopy(Move move);
    }
}
