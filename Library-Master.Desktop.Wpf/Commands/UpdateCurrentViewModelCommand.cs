using System;
using System.Windows.Input;
using Library_Master.Desktop.Wpf.State.Navigators;
using Library_Master.Desktop.Wpf.ViewModels;

namespace Library_Master.Desktop.Wpf.Commands
{
    public class UpdateCurrentViewModelCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private INavigator _navigator;

        public UpdateCurrentViewModelCommand(INavigator navigator)
        {
            _navigator = navigator;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter is ViewType)
            {
                ViewType viewType = (ViewType) parameter;
                switch (viewType)
                {
                    case ViewType.Home:
                        _navigator.CurrentViewModel = new HomeViewModel();
                        break;
                    case ViewType.Book:
                        _navigator.CurrentViewModel = new BookViewModel();
                        break;
                    case ViewType.Student:
                        _navigator.CurrentViewModel = new StudentViewModel();
                        break;
                    case ViewType.Transaction:
                        _navigator.CurrentViewModel = new TransactionViewModel();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}