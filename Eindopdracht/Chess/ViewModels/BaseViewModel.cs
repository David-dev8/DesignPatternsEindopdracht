using Chess.Base;

namespace Chess.ViewModels
{
    /// <summary>
    /// Deze klasse dient als basis voor elke ViewModel in de applicatie.
    /// </summary>
    public class BaseViewModel : Observable
    {
        protected NavigationService navigationService;

        public BaseViewModel(NavigationService navigationService)
        {
            this.navigationService = navigationService;
        }
    }
}
