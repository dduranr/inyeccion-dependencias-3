using InyeccionDeDependencias3.MVVM.ViewModels;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;

namespace InyeccionDeDependencias3.MVVM.Views
{
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
            //DataContext = new MainViewModel();
        }
    }
}
