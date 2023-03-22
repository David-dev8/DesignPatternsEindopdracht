using Chess.Models.Movement;
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
    public class ClassicalChess : Game
    {
        private const int BOARD_SIZE = 8;

        public ClassicalChess() : base(new RegularPieceFactory(Color.FromRgb(0, 0, 0)), new List<Player>() { new Player() { Color = Color.FromRgb(0, 0, 0) } })
        {
        }

        public override IEnumerable<Player> GetWinners()
        {
            throw new NotImplementedException();
        }

        public override bool IsLegal(Move move)
        {
            throw new NotImplementedException();
        }

        protected override Square[][] CreateBoard()
        {
            var board = new Square[BOARD_SIZE][];
            for(int i = 0; i < BOARD_SIZE; i++)
            {
                var row = new Square[BOARD_SIZE];
                for(int j = 0; j < BOARD_SIZE; j++)
                {
                    row[j] = new Square();
                }
                board[i] = row;
            }
            return board;
        }

        protected override void EliminatePlayers()
        {
            throw new NotImplementedException();
        }

        protected override void IncreaseScore(Player player, Move move)
        {
            throw new NotImplementedException();
        }

        protected override void SetUpPieces()
        {
            // TODO enum for color?
            SetupPiecesForRanks(Squares[0], Squares[1], Color.FromRgb(255, 255, 255));
            SetupPiecesForRanks(Squares[BOARD_SIZE], Squares[BOARD_SIZE - 1], Color.FromRgb(0, 0, 0));
        }

        private void SetupPiecesForRanks(Square[] firstRank, Square[] secondRank, Color color)
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
            foreach(Square square in secondRank)
            {
                square.Piece = pieceFactory.CreatePawn();
            }
        }
    }
}
