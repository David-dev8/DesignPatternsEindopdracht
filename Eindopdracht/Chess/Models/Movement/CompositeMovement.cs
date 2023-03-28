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
    /// <summary>
    /// A compsit movement that can contain multiple movementspaterns
    /// </summary>
    public class CompositeMovement : MovementPattern
    {
        private IList<MovementPattern> _movementPatterns;

        /// <summary>
        /// Creates a Composit movement
        /// </summary>
        /// <param name="moveFactory">The factory to use for the moves</param>
        public CompositeMovement(MoveFactory moveFactory) : base(moveFactory) 
        { 
            _movementPatterns= new List<MovementPattern>();
        }

        /// <summary>
        /// Add a movementpetern to the composit
        /// </summary>
        /// <param name="movementPattern">The movement pattern to add</param>
        public void AddMovementPattern(MovementPattern movementPattern)
        {
            _movementPatterns.Add(movementPattern);
        }

        /// <summary>
        /// Removes a movement patern from the composit
        /// </summary>
        /// <param name="movementPattern">The movement patern to remove</param>
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

        public override bool HasAbility(Func<MovementPattern, bool> abilityCheck)
        {
            return _movementPatterns.Any(movement => movement.HasAbility(abilityCheck));
        }
    }
}
