using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * Esta clase permite que los comandos (métodos en ViewModel) se puedan enlazar a los botones de la interfaz de usuario.
 */
namespace FutbolAdmin.ViewModel {
    using System;
    using System.Windows.Input;

    internal class ComandoViewModel : ICommand {
        private readonly Action<object> _execute;
        private readonly Predicate<object> _canExecute;

        public ComandoViewModel(Action<object> execute, Predicate<object> canExecute = null) {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public ComandoViewModel(Action<object> execute) {
            _execute = execute;
            _canExecute = null;
        }

        public bool CanExecute(object parameter) => _canExecute?.Invoke(parameter) ?? true;

        public void Execute(object parameter) => _execute(parameter);

        public event EventHandler CanExecuteChanged {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }
}
