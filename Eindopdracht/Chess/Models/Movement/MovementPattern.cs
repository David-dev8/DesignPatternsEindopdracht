using Chess.Models.Games;
using Chess.Models.Moves;
using Chess.Models.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Models.Movement
{
    public abstract class MovementPattern
    {
        protected MoveFactory _moveFactory;

        public MovementPattern(MoveFactory moveFactory)
        {
            _moveFactory = moveFactory;
        }

        public abstract IEnumerable<Move> GetPossibleMoves(Piece piece, Square[][] grid);
    }
}
