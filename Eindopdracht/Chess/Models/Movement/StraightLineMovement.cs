using Chess.Extensions;
using Chess.Models.Games;
using Chess.Models.Movement;
using Chess.Models.Moves;
using Chess.Models.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Chess.Models.Movement
{
    /// <summary>
    /// The movement patern for moving in straight lines like a rook
    /// </summary>
    public class StraightLineMovement : ContinuousMovement
    {
        protected static readonly int[][] POSSIBLE_STEPS =
        {
            new int[] { -1, 0 },
            new int[] { 1, 0 },
            new int[] { 0, -1 },
            new int[] { 0, 1 }
        };

        public StraightLineMovement(MoveFactory moveFactory) : base(moveFactory, POSSIBLE_STEPS)
        {
        }
    }
}
