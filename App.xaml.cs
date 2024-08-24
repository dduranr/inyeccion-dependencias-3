using InyeccionDeDependencias3.Misc;
using InyeccionDeDependencias3.Misc.Interfaces;
using InyeccionDeDependencias3.MVVM.ViewModels;
using InyeccionDeDependencias3.MVVM.Views;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace InyeccionDeDependencias3
{
    /// <summary>
    /// El archivo App.xaml.cs configura el contenedor de servicios para la inyección de dependencias, establece el DataContext de la ventana principal a una instancia de MainViewModel obtenida del contenedor, y muestra la ventana principal cuando la aplicación inicia.
    /// DependencyInjection proporciona soporte para la inyección de dependencias en .NET. La pripiedad _serviceProvider es el contenedor de servicios utilizado para la inyección de dependencias. En App.xaml se eliminó StartupUri, que es donde se define la ventana que se abre por defecto, y sobreescribimos aquí el método OnStartup de la clase base Application, con el fin de armar la lógica para la inyección de dependencias y de indicar a la app cuál es la ventana que debe abrirse (MainView). Puesto que aquí se declara el DataContext de la ventana principal MainView.xaml, en ésta ya no es necesario vincular dicha vista con su modelo de vista: <Window.DataContext>.
    /// </summary>
    public partial class App : Application
    {
        private static IServiceProvider? _serviceProvider;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            if (_serviceProvider == null)
            {
                _serviceProvider = new ServiceCollection()
                    .AddSingleton<IMessageWriter, MessageWriter>()
                    .AddSingleton<MainViewModel>()
                    .BuildServiceProvider();
            }

            var mainView = new MainView();
            mainView.DataContext = _serviceProvider.GetService<MainViewModel>();
            mainView.Show();
        }
    }
}
