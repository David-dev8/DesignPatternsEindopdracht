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
    public class ClassicalChess : Game
    {
        private const int GUARENTEED_SCORE_PER_MOVE = 20;
        private const int BOARD_SIZE = 8;

        public ClassicalChess() : base(new RegularPieceFactory(Color.FromRgb(0, 0, 0), AdvanceDirections.UP), BOARD_SIZE, new List<Player>() { 
            new Player() { Color = Color.FromRgb(255, 0, 0) },
            new Player() { Color = Color.FromRgb(0, 0, 0) } 
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
            // Is there a draw? This occurs when a player has no legal moves
            else if(ActivePlayers.Any(player =>
            {
                return !Pieces.Where(piece => piece?.Color == player.Color).Any(piece =>
                {
                    return piece.Movement.GetPossibleMoves(piece, Squares).Any();
                });
            }))
            {
                // Nobody won, because there is a draw
                return Enumerable.Empty<Player>();
            }
            // The game goes on
            return null;
        }

        public override bool IsLegal(Move move)
        {
            if(move.Destination.Piece?.Color == CurrentPlayer.Color)
            {
                // Not allowed to capture your own piece
                return false;
            }

            ClassicalChess clone = (ClassicalChess)VirtuallyMakeMove(move);
            // Is the king of the player whose turn it is in check? If so, the move was not legal
            if(clone.InCheck(CurrentPlayer))
            {
                return false;
            }

            return true;
        }

        private bool InCheck(Player player)
        {
            // Can any of the opponents pieces capture the king of the player?
            return Pieces.Where(piece => piece.Color != player.Color).Any(piece => {
                IEnumerable<Move> Moves = piece.Movement.GetPossibleMoves(piece, Squares);
                return Moves.Any(move => move.Destination.Piece == kings[player]);
            });
        }

        protected override Game ConstructCopy()
        {
            ClassicalChess copy = new ClassicalChess();
            copy.kings = kings;
            return copy;
        }

        protected override void EliminatePlayers()
        {
            // Eliminate each player that is in check and whose king has no legal moves
            for(int i = Players.Count - 1; i >= 0; i--)
            {
                Player player = Players[i];
                if(InCheck(player))
                {
                    // Can the player make any move to get out of the check?
                    // If this is not the case, the player is checkmated
                    if(!Pieces.Where(piece => piece?.Color == player.Color).Any(piece =>
                    {
                        IEnumerable<Move> Moves = piece.Movement.GetPossibleMoves(piece, Squares);
                        return Moves.Any(move => {
                            ClassicalChess game = (ClassicalChess)VirtuallyMakeMove(move);
                            return !game.InCheck(player);
                        });
                    }))
                    {
                        ActivePlayers.Remove(player);
                    }
                }
            }
        }

        protected override void IncreaseScore(Player player, Move move)
        {
            player.Score += GUARENTEED_SCORE_PER_MOVE + move.Score;
        }
    }
}
