using Chess.Extensions;
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
            new Player() { Color = Color.FromRgb(255, 255, 255) },
            new Player() { Color = Color.FromRgb(0, 0, 0) }
        })
        {
        }

        public override IEnumerable<Player> GetWinners()
        {
            // Only one king means we have a winner
            return kings.Count == 1 ? new List<Player>() { kings.First().Key } : null;
        }

        public override bool IsLegal(Move move)
        {
            if(!move.CanBeMade(this))
            {
                return false;
            }

            AtomicChess game = VirtuallyMakeMove(move) as AtomicChess;
            // Almost anything is legal in the atomic mode, besides exploding your own king
            return game.HasKingLeft(CurrentPlayer) && 
                !(move.Destination.IsOccupied && move.Destination.Piece?.Color == CurrentPlayer.Color);
        }

        protected override Game ConstructCopy()
        {
            return new AtomicChess();
        }

        protected override void EliminatePlayers()
        {
            // Players with no king get eliminated
            ActivePlayers = ActivePlayers.Where(player => HasKingLeft(player)).ToList();
        }

        private bool HasKingLeft(Player player)
        {
            return Squares.GetCurrentSquare(kings[player]) != null;
        }

        protected override void IncreaseScore(Player player, Move move)
        {

        }
    }
}
