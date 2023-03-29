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

            Location destinationLocation = game.Squares.GetCurrentLocation(Destination);
            
            if(ReachedPromotionSquare(game, destinationLocation, _direction))
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
        private bool ReachedPromotionSquare(Game game, Location destination, AdvanceDirections direction)
        {
            return direction switch
            {
                AdvanceDirections.UP => destination.Row == game.Squares.Length - game.PromotionRank,
                AdvanceDirections.DOWN => destination.Row == game.PromotionRank - 1,
                AdvanceDirections.LEFT => destination.Column == game.Squares.Length - game.PromotionRank,
                AdvanceDirections.RIGHT => destination.Column == game.PromotionRank - 1,
                _ => false
            };
        }
    }
}
