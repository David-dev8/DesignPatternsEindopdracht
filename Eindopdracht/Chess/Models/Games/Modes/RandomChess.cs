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
    /// <summary>
    /// Contains all functionalities for random chess
    /// </summary>
    public class RandomChess : ClassicalChess
    {
        private const int MINIMUM_SCORE_PER_MOVE = 10;
        private const int MAXIMUM_SCORE_PER_MOVE = 20;
        private Random _random = new Random();

        protected override void IncreaseScore(Player player, Move move)
        {
            player.Score += _random.Next(MINIMUM_SCORE_PER_MOVE, MAXIMUM_SCORE_PER_MOVE + 1);
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
            piecesToPlace.AddRange(Enumerable.Range(0, 8).Select(n => PieceFactory.CreatePawn()));

            Piece king = PieceFactory.CreateKing();
            kings.Add(player, king);
            firstRank[_random.Next(0, firstRank.Length)].Piece = king;

            foreach (Square square in firstRank.Union(secondRank))
            {
                square.Piece ??= GetAndRemoveFromArray(piecesToPlace, _random.Next(0, piecesToPlace.Count));
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
