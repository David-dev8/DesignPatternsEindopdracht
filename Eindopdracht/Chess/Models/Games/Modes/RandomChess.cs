using Chess.Models.Moves;
using Chess.Models.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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

        protected override void SetupPiecesForRanks(Square[] firstRank, Square[] secondRank, AdvanceDirections direction, Player player)
        {
            PieceFactory.Color = player.Color;

            List<Piece> piecesToPlace = new List<Piece>() {
                PieceFactory.CreateRook(),
                PieceFactory.CreateRook(),
                PieceFactory.CreateKnight(),
                PieceFactory.CreateQueen(),
                PieceFactory.CreateKnight(),
                PieceFactory.CreateBishop(),
                PieceFactory.CreateBishop(),
            };
            piecesToPlace.AddRange(Enumerable.Range(0, 8).Select(n => PieceFactory.CreatePawn(direction)));

            Piece king = PieceFactory.CreateKing();
            kings.Add(player, king);
            firstRank[_randomNumberGen.Next(0, firstRank.Length)].Piece = PieceFactory.CreateKing();

            foreach (Square square in firstRank.Union(secondRank))
            {
                if(square.Piece == null)
                {
                    square.Piece = GetAndRemoveFromArray(piecesToPlace, _randomNumberGen.Next(0, piecesToPlace.Count));
                }
            }
        }

        private Piece GetAndRemoveFromArray(List<Piece> inputArray, int index)
        {
            Piece pieceToReturn = inputArray[index];
            inputArray.Remove(pieceToReturn);
            return pieceToReturn;  
        }

    }
}
