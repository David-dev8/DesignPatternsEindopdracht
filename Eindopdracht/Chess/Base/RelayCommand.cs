using System;
using System.Windows.Input;

namespace Chess.Base
{
    /// <summary>
    /// Deze klasse vertegenwoordigt een command die wordt uitgevoerd wanneer hij voldoet aan de voorwaarden die zijn 
    /// meegegeven via de canExecute.
    /// </summary>
    public class RelayCommand : ICommand
    {
        private readonly Predicate<object> _canExecute;
        private readonly Action _execute;

        /// <summary>
        /// Creëert een RelayCommand met een gegeven methode die wordt uitgevoerd, wanneer deze wordt geactiveerd.
        /// </summary>
        /// <param name="execute">De uit te voeren methode</param>
        public RelayCommand(Action execute)
        {
            _canExecute = null;
            _execute = execute;
        }

        /// <summary>
        /// Creëert een RelayCommand met een gegeven methode die wordt uitgevoerd, wanneer deze wordt geactiveerd. 
        /// Voordat hij deze methode uitvoert, wordt er eerst gecontroleerd of hij mag worden uitgevoerd.
        /// </summary>
        /// <param name="execute">De uit te voeren methode.</param>
        /// <param name="canExecute">De methode waarin wordt gecontroleerd of de execute methode mag worden uitgevoerd.</param>
        public RelayCommand(Action execute, Predicate<object> canExecute)
        {
            _canExecute = canExecute;
            _execute = execute;
        }

        /// <summary>
        /// Dit event handelt het eventuele veranderen van de mogelijkheid om uit te voeren, af.
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        /// <summary>
        /// Deze methode controleert of de execute methode mag worden uitgevoerd.
        /// </summary>
        /// <param name="parameter">Het object dat de canExecute nodig heeft.</param>
        /// <returns>Als de _canExecute methode niet is geset wordt er altijd true gereturnd, anders wordt de uitkomst van de 
        /// canExecute gereturnt.</returns>
        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }

        /// <summary>
        /// Voert de gegeven execute methode uit.
        /// </summary>
        public void Execute(object parameter)
        {
            _execute.Invoke();
        }
    }
}
