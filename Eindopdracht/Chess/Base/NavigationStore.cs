using Chess.ViewModels;
using System;

namespace Chess.Base
{
    /// <summary>
    /// Stores wich viewmodel is actively being shown
    /// </summary>
    public class NavigationStore
    {
        private BaseViewModel _currentViewModel;

        public BaseViewModel CurrentViewModel
        {
            get
            {
                return _currentViewModel;
            }
            set
            {
                _currentViewModel = value;
                if(value != null)
                {
                    Navigated?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        public event EventHandler Navigated;

        public NavigationStore(BaseViewModel currentViewModel = null)
        {
            CurrentViewModel = currentViewModel;
        }
    }
}
