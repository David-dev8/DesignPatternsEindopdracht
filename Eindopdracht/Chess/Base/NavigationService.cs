using Chess.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Base
{
    /// <summary>
    /// This is the service that is used to navigate between views
    /// </summary>
    public class NavigationService
    {
        private NavigationStore _navigationStore;

        public NavigationService(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }


        /// <summary>
        /// Navigate to another page
        /// </summary>
        /// <param name="navigateTo"> The viewmodel of the page you want to navigate to</param>
        public void Navigate(Func<BaseViewModel> navigateTo)
        {
            _navigationStore.CurrentViewModel = navigateTo();
        }
    }
}
