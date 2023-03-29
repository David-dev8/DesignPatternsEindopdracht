using Chess.Base;
using Chess.Extensions;
using Chess.Models.Games.Modes;
using Chess.Models.Moves;
using Chess.Models.Pieces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Models.Games
{
    /// <summary>
    /// The chess game itself
    /// </summary>
    public abstract class Game: Observable
    {
        private const int DEFAULT_PROMOTION_RANK = 8;
        private Stack<Move> _movesHistory = new Stack<Move>();
        protected IDictionary<Player, Piece> kings = new Dictionary<Player, Piece>();
        private readonly int _boardSize;

        public Square[][] Squares { get; set; }
        public IList<Player> Players { get; set; }
        public IList<Player> ActivePlayers { get; set; }
        public bool HasEnded
        {
            get
            {
                return Winners != null;
            }
        }
        public IEnumerable<Player> Winners
        {
            get
            {
                return GetWinners();
            }
        }
        public bool CanUndoMove
        {
            get
            {
                return !HasEnded && _movesHistory.Any();
            }
        }
        public PieceFactory PieceFactory { get; private set; }
        public Player CurrentPlayer
        {
            get
            {
                return ActivePlayers[0];
            }
        }
        public int PromotionRank { get; set; } = DEFAULT_PROMOTION_RANK;
        protected IEnumerable<Piece> Pieces
        {
            get
            {
                return Squares.Flatten<Square>().Where(square => square != null && square.IsOccupied).Select(square => square.Piece);
            }
        }


        /// <summary>
        /// The game constructor, constructs a game
        /// </summary>
        /// <param name="pieceFactory">The factory to use for creating the pieces</param>
        /// <param name="boardSize"The size of the board that will be used in the game</param>
        /// <param name="players">A list of players that are participating in the game</param>
        public Game(PieceFactory pieceFactory, int boardSize, IList<Player> players)
        {
            PieceFactory = pieceFactory;
            Players = players;
            ActivePlayers = new List<Player>(Players);
            _boardSize = boardSize;
            Squares = CreateBoard();
            SetUpPieces();
        }

        /// <summary>
        /// Makes a move on the game board
        /// </summary>
        /// <param name="move">The move to make</param>
        public void MakeMove(Move move)
        {
            if(!HasEnded && IsLegal(move))
            {
                move.Make(this);
                _movesHistory.Push(move);
                IncreaseScore(CurrentPlayer, move);
                EliminatePlayers();
                if(!HasEnded)
                {
                    SetNextPlayer();
                }
                else
                {
                    NotifyPropertyChanged(nameof(HasEnded));
                    NotifyPropertyChanged(nameof(Winners));
                }
            }
        }

        /// <summary>
        /// Undoes the last move made
        /// </summary>
        public void UndoMove()
        {
            if(CanUndoMove)
            {
                Move lastMove = _movesHistory.Pop();
                lastMove.Undo(this);
                SetPreviousPlayer();
            }
        }

        /// <summary>
        /// Gives the turn to the next player
        /// </summary>
        private void SetNextPlayer()
        {
            Player player = CurrentPlayer;
            ActivePlayers.Remove(player);
            ActivePlayers.Add(player);
            OnPropertyChanged(nameof(CurrentPlayer));
        }

        /// <summary>
        /// Set the turn to the privious player
        /// </summary>
        private void SetPreviousPlayer()
        {
            Player player = ActivePlayers.Last();
            ActivePlayers.Remove(player);
            ActivePlayers.Insert(0, player);
            OnPropertyChanged(nameof(CurrentPlayer));
        }

        /// <summary>
        /// Virtually make a move on a cloned board
        /// </summary>
        /// <param name="move">The move to make on the cloned board</param>
        /// <returns></returns>
        protected Game VirtuallyMakeMove(Move move)
        {
            Location start = Squares.GetCurrentLocation(move.Start);
            Location destination = Squares.GetCurrentLocation(move.Destination);
            Game clone = Clone();
            Move copyMove = move.Clone(clone.Squares[start.Row][start.Column], clone.Squares[destination.Row][destination.Column]);
            copyMove.Make(clone);
            return clone;
        }

        /// <summary>
        /// Clones a game and all game components
        /// </summary>
        /// <returns>A clone of the game object</returns>
        private Game Clone()
        {
            Game clone = ConstructCopy();
            clone.kings = kings;
            clone.Squares = Squares.Select(row => row.Select(square => square != null ? new Square() { Piece = square.Piece } : null).ToArray()).ToArray();
            return clone;
        }

        /// <summary>
        /// Calculates the ammount of possible moves for piece
        /// </summary>
        /// <param name="piece">A piece on hte game board</param>
        /// <returns>The ammount of moves this piece can make</returns>
        public int GetAmountOfMovesForSpecificPiece(Piece piece)
        {
            return GetMovesForSpecificPiece(piece).Count();
        }

        public IEnumerable<Move> GetMovesForSpecificPiece(Piece piece)
        {
            return _movesHistory.Where(move => move.IsAffected(piece)).ToList();
        }

        /// <summary>
        /// Creates the board
        /// </summary>
        /// <returns>A board as a 2 dimensional array of squares</returns>
        protected virtual Square[][] CreateBoard()
        {
            var board = new Square[_boardSize][];
            for (int i = 0; i < _boardSize; i++)
            {
                var row = new Square[_boardSize];
                for (int j = 0; j < _boardSize; j++)
                {
                    row[j] = new Square();
                }
                board[i] = row;
            }
            return board;
        }

        /// <summary>
        /// Sets all the pieces up at the desired location before the start of the game
        /// </summary>
        protected virtual void SetUpPieces()
        {
            SetupPiecesForRanks(Squares[_boardSize - 1], Squares[_boardSize - 2], AdvanceDirections.UP, Players[0]);
            SetupPiecesForRanks(Squares[0], Squares[1], AdvanceDirections.DOWN, Players[1]);
        }

        /// <summary>
        /// Sets all the pieces up for the first and second rank.
        /// </summary>
        /// <param name="firstRank">The first rank to place pieces</param>
        /// <param name="secondRank">The second rank to place pieces</param>
        /// <param name="direction">The direction of the pieces to move</param>
        /// <param name="player">The current player</param>
        protected virtual void SetupPiecesForRanks(Square[] firstRank, Square[] secondRank, AdvanceDirections direction, Player player)
        {
            PieceFactory.Color = player.Color;

            firstRank[0].Piece = PieceFactory.CreateRook();
            firstRank[1].Piece = PieceFactory.CreateKnight();
            firstRank[2].Piece = PieceFactory.CreateBishop();
            firstRank[3].Piece = PieceFactory.CreateQueen();
            Piece king = PieceFactory.CreateKing();
            kings.Add(player, king);
            firstRank[4].Piece = king;
            firstRank[5].Piece = PieceFactory.CreateBishop();
            firstRank[6].Piece = PieceFactory.CreateKnight();
            firstRank[7].Piece = PieceFactory.CreateRook();

            SetupPawnsForRank(secondRank, direction);
        }

        public bool InCheck(Player player)
        {
            // Can any of the opponents pieces capture the king of the player?
            return Pieces.Where(piece => !piece.Color.Equals(player.Color)).Any(piece => {
                IEnumerable<Move> Moves = piece.Movement.GetPossibleMoves(piece, Squares);
                return Moves.Any(move => move.Destination.Piece == kings[player]);
            });
        }

        public bool IsCheckmated(Player player)
        {
            if(InCheck(player))
            {
                // Can the player make any move to get out of the check?
                // If this is not the case, the player is checkmated
                return !Pieces.Where(piece => piece?.Color == player.Color).Any(piece =>
                {
                    IEnumerable<Move> Moves = piece.Movement.GetPossibleMoves(piece, Squares).Where(move => IsLegal(move) &&
                                (!move.Destination.IsOccupied || move.Start.Piece.Color != move.Destination.Piece.Color));
                    return Moves.Any(move =>
                    {
                        Game game = VirtuallyMakeMove(move);
                        return !game.InCheck(player) && game.Squares.GetCurrentSquare(kings[player]) != null;
                    });
                });
            }
            return false;
        }

        /// <summary>
        /// Sets all the pawns up for the given rank
        /// </summary>
        /// <param name="rank">The rank to place pawns</param>
        /// <param name="direction">The direction of the pieces to move</param>
        protected virtual void SetupPawnsForRank(Square[] rank, AdvanceDirections direction)
        {
            foreach (Square square in rank)
            {
                square.Piece = PieceFactory.CreatePawn(direction);
            }
        }

        /// <summary>
        /// Gets the winner for the game
        /// </summary>
        /// <returns>The players that have won</returns>
        public abstract IEnumerable<Player> GetWinners();

        /// <summary>
        /// Checks if a move is possible acording to the rules
        /// </summary>
        /// <param name="move">The move to check</param>
        /// <returns>A boolean value indicating wether the move is posible</returns>
        public abstract bool IsLegal(Move move);

        /// <summary>
        /// Removes a player from a game
        /// </summary>
        protected abstract void EliminatePlayers();

        /// <summary>
        /// Increase the score of a player
        /// </summary>
        /// <param name="player">The player to increase the score for</param>
        /// <param name="move">The move to score for</param>
        protected abstract void IncreaseScore(Player player, Move move);

        /// <summary>
        /// Constructs a copy of the current game
        /// </summary>
        /// <returns>A copy of the current game</returns>
        protected abstract Game ConstructCopy();
    }
}
