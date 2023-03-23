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
    public class DiagonalMovement : ContinuousMovement
    {
        private static readonly int[][] _possibleSteps =
        {
            new int[] { -1, -1 },
            new int[] { -1, 1 },
            new int[] { 1, -1 },
            new int[] { 1, 1 }
        };

        public DiagonalMovement(MoveFactory moveFactory) : base(moveFactory)
        {
        }

        public override IEnumerable<Move> GetPossibleMoves(Piece piece, Square[][] grid)
        {
            List<Move> possibleMoves = new List<Move>();
            Location currentLocation = GetCurrentLocation(grid, piece.Square);

            foreach (int[] possibleStep in _possibleSteps)
            {
                possibleMoves.AddRange(GetPossibleMovesForSpecificDirection(grid, piece.Square, currentLocation, possibleStep[0], possibleStep[1]));
            }

            return possibleMoves;
        }
    }
}
