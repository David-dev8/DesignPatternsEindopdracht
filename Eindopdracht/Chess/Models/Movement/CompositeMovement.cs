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
    public class CompositeMovement : MovementPattern
    {
        private IList<MovementPattern> _movementPatterns;

        public CompositeMovement(MoveFactory moveFactory) : base(moveFactory) 
        { 
            _movementPatterns= new List<MovementPattern>();
        }

        public void AddMovementPattern(MovementPattern movementPattern)
        {
            _movementPatterns.Add(movementPattern);
        }

        public void RemoveMovementPattern(MovementPattern movementPattern)
        {
            _movementPatterns.Remove(movementPattern);
        }

        public override IEnumerable<Move> GetPossibleMoves(Piece piece, Square[][] grid)
        {
            List<Move> possibleMoves = new List<Move>();
            foreach(MovementPattern movementPattern in _movementPatterns) 
            {
                possibleMoves.AddRange(movementPattern.GetPossibleMoves(piece, grid));
            }
            return possibleMoves;
        }
    }
}
