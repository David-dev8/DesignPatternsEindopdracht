using Chess.Models.Moves;
using Chess.Models.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Chess.Models.Games.Modes
{
    public class CorruptedChess: ClassicalChess
    {
        private const int MINIMUM_SCORE_UNCERTAINTY = -5;
        private const int MAXIMUM_SCORE_UNCERTAINTY = 5;
        private Random _random = new Random();

        public CorruptedChess() : base(new CorruptedPieceFactory(Color.FromRgb(0, 0, 0), AdvanceDirections.UP))
        {
        }

        protected override Game ConstructCopy()
        {
            return new CorruptedChess();
        }

        protected override void IncreaseScore(Player player, Move move)
        {
            player.Score = Math.Max(0, player.Score + _random.Next(MINIMUM_SCORE_UNCERTAINTY, MAXIMUM_SCORE_UNCERTAINTY));
        }
    }
}
