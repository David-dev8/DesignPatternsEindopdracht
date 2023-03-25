﻿using Chess.Models.Games;
using Chess.Models.Moves;
using Chess.Models.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Models.Movement
{
    public class SingleAdvanceMovement : MovementPattern
    {
        private static readonly MoveOptions[] _moveOptions = { MoveOptions.PROMOTION };
        private AdvanceDirections _direction;

        public SingleAdvanceMovement(MoveFactory moveFactory, AdvanceDirections direction) : base(moveFactory)
        {
            _direction = direction;
        }

        public override IEnumerable<Move> GetPossibleMoves(Piece piece, Square[][] grid)
        {
            IList<Move> possibleMoves = new List<Move>();
            Square currentSquare = piece.Square;
            Location currentLocation = GetCurrentLocation(grid, currentSquare);

            RegisterPossibleMoveForSpecificDirection(grid, currentSquare, currentLocation, 0, possibleMoves, false);
            RegisterPossibleMoveForSpecificDirection(grid, currentSquare, currentLocation, -1, possibleMoves, true);
            RegisterPossibleMoveForSpecificDirection(grid, currentSquare, currentLocation, 1, possibleMoves, true);

            return possibleMoves;
        }

        private void RegisterPossibleMoveForSpecificDirection(Square[][] grid, Square start, Location currentLocation, int columnDifference, 
            IList<Move> possibleMoves, bool shouldBeOccupied)
        {
            Square adjacentSquare = GetDestination(grid, currentLocation, -1, columnDifference);
            if (adjacentSquare != null && adjacentSquare.IsOccupied() == shouldBeOccupied)
            {
                possibleMoves.Add(moveFactory.CreateMove(start, adjacentSquare, _moveOptions));
            }
        }
    }
}
