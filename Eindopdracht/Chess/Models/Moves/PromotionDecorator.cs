using Chess.Extensions;
using Chess.Models.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Models.Moves
{
    public class PromotionDecorator : BaseMoveDecorator
    {
        public PromotionDecorator(Move move) : base(move)
        {
        }

        public override void Make(Game game)
        {
            base.Make(game);

            //Location location = game.Squares.GetCurrentLocation(Destination);


            //Square squareToCaptureOn = GetSquareToCaptureOn(game);
            //if(squareToCaptureOn?.Piece != null)
            //{
            //    // Capture the piece that is behind the destination
            //    affectedPieces.Add(new AffectedPieceData(squareToCaptureOn, null, squareToCaptureOn.Piece));
            //    squareToCaptureOn.Piece = null;
            //}
        }
    }
}
