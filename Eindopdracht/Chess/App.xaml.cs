using Chess.Base;
using Chess.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Chess
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var navigationStore = new NavigationStore();
            var navigationService = new NavigationService(navigationStore);

            // TODO add splashscreen

            Task.Factory.StartNew(async () =>
            {
                navigationStore.CurrentViewModel = new GameModeSelectViewModel(navigationService);

                Dispatcher.Invoke(() =>
                {
                    MainWindow = new MainWindow()
                    {
                        DataContext = new MainWindowViewModel(navigationStore)
                    };
                    MainWindow.Show();
                    base.OnStartup(e);
                });
            });
        }
    }
}
