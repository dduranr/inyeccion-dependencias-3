using System.Windows.Input;

namespace InyeccionDeDependencias3.MVVM.ViewModels
{
    internal class ViewModelCommand : ICommand
    {
        /// <summary>
        /// Se define campo de tipo action para ejecutar los comandos. El delegado action se usa para encapsular un método, es decir, para pasar un método como parámetro. Esta propiedad es la que recibirá el método a ejecutar cuando por ejemplo se presione un botón. Normalmente el método que se asigne a esta propiedad no devuelve nada, es void.
        /// </summary>
        private readonly Action<object> _executeAction;

        /// <summary>
        /// Se define campo de tipo predicate para determinar si la acción se puede ejecutar o no. Este delegado permite que el control se habilite/deshabilite en función de si se puede ejecutar su comando. El método que se asigne a esta propiedad obviamente debe ser bool.
        /// </summary>
        private readonly Predicate<object>? _canExecuteAction;

        /// <summary>
        /// Constructor sin predicado canExecuteAction (ya que no todos los comandos deben ser validados para verificar si debe ejecutarse la acción).
        /// </summary>
        /// <param name="executeAction"></param>
        public ViewModelCommand(Action<object> executeAction)
        {
            _executeAction = executeAction;
            _canExecuteAction = null;
        }

        /// <summary>
        /// Constructor con ambos parámetros: executeAction y canExecuteAction.
        /// </summary>
        /// <param name="executeAction">Hace referencia al método que se ejecutará cuando se ponga en acción el comando. Ese método devuelve void.</param>
        /// <param name="canExecuteAction">Hace referencia al método que se ejecutará para determinar si se puede ejecutar el método anterior. Ese método devuelve bool.</param>
        public ViewModelCommand(Action<object> executeAction, Predicate<object> canExecuteAction)
        {
            _executeAction = executeAction;
            _canExecuteAction = canExecuteAction;
        }

        /// <summary>
        /// Este evento forma parte de la implementación de ICommand.
        /// Subscribimos o damos de baja el evento RequerySuggested según sea necesario.
        /// El evento RequerySuggested se produce cuando el administrador de comandos detecta si la condición de ejecución del comando ha cambiado
        /// </summary>
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// Este evento forma parte de la implementación de ICommand.
        /// Este método es el encargado de ejecutar la acción del control en cuestión.
        /// Algo pasa con este método que al parecer parameter SIEMPRE es null, y aún así ejecuta el comando que se pasa mediante parameter. Por ejemplo, en LoginViewModel.cs está esta línea:
        ///     LoginCommand = new ViewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
        /// Cuando intento iniciar sesión con credenciales correctas e incorrectas, en cualquier caso el parameter es null. Lo raro es que funciona el login.
        /// Importante: si se hace la validación para que sólo se ejecute parameter cuando NO es null, dejan de funcionar los comandos, el más evidente, el del inicio de sesión.
        /// </summary>

        //public void Execute(object parameter)
        public void Execute(object? parameter)
        {
            _executeAction(parameter);
        }

        /// <summary>
        /// Este evento forma parte de la implementación de ICommand.
        /// Si _canExecuteAction es nulo devuleve siempre TRUE ya que no se ha establecido el predicaco de validación (1er constructor). Es decir, si no hay reglas de validación para habilitar/deshabilitar el control, éste siempre validará. De lo contrario, devolvemos el valor del delegado predicado, o sea, de la validación (2do constructor).
        /// </summary>
        public bool CanExecute(object? parameter)
        {
            bool parametro = (bool?)parameter ?? true;
            return _canExecuteAction == null ? true : _canExecuteAction(parametro);
        }

    }

}
