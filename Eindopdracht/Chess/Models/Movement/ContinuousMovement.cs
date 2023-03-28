using Chess.Models.Games;
using Chess.Models.Moves;
using Chess.Models.Movement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using Chess.Extensions;
using Chess.Models.Pieces;

namespace Chess.Models.Movement
{
    /// <summary>
    /// The patern for a straight movement
    /// </summary>
    public abstract class ContinuousMovement : MovementPattern
    {
        private IEnumerable<int[]> _possibleSteps;

        /// <summary>
        /// Creates a a patern for a straight movement 
        /// </summary>
        /// <param name="moveFactory">The factory to use to create this movement</param>
        /// <param name="possibleSteps">The Steps it can possibly take</param>
        protected ContinuousMovement(MoveFactory moveFactory, IEnumerable<int[]> possibleSteps) : base(moveFactory)
        {
            _possibleSteps = possibleSteps;
        }

        /// <summary>
        /// Gets all posible moves facing a specific cardinal direction
        /// </summary>
        /// <param name="grid">The board to check for moves on</param>
        /// <param name="start">The staring possition of th move</param>
        /// <param name="currentLocation">The current location of the piece to move</param>
        /// <param name="rowsPerStep">The ammount of rows it maay move</param>
        /// <param name="columnsPerStep">The ammount of collumns it may move</param>
        /// <returns>A list of all possible movements facing a cardinal direction</returns>
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

        public override IEnumerable<Move> GetPossibleMoves(Piece piece, Square[][] grid)
        {
            List<Move> possibleMoves = new List<Move>();
            Square square = grid.GetCurrentSquare(piece);
            Location currentLocation = grid.GetCurrentLocation(square);

            foreach(int[] possibleStep in _possibleSteps)
            {
                possibleMoves.AddRange(GetPossibleMovesForSpecificDirection(grid, square, currentLocation, possibleStep[0], possibleStep[1]));
            }

            return possibleMoves;
        }
    }
}
