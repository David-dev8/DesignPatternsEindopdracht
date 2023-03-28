using Chess.Extensions;
using Chess.Models.Games;
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
            base.Make(game);

            Location destinationLocation = game.Squares.GetCurrentLocation(Destination);
            for(int i = -1; i <= 1; i++)
            {
                for(int j = -1; j <= 1; j++)
                {
                    if(i == 0 && j == 0)
                    {
                        continue;
                    }
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
}
