# Inyección de dependencias

La inyección de dependencias es una forma de implementar el principio SOLID: *inversión de dependencia*, que consiste en que las entidades (clases, objetos, etc) deben depender de abstracciones y no de implementaciones concretas.

Este proyecto es de **C#**, y está basado en el ejemplo de la documentación oficial [learn.microsoft.com](https://learn.microsoft.com/es-es/dotnet/core/extensions/dependency-injection). El ejemplo que da la documentación oficial está diseñado para correr en una aplicación C# de consola. Sin embargo, la presente aplicación integra este mismo ejemplo pero en una aplicación C# WPF usando el patrón MVVM.

En C# y .NET, por ejemplo, se puede usar el paquete DependencyInjection. Éste es un contenedor de inversión de control. Es decir, es un contenedor de objetos que se encarga de crear y destruir las instancias de las clases. Y, además, gestiona las dependencias entre ellas. La idea es que el programador configure todas las clases que entran en juego en la aplicación y su ciclo de vida. Después, el contenedor se encarga de crear las instancias de las clases y de inyectar las dependencias entre ellas cuando sea necesario.

En resumen, la magia está en los archivos App.xaml.cs y MainViewModel.cs.

1. En App.xaml.cs se configura el contenedor de servicios para la inyección de dependencias, establece el DataContext de la ventana principal a una instancia de MainViewModel obtenida del contenedor, y muestra la ventana principal cuando la aplicación inicia. En el contenedor de servicios _serviceProvider se registran las clases que se usarán para inyección de dependencias. Para que la inyección funcione, aquí deben registrarse tanto la clase a inyectar como la clase a donde se va a inyectar. Dentro del contenedor de servicios NO se diferencia entre cuál es la clase que se inyecta y cuál la que recibe la inyección.
2. En MainViewModel.cs se crea una propiedad privada _messageWriter para guardar la instancia inyectada, y así pueda ser utilizada en cualquier parte dentro de MainViewModel.cs. Después se inyecta formalmente como parámetro en el constructor y finalmente se usa la instancia de MessageWriter.


**App.xaml.cs**

    namespace InyeccionDeDependencias3
    {
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


**MainViewModel.cs**

    namespace InyeccionDeDependencias3.MVVM.ViewModels
    {
        public class MainViewModel : ViewModelBase
        {
            private readonly IMessageWriter _messageWriter;

            public ICommand ShowHomeViewCommand { get; }
            public ICommand ShowCustomerViewCommand { get; }

            public MainViewModel(IMessageWriter messageWriter)
            {
                _messageWriter = messageWriter;
            }

            private void ExecuteShowHomeViewCommand(object? obj)
            {
                _messageWriter.Write("Este es el mensaje 1");
            }
            private void ExecuteShowCustomerViewCommand(object obj)
            {
                _messageWriter.Write($"CUTEste es el mensaje 2");
            }
        }
    }

