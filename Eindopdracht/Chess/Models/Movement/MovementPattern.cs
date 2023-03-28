using Chess.Models.Games;
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
    /// <summary>
    /// A class that represents how pieces may move
    /// </summary>
    public abstract class MovementPattern
    {
        protected MoveFactory moveFactory;

        /// <summary>
        /// Creates a movementPatern
        /// </summary>
        /// <param name="moveFactory">The factory to use to create movement paterns</param>
        public MovementPattern(MoveFactory moveFactory)
        {
            this.moveFactory = moveFactory;
        }

        /// <summary>
        /// Returns all possible moves for a piece
        /// </summary>
        /// <param name="piece">The piece to check the moves for</param>
        /// <param name="grid">The grid in wich to check all possible movements</param>
        /// <returns>A collection with all posible moves</returns>
        public abstract IEnumerable<Move> GetPossibleMoves(Piece piece, Square[][] grid);

        protected Square GetDestination(Square[][] grid, Location currentLocation, int rowDifference, int columnDifference, AdvanceDirections? direction = null)
        {
            int[] stepDirection = direction == null ? new int[] {rowDifference, columnDifference} : GetRightOrientation(rowDifference, columnDifference, direction.Value);
            int newRow = currentLocation.Row + stepDirection[0];
            int newColumn = currentLocation.Column + stepDirection[1];
            return IsWithinBounds(grid, newRow, newColumn) ? grid[newRow][newColumn] : null;
        }

        /// <summary>
        /// Makes sure a piece with directional movement has the right orientation
        /// </summary>
        /// <param name="rowDifference">The difference to the row this piece has started in</param>
        /// <param name="columnDifference">The differnce to the column that the piece has started in</param>
        /// <param name="direction">The direction the piece can move in</param>
        /// <returns></returns>
        private int[] GetRightOrientation(int rowDifference, int columnDifference, AdvanceDirections direction)
        {
            int[] stepDirection = {rowDifference, columnDifference};
            for(int i = 0; i < (int)direction; i++)
            {
                Array.Reverse(stepDirection);
                stepDirection[1] *= -1;
            }
            return stepDirection;
        }

        /// <summary>
        /// Chekcs if performing an ability is possible
        /// </summary>
        /// <param name="abilityCheck"></param>
        /// <returns></returns>
        public virtual bool HasAbility(Func<MovementPattern, bool> abilityCheck)
        {
            return abilityCheck(this);
        }

        /// <summary>
        /// Checks if a square is within bounds of the board
        /// </summary>
        /// <param name="grid">The Grid to check for</param>
        /// <param name="row">The Y coordinate</param>
        /// <param name="column">The x Coordinate</param>
        /// <returns>A boolean value indicating wether a value is within bounds</returns>
        protected bool IsWithinBounds(Square[][] grid, int row, int column)
        {
            return row >= 0 && row < grid.Length && column >= 0 && column < grid[row].Length;
        }
    }
}
