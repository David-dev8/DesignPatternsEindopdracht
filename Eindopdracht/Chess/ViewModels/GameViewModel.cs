using Chess.Base;
using Chess.Models.Games;
using Chess.Models.Moves;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Chess.ViewModels
{
    /// <summary>
    /// This is the viewmodel for the game, this is the page where the game is played
    /// </summary>
    public class GameViewModel : BaseViewModel
    {
        private Square _selectedSquare;
        private IEnumerable<Move> _activeMoves;

        public Game Game { get; set; }
        public ICommand UndoMoveCommand { get; set; }
        public ICommand QuitCommand { get; set; }
        public Square SelectedSquare
        {
            get
            {
                return _selectedSquare;
            }
            set
            {
                _selectedSquare = value;
                NotifyPropertyChanged();
                DetermineActiveMoves();
            }
        }
        public IEnumerable<Move> ActiveMoves
        {
            get
            {
                return _activeMoves;
            }
            set
            {
                _activeMoves = value;
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Creates the game viewmodel
        /// </summary>
        /// <param name="game">The gamemode that is to be played</param>
        /// <param name="navigationService">The navigationservice to navigate with</param>
        public GameViewModel(Game game, NavigationService navigationService) : base(navigationService)
        {
            Game = game;
            UndoMoveCommand = new RelayCommand(UndoMove, (_) => game.CanUndoMove);
            QuitCommand = new RelayCommand(Quit);
            ActiveMoves = new List<Move>();
        }

        /// <summary>
        /// Handles the action to be executed when the player presses the undo move button
        /// </summary>
        private void UndoMove()
        {
            Game.UndoMove();
            SelectedSquare = null;
        }

        /// <summary>
        /// Handles the action to be executed when the player presses the quit button
        /// </summary>
        private void Quit()
        {
            navigationService.Navigate(() => new GameModeSelectViewModel(navigationService));
        }

        /// <summary>
        /// TODO uitleggen
        /// </summary>
        private void DetermineActiveMoves()
        {
            Move selectedMove = ActiveMoves.FirstOrDefault(activeMove => activeMove.Destination == _selectedSquare);
            ActiveMoves = new List<Move>();
            if(selectedMove != null)
            {
                // Selected a possible move, execute the move
                Game.MakeMove(selectedMove);
                SelectedSquare = null;
            }
            // Does the selected square have a piece from the current player?
            else if(_selectedSquare?.Piece != null && _selectedSquare.Piece.Color == Game.CurrentPlayer.Color) // TODO teveel?
            {
                // Generate possible moves
                ActiveMoves = _selectedSquare.Piece.Movement.GetPossibleMoves(_selectedSquare.Piece, Game.Squares).Where(move => Game.IsLegal(move) && move.CanBeMade(Game)).ToList(); // TODO
            }
        }
    }
}
