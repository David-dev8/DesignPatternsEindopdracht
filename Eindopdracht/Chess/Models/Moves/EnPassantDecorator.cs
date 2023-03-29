using Chess.Extensions;
using Chess.Models.Games;
using Chess.Models.Pieces;
using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Chess.Models.Moves
{
    public class EnPassantDecorator : BaseMoveDecorator
    {
        public EnPassantDecorator(Move move) : base(move)
        {
        }

        public override void Make(Game game)
        {
            base.Make(game);

            Square squareToCaptureOn = GetSquareToCaptureOn(game);
            if(squareToCaptureOn?.Piece != null)
            {
                // Capture the piece that is behind the destination
                affectedPieces.Add(new AffectedPieceData(squareToCaptureOn, null, squareToCaptureOn.Piece));
                squareToCaptureOn.Piece = null;
            }
        }

        private Square GetSquareToCaptureOn(Game game)
        {
            Square[][] grid = game.Squares;
            Location destinationLocation = grid.GetCurrentLocation(Destination);
            Location startLocation = grid.GetCurrentLocation(Start);

            int rowDifference = destinationLocation.Row - startLocation.Row;
            int columnDifference = destinationLocation.Column - startLocation.Column;
            if(Math.Abs(rowDifference) < 2 && Math.Abs(columnDifference) < 2)
            {
                return grid[startLocation.Row][destinationLocation.Column];
            }

            return null;
        }

        public override bool CanBeMade(Game game)
        {
            // We can enpassant if a piece next to us just moved up two squares
            Square squareToCaptureOn = GetSquareToCaptureOn(game);
            if(squareToCaptureOn != null)
            {
                IEnumerable<Move> movesByOtherPiece = game.GetMovesForSpecificPiece(squareToCaptureOn.Piece);
                if(movesByOtherPiece.Count() == 1)
                {
                    Move move = movesByOtherPiece.First();
                    Square[][] grid = game.Squares;
                    Location startLocation = grid.GetCurrentLocation(move.Start);
                    Location destinationLocation = grid.GetCurrentLocation(move.Destination);
                    if(Math.Abs(destinationLocation.Column - startLocation.Column) > 1 ||
                        Math.Abs(destinationLocation.Row - startLocation.Row) > 1)
                    {
                        return true;
                    }
                }
            }

            // We can also move two squares ourselves if we did not move yet
            return game.GetAmountOfMovesForSpecificPiece(Start.Piece) == 0;
        }

        protected override BaseMoveDecorator ConstructCopy(Move move)
        {
            return new EnPassantDecorator(move);
        }
    }
}
