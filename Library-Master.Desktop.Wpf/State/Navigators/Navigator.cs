using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Library_Master.Desktop.Wpf.Commands;
using Library_Master.Desktop.Wpf.Models;
using Library_Master.Desktop.Wpf.ViewModels;

namespace Library_Master.Desktop.Wpf.State.Navigators
{
    public class Navigator : ObservableObject, INavigator
    {
        private BaseViewModel _currentViewModel;

        public BaseViewModel CurrentViewModel
        {
            get
            {
                return _currentViewModel;
            }
            set
            {
                _currentViewModel = value;
                OnPropertyChanged(nameof(CurrentViewModel));
            }
        }
        public ICommand UpdateCurrentViewmodelCommand => new UpdateCurrentViewModelCommand(this);

        
    }
}