﻿using Chess.Extensions;
using Chess.Models.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Models.Moves
{
    public class CastleDecorator : BaseMoveDecorator
    {
        public CastleDecorator(Move move) : base(move)
        {
        }

        public override void Make(Game game)
        {
            base.Make(game);

            // Swap the other piece from being to one side of the current piece to the other side
            Square start = GetSquareNextToDestination(game.Squares, 1, true);
            Square destination = GetSquareNextToDestination(game.Squares, -1);
            if(start != null && destination != null)
            {
                affectedPieces.Add(new AffectedPieceData(start, destination, start.Piece));
                destination.Piece = start.Piece;
                start.Piece = null;
            }
        }

        /// <summary>
        /// Gets the next square to the destination
        /// </summary>
        /// <param name="grid">The grid to perform it on</param>
        /// <param name="sideDirection">The direction to move</param>
        /// <param name="shouldLookTwice">Should look for a second time</param>
        /// <returns></returns>
        private Square GetSquareNextToDestination(Square[][] grid, int sideDirection, bool shouldLookTwice = false)
        {
            Location destinationLocation = grid.GetCurrentLocation(Destination);
            Location startLocation = grid.GetCurrentLocation(Start);
            int rowDirection = Math.Sign(destinationLocation.Row - startLocation.Row);
            int columnDirection = Math.Sign(destinationLocation.Column - startLocation.Column);

            Square square = grid.ElementAtOrDefault(destinationLocation.Row + sideDirection * rowDirection)?.ElementAtOrDefault(destinationLocation.Column + sideDirection * columnDirection);
            if(shouldLookTwice && square.Piece == null)
            {
                square = grid.ElementAtOrDefault(destinationLocation.Row + sideDirection * rowDirection * 2)?.ElementAtOrDefault(destinationLocation.Column + sideDirection * columnDirection * 2);
            }
            return square;
        }

        public override bool CanBeMade(Game game)
        {
            // Check if one of the castling pieces has already moved, because then castling is not allowed
            return game.GetAmountOfMovesForSpecificPiece(Start.Piece) == 0 &&
                game.GetAmountOfMovesForSpecificPiece(GetSquareNextToDestination(game.Squares, 1, true).Piece) == 0;
        }

        protected override BaseMoveDecorator ConstructCopy(Move move)
        {
            return new CastleDecorator(move);
        }
    }
}
