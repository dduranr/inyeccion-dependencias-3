using System.Diagnostics;
using System.Windows.Input;

namespace InyeccionDeDependencias3.MVVM.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        //Propiedades privadas
        private ViewModelBase _modeloDeVista = new HomeViewModel();
        private string _subtitulo = "Subtítulo por defecto";

        //Propiedades públicas
        public ViewModelBase ModeloDeVista
        {
            get => _modeloDeVista;
            set
            {
                _modeloDeVista = value;
                OnPropertyChanged(nameof(ModeloDeVista));
            }
        }

        public string Subtitulo
        {
            get => _subtitulo;
            set
            {
                _subtitulo = value;
                OnPropertyChanged(nameof(Subtitulo));
            }
        }

        //Comandos
        public ICommand ShowHomeViewCommand { get; }
        public ICommand ShowCustomerViewCommand { get; }

        //Inicialización de comandos
        public MainViewModel()
        {
            ShowHomeViewCommand = new ViewModelCommand(ExecuteShowHomeViewCommand);
            ShowCustomerViewCommand = new ViewModelCommand(ExecuteShowCustomerViewCommand);

            // Ejecutamos un comando, el que sea, con el fin de establecer una vista predeterminada
            ExecuteShowHomeViewCommand(null);
        }

        //Delegados
        private void ExecuteShowHomeViewCommand(object? obj)
        {
            ModeloDeVista = new HomeViewModel();
            Subtitulo = "Este es el subtítulo de HOME";
            Trace.WriteLine("Se lee delegado HOME");
        }
        private void ExecuteShowCustomerViewCommand(object obj)
        {
            ModeloDeVista = new CustomerViewModel();
            Subtitulo = "Este es el subtítulo de CUSTOMER";
            Trace.WriteLine("Se lee delegado CUSTOMER");
        }
    }
}
