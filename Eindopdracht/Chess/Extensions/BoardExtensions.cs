using Chess.Models.Games;
using Chess.Models.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Extensions
{
    /// <summary>
    /// This class contains all the extension methods for the game board.
    /// </summary>
    public static class BoardExtensions
    {
        /// <summary>
        /// Returns the square that a given piece is curently at
        /// </summary>
        /// <param name="grid">The grid to search for the piece in</param>
        /// <param name="currentPiece">The piece to search for</param>
        /// <returns>The square the piece is currently at</returns>
        public static Square GetCurrentSquare(this Square[][] grid, Piece currentPiece)
        {
            for(int row = 0; row < grid.GetLength(0); row++)
            {
                for(int column = 0; column < grid[row].Length; column++)
                {
                    if(grid[row][column] != null)
                    {
                        Piece pieceAtSquare = grid[row][column].Piece;
                        if(currentPiece.Equals(pieceAtSquare))
                        {
                            return grid[row][column];
                        }
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Returns the coordinates that a given piece is currently at
        /// </summary>
        /// <param name="grid">The grid to search for the piece in</param>
        /// <param name="currentSquare">The piece to search for</param>
        /// <returns>The coordinates of where the piece is currently at</returns>
        public static Location GetCurrentLocation(this Square[][] grid, Square currentSquare)
        {
            for(int row = 0; row < grid.GetLength(0); row++)
            {
                for(int column = 0; column < grid[row].Length; column++)
                {
                    if(grid[row][column] != null && grid[row][column].Equals(currentSquare))
                    {
                        return new Location(row, column);
                    }
                }
            }
            return null;
        }
    }
}
