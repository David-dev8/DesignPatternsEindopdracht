using Chess.Base;
using Chess.Models.Games;
using Chess.Models.Games.Modes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Chess.ViewModels
{
    /// <summary>
    /// This viewmodel is for the page where you can select a gamemode
    /// </summary>
    public class GameModeSelectViewModel : BaseViewModel
    {
        public IEnumerable<ModeInfo> GameModes { get; set; }
        public ICommand StartCommand { get; set; }

        private ModeInfo _chosenGameMode;
        public ModeInfo ChosenGameMode 
        { 
            get 
            {
                return _chosenGameMode;
            } 
            set 
            {
                _chosenGameMode = value;
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Creates the game viewmodel
        /// </summary>
        /// <param name="navigationService">The navigationservice to navigate with</param>
        public GameModeSelectViewModel(NavigationService navigationService) : base(navigationService)
        {
            GameModes = GameModeStore.GetModeInfos();
            StartCommand = new RelayCommand(StartGame);
            ChosenGameMode = GameModes.First();

        }

        /// <summary>
        /// Starts a game with the selected gamemode and navigate to the game page
        /// </summary>
        public void StartGame()
        {
            Game GameToStart = GameModeFactory.CreateGame(ChosenGameMode.Name);
            navigationService.Navigate(() => new GameViewModel(GameToStart, navigationService));
        }


    }
}
