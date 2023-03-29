using Chess.Extensions;
using Chess.Models.Games;
using Chess.Models.Movement;
using Chess.Models.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Models.Moves
{
    public class PromotionDecorator : BaseMoveDecorator
    {
        private AdvanceDirections _direction;

        public PromotionDecorator(Move move, AdvanceDirections direction) : base(move)
        {
            _direction = direction;
        }

        public override void Make(Game game)
        {
            base.Make(game);

            Location startLocation = game.Squares.GetCurrentLocation(Start);
            Location destinationLocation = game.Squares.GetCurrentLocation(Destination);
            
            if(((_direction == AdvanceDirections.UP || _direction == AdvanceDirections.DOWN) && ReachedPromotionSquare(game, destinationLocation.Row, startLocation.Row))
                || ((_direction == AdvanceDirections.LEFT || _direction == AdvanceDirections.RIGHT) && ReachedPromotionSquare(game, destinationLocation.Column, startLocation.Column)))
            {
                game.PieceFactory.Color = Destination.Piece.Color;
                Destination.Piece = game.PieceFactory.CreateQueen();
            }
        }

        protected override BaseMoveDecorator ConstructCopy(Move move)
        {
            return new PromotionDecorator(move, _direction);
        }

        /// <summary>
        /// Indicates if a piece reached a promotion square
        /// </summary>
        /// <param name="game">The current game</param>
        /// <param name="destination">The destination of a move</param>
        /// <param name="start">The start of a move</param>
        /// <returns></returns>
        private bool ReachedPromotionSquare(Game game, int destination, int start)
        {
            return destination - start != 0 && (destination == game.PromotionRank - 1 || destination == game.Squares.Length - game.PromotionRank);
        }
    }
}
