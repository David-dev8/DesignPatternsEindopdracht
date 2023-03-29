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
    /// <summary>
    /// Contains all functionalities for pawn storm chess
    /// </summary>
    public class PawnStormChess : Game
    {
        private const int BOARD_SIZE = 8;
        // The score for a regular player counts for 1.5 as much as normal, since he has fewer pieces
        private const double REGULAR_PLAYER_SCORE_FACTOR = 1.5;
        // Amount of pieces for the horde player that counts as 1 point
        private const double PIECES_PER_SCORE_POINT = 9;

        // Player that has the horde of pawns
        private Player _hordePlayer;
        // Player with normal setup
        private Player _regularPlayer;
        // Gets the horde, i.e. all pieces from the hordePlayer
        private IEnumerable<Piece> horde
        {
            get
            {
                return Pieces.Where(p => p.Color == _hordePlayer.Color);
            }
        }

        public PawnStormChess() : base(new RegularPieceFactory(Color.FromRgb(0, 0, 0), AdvanceDirections.UP), BOARD_SIZE, new List<Player>() {
            new Player("Player 1", Color.FromRgb(255, 255, 255)),
            new Player("Player 2", Color.FromRgb(0, 0, 0))
        })
        {
            _hordePlayer = Players[0];
            _regularPlayer = Players[1];
        }

        public override IEnumerable<Player> GetWinners()
        {
            return ActivePlayers.Count == 1 ? new List<Player>() { ActivePlayers.First() } : null;
        }

        public override bool IsLegal(Move move)
        {
            Game clone = VirtuallyMakeMove(move);
            // Only check if the regular player is putting himself in check, since only he has a king
            return
                !(CurrentPlayer == _regularPlayer && clone.InCheck(_regularPlayer)) &&
                move.CanBeMade(this) &&
                !(move.Destination.IsOccupied && move.Destination.Piece?.Color == CurrentPlayer.Color);
        }

        protected override Game ConstructCopy()
        {
            return new PawnStormChess();
        }

        protected override void EliminatePlayers()
        {
            // If hordePlayer has no pieces left, he loses, otherwise he's still in the game
            if(!horde.Any())
            {
                ActivePlayers.Remove(_hordePlayer);
            }
            // If the regular player is checkmated, the hordePlayer won
            else if(IsCheckmated(_regularPlayer))
            {
                ActivePlayers.Remove(_regularPlayer);
            }
        }

        protected override void IncreaseScore(Player player, Move move)
        {
            if(player == _hordePlayer)
            {
                // Horde player receives additional points for each pawn he has left
                player.Score += (int)(horde.Count() / PIECES_PER_SCORE_POINT);
            }
            else
            {
                player.Score += (int)(move.Score * REGULAR_PLAYER_SCORE_FACTOR);
            }
        }

        protected override void SetUpPieces()
        {
            SetupHorde(AdvanceDirections.UP, Players[0]);
            SetupPiecesForRanks(Squares[0], Squares[1], AdvanceDirections.DOWN, Players[1]);
        }

        private void SetupHorde(AdvanceDirections direction, Player player)
        {
            PieceFactory.Color = player.Color;
            for(int i = Squares.Length - 1; i >= Squares.Length - 4; i--)
            {
                foreach(Square square in Squares[i])
                {
                    square.Piece = PieceFactory.CreatePawn(direction);
                }
            }

            Squares[Squares.Length - 5][1].Piece = PieceFactory.CreatePawn(direction);
            Squares[Squares.Length - 5][2].Piece = PieceFactory.CreatePawn(direction);

            Squares[Squares.Length - 5][5].Piece = PieceFactory.CreatePawn(direction);
            Squares[Squares.Length - 5][6].Piece = PieceFactory.CreatePawn(direction);
        }
    }
}
