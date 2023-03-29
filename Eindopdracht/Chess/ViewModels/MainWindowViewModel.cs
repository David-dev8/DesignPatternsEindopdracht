using Chess.Base;
using System;
using System.Windows;
using System.Windows.Input;

namespace Chess.ViewModels
{
    /// <summary>
    /// This is the main viewmodel
    /// </summary>
    public class MainWindowViewModel : Observable
    {
        private readonly NavigationStore _navigationStore;

        /// <summary>
        /// This property gives access to the current ViewModel
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
        /// Creates a ViewModel for the MainWindow with a navigationStore
        /// </summary>
        /// <param name="navigationStore">The navigationStore used for navigation</param>
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
