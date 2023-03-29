using System;
using System.Windows.Input;

namespace Chess.Base
{
    /// <summary>
    /// Represents a command that will be executed if the given conditions of canExecute are true.
    /// </summary>
    public class RelayCommand : ICommand
    {
        private readonly Predicate<object> _canExecute;
        private readonly Action _execute;

        /// <summary>
        /// Constructs a RelayCommand with a executable method
        /// </summary>
        /// <param name="execute">The method to be executed</param>
        public RelayCommand(Action execute)
        {
            _canExecute = null;
            _execute = execute;
        }

        /// <summary>
        /// Constructs a RelayCommand with a executable method, but it should only execute if the given conditions are true.
        /// </summary>
        /// <param name="execute">The method to be executed</param>
        /// <param name="canExecute">A method with some conditions</param>
        public RelayCommand(Action execute, Predicate<object> canExecute)
        {
            _canExecute = canExecute;
            _execute = execute;
        }

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
        /// Checks whether the executable method is allowed to execute.
        /// </summary>
        /// <param name="parameter">The object that canExecute needed</param>
        /// <returns>True if canExecute is not set, the result of canExecute otherwise</returns>
        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }

        /// <summary>
        /// Executes the executable method
        /// </summary>
        public void Execute(object parameter)
        {
            _execute.Invoke();
        }
    }
}
