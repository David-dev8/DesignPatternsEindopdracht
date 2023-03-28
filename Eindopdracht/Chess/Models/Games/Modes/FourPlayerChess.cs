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
    public class FourPlayerChess : Game
    {
        private const int GAP = 3;
        private const int BOARD_SIZE = 14;

        public FourPlayerChess() : base(new RegularPieceFactory(Color.FromRgb(0, 0, 0), AdvanceDirections.UP), BOARD_SIZE, new List<Player>() {
            new Player() { Color = Color.FromRgb(255, 200, 200) },
            new Player() { Color = Color.FromRgb(50, 0, 0) },
            new Player() { Color = Color.FromRgb(0, 50, 0) },
            new Player() { Color = Color.FromRgb(0, 0, 50) }
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

        protected override Square[][] CreateBoard()
        {
            var board = new Square[BOARD_SIZE][];
            for (int i = 0; i < BOARD_SIZE; i++)
            {
                var row = new Square[BOARD_SIZE];
                for (int j = 0; j < BOARD_SIZE; j++)
                {
                    if ((i >= GAP && i <= BOARD_SIZE - 1 - GAP) ||
                        (j >= GAP && j <= BOARD_SIZE - 1 - GAP))
                    {
                        row[j] = new Square();
                    }
                }
                board[i] = row;
            }
            return board;
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

            SetupPiecesForRanks(Squares.Select(row => row[0]).ToArray(), Squares.Select(row => row[1]).ToArray(), AdvanceDirections.RIGHT, Players[2].Color);
            SetupPiecesForRanks(Squares.Select(row => row[BOARD_SIZE - 1]).ToArray(), Squares.Select(row => row[BOARD_SIZE - 2]).ToArray(), AdvanceDirections.LEFT, Players[3].Color);
        }

        private void SetupPiecesForRanks(Square[] firstRank, Square[] secondRank, AdvanceDirections direction, Color color)
        {
            pieceFactory.Color = color;

            firstRank[GAP].Piece = pieceFactory.CreateRook();
            firstRank[GAP + 1].Piece = pieceFactory.CreateKnight();
            firstRank[GAP + 2].Piece = pieceFactory.CreateBishop();
            firstRank[GAP + 3].Piece = pieceFactory.CreateQueen();
            firstRank[GAP + 4].Piece = pieceFactory.CreateKing();
            firstRank[GAP + 5].Piece = pieceFactory.CreateBishop();
            firstRank[GAP + 6].Piece = pieceFactory.CreateKnight();
            firstRank[GAP + 7].Piece = pieceFactory.CreateRook();

            // Pawns for every square on the second rank
            for (int i = GAP; i < BOARD_SIZE - GAP; i++)
            {
                secondRank[i].Piece = pieceFactory.CreatePawn(direction);
            }
        }

    }
}
