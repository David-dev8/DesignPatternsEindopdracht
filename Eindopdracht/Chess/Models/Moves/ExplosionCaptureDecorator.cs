using Chess.Extensions;
using Chess.Models.Games;
using Chess.Models.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Models.Moves
{
    /// <summary>
    /// The decorator for moves that explode around themselves
    /// </summary>
    public class ExplosionCaptureDecorator : BaseMoveDecorator
    {
        public ExplosionCaptureDecorator(Move move) : base(move)
        {
        }

        public override void Make(Game game)
        {
            Piece pieceToCapture = Destination.Piece;
            base.Make(game);

            if(pieceToCapture != null)
            {
                // Explode, this even includesthe piece that made the move
                Location destinationLocation = game.Squares.GetCurrentLocation(Destination);
                for(int i = -1; i <= 1; i++)
                {
                    for(int j = -1; j <= 1; j++)
                    {
                        Square neighbour = game.Squares.ElementAtOrDefault(destinationLocation.Row + i)?.ElementAtOrDefault(destinationLocation.Column + j);
                        if(neighbour?.Piece != null)
                        {
                            affectedPieces.Add(new AffectedPieceData(neighbour, null, neighbour.Piece));
                            neighbour.Piece = null;
                        }
                    }
                }
            }
        }

        protected override BaseMoveDecorator ConstructCopy(Move move)
        {
            return new ExplosionCaptureDecorator(move);
        }
    }
}
