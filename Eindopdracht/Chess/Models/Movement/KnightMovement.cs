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
    public class KnightMovement : MovementPattern
    {
        public KnightMovement(MoveFactory moveFactory) : base(moveFactory)
        {
        }

        public override IEnumerable<Move> GetPossibleMoves(Piece piece, Square[][] grid)
        {
            IList<Move> possibleMoves = new List<Move>();
            Location currentLocation = GetCurrentLocation(grid, piece.Square);
            int[][] possibleSteps = {new int[] {-1, 2 }, new int[] {-1, -2 }, new int[] {1, 2 }, new int[] {1, -2 }}; // TODO static en aanvullen

            foreach(int[] step in possibleSteps) 
            {
                Square destination = GetDestination(grid, currentLocation, step[0], step[1]);
                if (destination != null)
                {
                    possibleMoves.Add(moveFactory.CreateMove(piece.Square, destination));
                }
            }
            return possibleMoves;
        }
    }
}
