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
    public class RandomChess : Game
    {

        private const int BOARD_SIZE = 8;
        private Random _randomNumberGen = new Random();

        public RandomChess() : base(new RegularPieceFactory(Color.FromRgb(0, 0, 0), AdvanceDirections.UP), BOARD_SIZE, new List<Player>() {
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
            // TODO enum for color?
            SetupPiecesForRanks(Squares[BOARD_SIZE - 1], Squares[BOARD_SIZE - 2], AdvanceDirections.UP, Players[0].Color);
            SetupPiecesForRanks(Squares[0], Squares[1], AdvanceDirections.DOWN, Players[1].Color);
        }

        private void SetupPiecesForRanks(Square[] firstRank, Square[] secondRank, AdvanceDirections direction, Color color)
        {
            pieceFactory.Color = color;

            List<Piece> piecesToPlace = new List<Piece>() {
                pieceFactory.CreateRook(),
                pieceFactory.CreateRook(),
                pieceFactory.CreateKnight(),
                pieceFactory.CreateQueen(),
                pieceFactory.CreateKnight(),
                pieceFactory.CreateBishop(),
                pieceFactory.CreateBishop(),
            };
            piecesToPlace.AddRange(Enumerable.Range(0, 8).Select(n => pieceFactory.CreatePawn(direction)));

            firstRank[_randomNumberGen.Next(0, firstRank.Length)].Piece = pieceFactory.CreateKing();

            foreach (Square square in firstRank.Union(secondRank))
            {
                if(square.Piece == null)
                {
                    square.Piece = getAndRemoveFromArray(piecesToPlace, _randomNumberGen.Next(0, piecesToPlace.Count));
                }
            }
        }

        private Piece getAndRemoveFromArray(List<Piece> inputArray, int index)
        {
            Piece pieceToReturn = inputArray[index];
            inputArray.Remove(pieceToReturn);
            return pieceToReturn;  
        }

    }
}
