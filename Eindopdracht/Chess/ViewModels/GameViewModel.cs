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
    public class GameViewModel : BaseViewModel
    {
        private Square _selectedSquare;
        private IList<Move> _activeMoves;

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
        public IList<Move> ActiveMoves
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

        public GameViewModel(Game game, NavigationService navigationService) : base(navigationService)
        {
            Game = game;
            UndoMoveCommand = new RelayCommand(UndoMove);
            QuitCommand = new RelayCommand(Quit);
            ActiveMoves = new List<Move>();
        }

        private void UndoMove()
        {
            Game.UndoMove();
        }

        private void Quit()
        {
            navigationService.Navigate(() => new GameModeSelectViewModel(navigationService));
        }

        private void DetermineActiveMoves()
        {
            ActiveMoves = new List<Move>();
            Move selectedMove = ActiveMoves.FirstOrDefault(activeMove => activeMove.Destination == _selectedSquare);
            if(selectedMove != null)
            {
                // Selected a possible move, execute the move
                Game.MakeMove(selectedMove);
            }
            // Does the selected square have a piece from the current player?
            else if(_selectedSquare?.Piece != null && _selectedSquare.Piece.Color == Game.CurrentPlayer.Color)
            {
                // Generate possible moves
                ActiveMoves = new List<Move>() { new Move() { Destination = Game.Squares[0][0] } }; // TODO
            }
        }
    }
}
