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
    /// Contains all functionalities for four player chess
    /// </summary>
    public class FourPlayerChess : ClassicalChess
    {
        private const int GAP = 3;
        private const int BOARD_SIZE = 14;

        public FourPlayerChess() : base(null, new List<Player>() {
            new Player("Player 1", Color.FromRgb(191, 59, 67)),
            new Player("Player 2", Color.FromRgb(65, 133, 191)),
            new Player("Player 3", Color.FromRgb(78, 145, 97)),
            new Player("Player 4", Color.FromRgb(192, 149, 38))
        })
        {
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

        protected override void IncreaseScore(Player player, Move move)
        {
            // The more players there are, the higher the score
            player.Score += move.Score * ActivePlayers.Count;
        }

        protected override void SetUpPieces()
        {
            SetupPiecesForRanks(Squares[BOARD_SIZE - 1], Squares[BOARD_SIZE - 2], AdvanceDirections.UP, Players[0]);
            SetupPiecesForRanks(Squares[0], Squares[1], AdvanceDirections.DOWN, Players[2]);

            SetupPiecesForRanks(Squares.Select(row => row[0]).ToArray(), Squares.Select(row => row[1]).ToArray(), AdvanceDirections.RIGHT, Players[1]);
            SetupPiecesForRanks(Squares.Select(row => row[BOARD_SIZE - 1]).ToArray(), Squares.Select(row => row[BOARD_SIZE - 2]).ToArray(), 
                AdvanceDirections.LEFT, Players[3]);
        }

        protected override void SetupPiecesForRanks(Square[] firstRank, Square[] secondRank, AdvanceDirections direction, Player player)
        {
            PieceFactory.Color = player.Color;
            PieceFactory.Direction = direction;

            firstRank[GAP].Piece = PieceFactory.CreateRook();
            firstRank[GAP + 1].Piece = PieceFactory.CreateKnight();
            firstRank[GAP + 2].Piece = PieceFactory.CreateBishop();
            firstRank[GAP + 3].Piece = PieceFactory.CreateQueen();
            Piece king = PieceFactory.CreateKing();
            kings.Add(player, king);
            firstRank[GAP + 4].Piece = king;
            firstRank[GAP + 5].Piece = PieceFactory.CreateBishop();
            firstRank[GAP + 6].Piece = PieceFactory.CreateKnight();
            firstRank[GAP + 7].Piece = PieceFactory.CreateRook();

            SetupPawnsForRank(secondRank, direction);
        }

        protected override void SetupPawnsForRank(Square[] rank, AdvanceDirections direction)
        {
            for (int i = GAP; i < BOARD_SIZE - GAP; i++)
            {
                rank[i].Piece = PieceFactory.CreatePawn();
            }
        }
    }
}
