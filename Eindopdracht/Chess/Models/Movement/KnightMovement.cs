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
using System.Windows.Controls;

namespace Chess.Models.Movement
{
    /// <summary>
    /// The patern for knight movements
    /// </summary>
    public class KnightMovement : MovementPattern
    {
        protected static readonly int[][] POSSIBLE_STEPS =
        {
            new int[] { -1, 2 }, 
            new int[] { -1, -2 }, 
            new int[] { 1, 2 }, 
            new int[] { 1, -2 },
            new int[] { -2, -1 },
            new int[] { -2, 1 },
            new int[] { 2, -1 },
            new int[] { 2, 1 },
        };

        public KnightMovement(MoveFactory moveFactory) : base(moveFactory)
        {
        }

        public override IEnumerable<Move> GetPossibleMoves(Piece piece, Square[][] grid)
        {
            IList<Move> possibleMoves = new List<Move>();
            Square square = grid.GetCurrentSquare(piece);
            Location currentLocation = grid.GetCurrentLocation(square);

            foreach(int[] step in POSSIBLE_STEPS)
            {
                Square destination = GetDestination(grid, currentLocation, step[0], step[1]);
                if(destination != null)
                {
                    possibleMoves.Add(moveFactory.CreateMove(square, destination));
                }
            }

            return possibleMoves;
        }
    }
}
