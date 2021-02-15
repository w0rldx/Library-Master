using System.Windows.Input;
using Library_Master.Desktop.Wpf.ViewModels;

namespace Library_Master.Desktop.Wpf.State.Navigators
{
    public interface INavigator
    {
        BaseViewModel CurrentViewModel { get; set; }
        ICommand UpdateCurrentViewmodelCommand { get; }
    }
}