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
    public class OneAdjacentMovement : MovementPattern
    {
        public OneAdjacentMovement(MoveFactory moveFactory) : base(moveFactory)
        {
        }

        public override IEnumerable<Move> GetPossibleMoves(Piece piece, Square[][] grid)
        {
            throw new NotImplementedException();
        }

        //private Move GetPossibleMoveForSpecificDirection(Square[][] grid, Square start, Location currentLocation, int rowDifference, int columnDifference)
        //{
        //    Square adjacentSquare = grid[currentLocation.Row + rowDifference][currentLocation.Column + columnDifference];
        //    if (adjacentSquare.IsOccupied())
        //    {
        //        return moveFactory.CreateMove(start, adjacentSquare);
        //    }
        //    return null;
        //}
    }
}
