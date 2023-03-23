using Chess.Models.Games;
using Chess.Models.Moves;
using Chess.Models.Pieces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Models.Movement
{
    public class OneAdjacentMovement : MovementPattern
    {
        private static readonly int[][] _possibleSteps =
        {
            new int[] { 0, -1 }, 
            new int[] { 0, 1 }, 
            new int[] { 1, -1 }, 
            new int[] { 1, 0 }, 
            new int[] { 1, 1 }
        };

        public OneAdjacentMovement(MoveFactory moveFactory) : base(moveFactory)
        {
        }

        public override IEnumerable<Move> GetPossibleMoves(Piece piece, Square[][] grid)
        {
            IList<Move> possibleMoves = new List<Move>();
            Location currentLocation = GetCurrentLocation(grid, piece.Square);

            foreach (int[] possibleStep in _possibleSteps)
            {
                Square destination = GetDestination(grid, currentLocation, possibleStep[0], possibleStep[1]);
                if (destination != null)
                {
                    possibleMoves.Add(moveFactory.CreateMove(piece.Square, destination));
                }
            }

            return possibleMoves;
        }
    }
}
