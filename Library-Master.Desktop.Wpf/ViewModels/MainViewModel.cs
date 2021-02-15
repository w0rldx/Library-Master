using Library_Master.Desktop.Wpf.State.Navigators;

namespace Library_Master.Desktop.Wpf.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public INavigator Navigator { get; set; } = new Navigator();
    }
}