using Chess.Extensions;
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
    /// <summary>
    /// The patern for adjacent movements like a kings movement
    /// </summary>
    public class OneAdjacentMovement : MovementPattern
    {
        protected static readonly int[][] POSSIBLE_STEPS =
        {
            new int[] { 0, -1 }, 
            new int[] { 0, 1 }, 
            new int[] { 1, -1 }, 
            new int[] { 1, 0 }, 
            new int[] { 1, 1 },
            new int[] { -1, -1 },
            new int[] { -1, 0 },
            new int[] { -1, 1 }
        };

        public OneAdjacentMovement(MoveFactory moveFactory) : base(moveFactory)
        {
        }

        public override IEnumerable<Move> GetPossibleMoves(Piece piece, Square[][] grid)
        {
            IList<Move> possibleMoves = new List<Move>();
            Square square = grid.GetCurrentSquare(piece);
            Location currentLocation = grid.GetCurrentLocation(square);

            foreach(int[] possibleStep in POSSIBLE_STEPS)
            {
                Square destination = GetDestination(grid, currentLocation, possibleStep[0], possibleStep[1]);
                if(destination != null)
                {
                    possibleMoves.Add(moveFactory.CreateMove(square, destination));
                }
            }

            return possibleMoves;
        }
    }
}
