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
    public class AtomicChess: Game
    {
        private const int BOARD_SIZE = 8;

        public AtomicChess() : base(new AtomicPieceFactory(Color.FromRgb(0, 0, 0), AdvanceDirections.UP), BOARD_SIZE, new List<Player>() {
            new Player() { Color = Color.FromRgb(255, 200, 200) },
            new Player() { Color = Color.FromRgb(50, 0, 0) }
        })
        {
        }

        public override IEnumerable<Player> GetWinners()
        {
            return null;
        }

        public override bool IsLegal(Move move)
        {
            return true;
        }

        protected override Game ConstructCopy()
        {
            throw new NotImplementedException();
        }

        protected override void EliminatePlayers()
        {



        }

        protected override void IncreaseScore(Player player, Move move)
        {

        }
    }
}
