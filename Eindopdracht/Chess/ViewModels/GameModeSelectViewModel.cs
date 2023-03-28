using Chess.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Chess.ViewModels
{
    public class GameModeSelectViewModel : BaseViewModel
    {

        public Dictionary<String, ICommand> GameModes { get; set; }
        public Dictionary<String, String> GameDescriptions { get; set; }
        public ICommand StartCommand { get; set; }

        private KeyValuePair<String, String> _chosenGameMode;
        public KeyValuePair<String, String> ChosenGameMode { 
            get {
                return _chosenGameMode;
            } set {
                _chosenGameMode = value;
                NotifyPropertyChanged();
            }
        }

        public GameModeSelectViewModel(NavigationService navigationService) : base(navigationService)
        {
            GameDescriptions = new Dictionary<String, String>();
            GameModes = new Dictionary<String, ICommand>();
            ChosenGameMode = new KeyValuePair<String, String>("", "");
            StartCommand = new RelayCommand(StartGame);

            GameModes.Add("Clasic chess", new RelayCommand(() => SelectGameMode("Clasic chess")));
            GameDescriptions.Add("Clasic chess", "This is just clasical chess. 2 players, normal board, no special pieces, no special interactions.");

            GameModes.Add("Atomic chess", new RelayCommand(() => SelectGameMode("Atomic chess")));
            GameDescriptions.Add("Atomic chess", "This is atomic chess, atomic refers to the fact that all pieces are highly volatile. Capturing a piece will result in the removal of all pieces within a 3 x 3 area with the captured piece as the centre (A kings radius).");

            GameModes.Add("Four player chess", new RelayCommand(() => SelectGameMode("Four player chess")));
            GameDescriptions.Add("Four player chess", "Like clasical chess this mode does not implement any new pieces or interactions, however it does implement double the players. Take on 3 other players or cooperate to win in this 4 player chess mode.");

            GameModes.Add("Pawnstorm chess", new RelayCommand(() => SelectGameMode("Pawnstorm chess")));
            GameDescriptions.Add("Pawnstorm chess", "In this mode one player plays chess just like normal on a normal board with normal pieces. The second player however will have no normal pieces except for a lot of pawns.");

            GameModes.Add("Random chess", new RelayCommand(() => SelectGameMode("Random chess")));
            GameDescriptions.Add("Random chess", "In this gamemode both players will still have all their normal pieces. But their starting possition will be randomised");

            ChosenGameMode=GameDescriptions.ElementAt(0);

        }

        public void SelectGameMode(String gamemode)
        {
            ChosenGameMode = new KeyValuePair<String, String>(gamemode, GameDescriptions[gamemode]);
        }

        public void StartGame()
        {
            _navigationService.Navigate(() => new GameViewModel(_navigationService));
        }


    }
}
