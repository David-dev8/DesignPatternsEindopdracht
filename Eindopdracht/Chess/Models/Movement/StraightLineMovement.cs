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
    public class StraightLineMovement : MovementPattern
    {
        public StraightLineMovement(MoveFactory moveFactory) : base(moveFactory)
        {
        }

        public override IEnumerable<Move> GetPossibleMoves(Piece piece, Square[][] grid)
        {
            List<Move> possibleMoves = new List<Move>();
            Location currentLocation = GetCurrentLocation(grid, piece.Square);

            Location adjacent = grid[currentLocation - 1][currentLocation - 1] // TODO x en y stap
            while()
        }

        // TODO naamgeving params
        private IEnumerable<Move> GetPossibleMovesForSpecificDirection(Square[][] grid, Square start, Location currentLocation, int rowsPerStep, int columnsPerStep)
        {
            List<Move> possibleMoves = new List<Move>();
            Square destination = null;
            int nextRow = currentLocation.Row + rowsPerStep;
            int nextColumn = currentLocation.Column + columnsPerStep;

            while(nextRow > 0 && nextColumn > 0 && destination.IsOccupied())
            {
                destination = grid[nextRow][nextColumn];
                possibleMoves.Add(_moveFactory.CreateMove(start, destination));
                nextRow += rowsPerStep;
                nextColumn+= columnsPerStep;
            }
        }

        private Location GetCurrentLocation(Square[][] grid, Square currentSquare)
        {
            int amountOfRows = grid.GetLength(0);
            for (int row = 0; row < amountOfRows; row++)
            {
                int amountOfColumns = grid[row].Length;
                for (int column = 0; column < amountOfColumns; column++)
                {
                    Square square = grid[row][column];
                    if (square.Equals(currentSquare))
                    {
                        return new Location(row, column);
                    }
                }
            }
            return null;
        }
    }
}
