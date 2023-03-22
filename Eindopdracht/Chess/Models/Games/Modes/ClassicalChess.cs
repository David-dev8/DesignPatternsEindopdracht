using Chess.Models.Moves;
using Chess.Models.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Models.Games.Modes
{
    public class ClassicalChess : Game
    {
        public ClassicalChess() : base(new PieceFactory(), Enumerable.Empty<Player>().ToList())
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
            var board = new Square[8][];
            for(int i = 0; i < 8; i++)
            {
                var row = new Square[8];
                for(int j = 0; j < 8; j++)
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
    }
}
