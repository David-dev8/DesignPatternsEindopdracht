using Chess.Models.Games;
using Chess.Models.Moves;
using Chess.Models.Movement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Chess.Models.Movement
{
    public abstract class ContinuousMovement : MovementPattern
    {
        protected ContinuousMovement(MoveFactory moveFactory) : base(moveFactory)
        {
        }

        protected IEnumerable<Move> GetPossibleMovesForSpecificDirection(Square[][] grid, Square start, Location currentLocation, int rowsPerStep, int columnsPerStep)
        {
            IList<Move> possibleMoves = new List<Move>();
            Square destination;
            int nextRow = currentLocation.Row + rowsPerStep;
            int nextColumn = currentLocation.Column + columnsPerStep;

            while(IsWithinBounds(grid, nextRow, nextColumn)) { 
                destination = grid[nextRow][nextColumn];
                possibleMoves.Add(moveFactory.CreateMove(start, destination));
                if(destination.IsOccupied)
                {
                    break;
                }
                nextRow += rowsPerStep;
                nextColumn += columnsPerStep;
            }

            return possibleMoves;
        }
    }
}
