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
        // Since this is atomic and pieces explode, moves will be likely to yield a high score
        // Therefore introduce a setback on the score
        private const int SCORE_SETBACK = 2;
        private const int BOARD_SIZE = 8;

        public AtomicChess() : base(new AtomicPieceFactory(Color.FromRgb(255, 255, 255), AdvanceDirections.UP), BOARD_SIZE, new List<Player>() {
            new Player("Player 1", Color.FromRgb(255, 255, 255)), 
            new Player("Player 2", Color.FromRgb(0, 0, 0))
        })
        {
        }

        public override IEnumerable<Player> GetWinners()
        {
            // Only one player means we have a winner (the other king has exploded)
            return ActivePlayers.Count == 1 ? new List<Player>() { ActivePlayers.First() } : null;
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
            player.Score += Math.Max(0, move.Score - SCORE_SETBACK);
        }
    }
}
