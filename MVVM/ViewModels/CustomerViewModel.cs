using System.Diagnostics;
using System.Windows.Input;

namespace InyeccionDeDependencias3.MVVM.ViewModels
{
    public class CustomerViewModel : ViewModelBase
    {
        //Propiedades privadas


        //Propiedades públicas

        //Comandos
        public ICommand ShowUserCreateView { get; }

        //Inicialización de comandos
        //public CustomerViewModel(MainViewModel mainViewModel)
        public CustomerViewModel()
        {
            //var x = mainViewModel.Titulo;
            //Trace.WriteLine("Funciona!!!: " + x);
            ShowUserCreateView = new ViewModelCommand(ExecuteShowCustomerCreateView);
        }

        //Delegados
        public void ExecuteShowCustomerCreateView(object? obj)
        {
            Trace.WriteLine("¡Se ejecuta el delegado!");
            //MainViewModel mainViewModel;
            //var x = mainViewModel.GetType();
        }

        //Predicados
    }
}
