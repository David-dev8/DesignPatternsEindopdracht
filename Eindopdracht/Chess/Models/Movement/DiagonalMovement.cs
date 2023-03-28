using Chess.Extensions;
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
    /// Creates a diagonal movement
    /// </summary>
    public class DiagonalMovement : ContinuousMovement
    {
        protected static readonly int[][] POSSIBLE_STEPS =
        {
            new int[] { -1, -1 },
            new int[] { -1, 1 },
            new int[] { 1, -1 },
            new int[] { 1, 1 }
        };

        public DiagonalMovement(MoveFactory moveFactory) : base(moveFactory, POSSIBLE_STEPS)
        {
        }
    }
}
