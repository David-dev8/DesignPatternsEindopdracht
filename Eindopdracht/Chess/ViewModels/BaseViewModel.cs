using Chess.Base;

namespace Chess.ViewModels
{
    /// <summary>
    /// Deze klasse dient als basis voor elke ViewModel in de applicatie.
    /// </summary>
    public class BaseViewModel : Observable
    {
        protected NavigationService _navigationService;

        public BaseViewModel(NavigationService navigationService)
        {
            _navigationService = navigationService;
        }
    }
}
