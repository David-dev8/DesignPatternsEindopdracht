using Chess.Models.Games;
using Chess.Models.Moves;
using Chess.Models.Movement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Models.Movement
{
    public abstract class ContinuousMovement : MovementPattern
    {
        protected ContinuousMovement(MoveFactory moveFactory) : base(moveFactory)
        {
        }

        protected IEnumerable<Move> GetPossibleMovesForSpecificDirection(Square[][] grid, Square start, Location currentLocation, int rowsPerStep, int columnsPerStep)
        {
            List<Move> possibleMoves = new List<Move>();
            Square destination = null;
            int nextRow = currentLocation.Row + rowsPerStep;
            int nextColumn = currentLocation.Column + columnsPerStep;

            while (nextRow > 0 && nextColumn > 0 && destination.IsOccupied())
            {
                destination = grid[nextRow][nextColumn];
                possibleMoves.Add(moveFactory.CreateMove(start, destination));
                nextRow += rowsPerStep;
                nextColumn += columnsPerStep;
            }
            return possibleMoves;
        }
    }
}
