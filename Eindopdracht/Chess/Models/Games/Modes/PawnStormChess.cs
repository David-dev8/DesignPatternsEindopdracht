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

        public PawnStormChess() : base(new RegularPieceFactory(Color.FromRgb(0, 0, 0), AdvanceDirections.UP), BOARD_SIZE, new List<Player>() {
            new Player() { Color = Color.FromRgb(255, 255, 255) },
            new Player() { Color = Color.FromRgb(0, 0, 0) }
        })
        {
        }

        public override IEnumerable<Player> GetWinners()
        {
            return Enumerable.Empty<Player>();
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
