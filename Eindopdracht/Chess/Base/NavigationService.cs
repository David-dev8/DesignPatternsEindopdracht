using Chess.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Base
{
    public class NavigationService
    {
        private NavigationStore _navigationStore;

        public NavigationService(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }

        public void Navigate(Func<BaseViewModel> navigateTo)
        {
            _navigationStore.CurrentViewModel = navigateTo();
        }
    }
}
