using Chess.Models.Movement;
using Chess.Models.Moves;
using Chess.Models.Pieces;
using Chess.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Chess.Models.Games.Modes
{
    /// <summary>
    /// Contains all functionalities for classical chess
    /// </summary>
    public class ClassicalChess : Game
    {
        private const int GUARENTEED_SCORE_PER_MOVE = 2;
        private const int BOARD_SIZE = 8;

        public ClassicalChess(PieceFactory pieceFactory = null, IList<Player> players = null) : base(
            pieceFactory ?? new RegularPieceFactory(Color.FromRgb(0, 0, 0), AdvanceDirections.UP), BOARD_SIZE, 
            players ?? new List<Player>() { 
                new Player("Player 1", Color.FromRgb(255, 255, 255)),
                new Player("Player 2", Color.FromRgb(0, 0, 0)) 
            })
        {
        }

        public override IEnumerable<Player> GetWinners()
        {
            // Is there only one player left?
            if(ActivePlayers.Count == 1)
            {
                // This means someone has been checkmated and there is a winner
                return new List<Player>() { ActivePlayers[0] };
            }
            // Is there a draw? This occurs when the current player has no legal moves
            else if(!HasLegalMoves(CurrentPlayer))
            {
                // Nobody won, because there is a draw
                return Enumerable.Empty<Player>();
            }
            // The game goes on
            return null;
        }

        private bool HasLegalMoves(Player player)
        {
            return Pieces.Where(piece => piece?.Color == player.Color).Any(piece =>
            {
                return piece.Movement.GetPossibleMoves(piece, Squares).Where(move => IsLegal(move)).Any();
            });
        }

        public override bool IsLegal(Move move)
        {
            if(move.Destination.Piece?.Color == CurrentPlayer.Color || !move.CanBeMade(this))
            {
                // Not allowed to capture your own piece
                return false;
            }

            Game clone = VirtuallyMakeMove(move);
            // Is the king of the player whose turn it is in check? If so, the move was not legal
            if(clone.InCheck(CurrentPlayer))
            {
                return false;
            }

            return true;
        }

        protected override Game ConstructCopy()
        {
            return new ClassicalChess();
        }

        protected override void EliminatePlayers()
        {
            // Eliminate each player that is in check and whose king has no legal moves, i.e. is checkmated
            ActivePlayers = ActivePlayers.Where(player => !IsCheckmated(player)).ToList();
        }

        protected override void IncreaseScore(Player player, Move move)
        {
            player.Score += GUARENTEED_SCORE_PER_MOVE + move.Score;
        }
    }
}
