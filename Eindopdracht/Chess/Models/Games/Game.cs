using Chess.Base;
using Chess.Models.Moves;
using Chess.Models.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Models.Games
{
    public abstract class Game: Observable
    {
        private Stack<Move> _movesHistory = new Stack<Move>();
        protected readonly PieceFactory pieceFactory;

        public Square[][] Squares { get; set; }
        public IList<Player> Players { get; set; }
        public Queue<Player> ActivePlayers { get; set; }
        public bool HasEnded
        {
            get
            {
                return GetWinners() != null;
            }
        }
        public Player CurrentPlayer
        {
            get
            {
                return ActivePlayers.Peek();
            }
        }

        public Game(PieceFactory pieceFactory, IList<Player> players)
        {
            _pieceFactory = pieceFactory;
            Players = players;
            ActivePlayers = new Queue<Player>(Players);
            Squares = CreateBoard();
        }

        public void MakeMove(Move move)
        {
            if(IsLegal(move))
            {
                move.Make(this);
                IncreaseScore(CurrentPlayer, move);
                EliminatePlayers();
                if(!HasEnded)
                {
                    SetNextPlayer();
                }
            }
        }

        public void UndoMove()
        {
            Move lastMove = _movesHistory.Pop();
            lastMove.Undo(this);
        }

        private void SetNextPlayer()
        {
            ActivePlayers.Enqueue(ActivePlayers.Dequeue());
            OnPropertyChanged(nameof(CurrentPlayer));
        }

        public abstract IEnumerable<Player> GetWinners();
        public abstract bool IsLegal(Move move);
        protected abstract Square[][] CreateBoard();
        protected abstract void SetUpPieces();
        protected abstract void EliminatePlayers();
        protected abstract void IncreaseScore(Player player, Move move);
    }
}
