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

        public Game Game { get; set; }
        public ICommand UndoMoveCommand { get; set; }
        public ICommand QuitCommand { get; set; }
        public ObservableCollection<Move> ActiveMoves { get; } = new ObservableCollection<Move>();
        public Square SelectedSquare
        {
            get
            {
                return _selectedSquare;
            }
            set
            {
                _selectedSquare = value;

                Move selectedMove = ActiveMoves.FirstOrDefault(activeMove => activeMove.Destination == _selectedSquare);
                if(selectedMove != null)
                {
                    // Selected a possible move, execute the move
                    Game.MakeMove(selectedMove);
                    ActiveMoves.Clear();
                }
                // Does the selected square have a piece from the current player?
                else if(_selectedSquare.Piece.Color == Game.CurrentPlayer.Color) 
                {
                    // Generate possible moves
                    ActiveMoves.Clear();
                    ActiveMoves.Add(_selectedSquare.Piece.MovementPattern); // TODO
                }

                NotifyPropertyChanged();
            }
        }

        public GameViewModel(Game game, NavigationService navigationService) : base(navigationService)
        {
            Game = game;
            UndoMoveCommand = new RelayCommand(UndoMove);
            QuitCommand = new RelayCommand(Quit);
        }

        private void UndoMove()
        {
            Game.UndoMove();
        }

        private void Quit()
        {

        }
    }
}
