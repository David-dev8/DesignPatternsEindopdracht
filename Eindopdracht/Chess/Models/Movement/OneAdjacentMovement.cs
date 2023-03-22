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
        public OneAdjacentMovement(MoveFactory moveFactory) : base(moveFactory)
        {
        }

        public override IEnumerable<Move> GetPossibleMoves(Piece piece, Square[][] grid)
        {
            IList<Move> possibleMoves = new List<Move>();
            Location currentLocation = GetCurrentLocation(grid, piece.Square);
            for(int rowDifference = 0; rowDifference <= 1; rowDifference++)
            {
                for(int columnDifference = -1; columnDifference <= 1; columnDifference++)
                {
                    if(rowDifference != 0 && columnDifference != 0)
                    {
                        Square destination = GetDestination(grid, currentLocation, rowDifference, columnDifference);
                        if (destination != null)
                        {
                            possibleMoves.Add(moveFactory.CreateMove(piece.Square, destination));
                        }
                    }
                }
            }
            return possibleMoves;
        }
    }
}
