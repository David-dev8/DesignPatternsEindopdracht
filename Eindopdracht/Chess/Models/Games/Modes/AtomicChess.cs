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
            // TODO enum for color?
            SetupPiecesForRanks(Squares[BOARD_SIZE - 1], Squares[BOARD_SIZE - 2], AdvanceDirections.UP, Players[0].Color);
            SetupPiecesForRanks(Squares[0], Squares[1], AdvanceDirections.DOWN, Players[1].Color);
        }

        private void SetupPiecesForRanks(Square[] firstRank, Square[] secondRank, AdvanceDirections direction, Color color)
        {
            pieceFactory.Color = color;

            firstRank[0].Piece = pieceFactory.CreateRook();
            firstRank[1].Piece = pieceFactory.CreateKnight();
            firstRank[2].Piece = pieceFactory.CreateBishop();
            firstRank[3].Piece = pieceFactory.CreateQueen();
            firstRank[4].Piece = pieceFactory.CreateKing();
            firstRank[5].Piece = pieceFactory.CreateBishop();
            firstRank[6].Piece = pieceFactory.CreateKnight();
            firstRank[7].Piece = pieceFactory.CreateRook(); // TODO method reference I think

            // Pawns for every square on the second rank
            foreach (Square square in secondRank)
            {
                square.Piece = pieceFactory.CreatePawn(direction);
            }
        }
    }
}
