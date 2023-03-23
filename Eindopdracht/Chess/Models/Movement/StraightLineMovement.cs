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
    public class StraightLineMovement : ContinuousMovement
    {
        private static readonly int[][] _possibleSteps =
        {
            new int[] { -1, 0 },
            new int[] { 1, 0 },
            new int[] { 0, -1 },
            new int[] { 0, 1 }
        };

        public StraightLineMovement(MoveFactory moveFactory) : base(moveFactory)
        {
        }

        // TODO deze methode naar boven halen voor zo goed als elke movement
        public override IEnumerable<Move> GetPossibleMoves(Piece piece, Square[][] grid)
        {
            List<Move> possibleMoves = new List<Move>();
            Location currentLocation = GetCurrentLocation(grid, piece.Square);

            foreach (int[] possibleStep in _possibleSteps)
            {
                possibleMoves.AddRange(GetPossibleMovesForSpecificDirection(grid, piece.Square, currentLocation, 
                    possibleStep[0], possibleStep[1]));
            }
            
            return possibleMoves;
        }
    }
}
