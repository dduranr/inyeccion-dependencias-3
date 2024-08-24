using System.ComponentModel;

namespace InyeccionDeDependencias3.MVVM.ViewModels
{
    /// <summary>
    /// Ésta es la clase base para todos los modelos de vista. Esta clase implementa la Interfaz INotifyPropertyChanged con el fin de que pueda notificar a los clientes que las usan, todos los cambios en las propiedades. La interfaz INotifyPropertyChanged tiene un único evento (PropertyChanged) que notifica a los clientes que una propiedad ha cambiado y que deben volver a evaluar sus valores.
    /// </summary>
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
