﻿using Chess.Models.Games;
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
    public abstract class MovementPattern
    {
        protected MoveFactory moveFactory;

        public MovementPattern(MoveFactory moveFactory)
        {
            this.moveFactory = moveFactory;
        }

        public abstract IEnumerable<Move> GetPossibleMoves(Piece piece, Square[][] grid);

        protected Location GetCurrentLocation(Square[][] grid, Square currentSquare)
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

        protected Square GetDestination(Square[][] grid, Location currentLocation, int rowDifference, int columnDifference)
        {
            int newRow = currentLocation.Row + rowDifference;
            int newColumn = currentLocation.Column + columnDifference;
            return IsWithinBounds(grid, newRow, newColumn) ?
                grid[currentLocation.Row + rowDifference][currentLocation.Column + columnDifference] : null;
        }

        protected bool IsWithinBounds(Square[][] grid, int row, int column)
        {
            return row >= 0 && row < grid.Length && column >= 0 && column < grid[row].Length;
        }
    }
}
