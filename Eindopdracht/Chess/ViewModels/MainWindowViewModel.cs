using Chess.Base;
using System;
using System.Windows;
using System.Windows.Input;

namespace Chess.ViewModels
{
    public class MainWindowViewModel : Observable
    {
        private readonly NavigationStore _navigationStore;

        /// <summary>
        /// Deze property geeft toegang tot de huidige ViewModel.
        /// </summary>
        public BaseViewModel CurrentViewModel
        {
            get
            {
                return _navigationStore.CurrentViewModel;
            }
            private set
            {
                _navigationStore.CurrentViewModel = value;
            }
        }

        /// <summary>
        /// Creëert een ViewModel voor de MainWindow met een navigationStore.
        /// </summary>
        /// <param name="navigationStore">De navigationStore die wordt gebruikt voor navigatie.</param>
        public MainWindowViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            NotifyForUpdates();
        }

        private void NotifyForUpdates()
        {
            _navigationStore.Navigated += (object sender, EventArgs e) =>
            {
                OnPropertyChanged(nameof(CurrentViewModel));
            };
        }
    }
}
