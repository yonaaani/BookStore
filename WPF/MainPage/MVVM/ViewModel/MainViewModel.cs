using System;
using System.Threading;
using MainPage.Core;
using MainPage.MVVM.Model;
using MainPage.MVVM.Model.Contracts;
using MainPage.Repositories;
using MainPage.MVVM.ViewModel;
using MainPage.MVVM.View;
using FontAwesome.Sharp;
using System.Windows.Input;

namespace MainPage.MVVM.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        //fields
        private UserAccountModel _currentUserAccount;
        private IUserRepository userRepository;

        private ViewModelBase _currentChildView;
        private string _caption;
        private IconChar _icon;
        
        //properties
        public UserAccountModel CurrentUserAccount
        {
            get
            {
                return _currentUserAccount;
            }

            set
            {
                _currentUserAccount = value;
                OnPropertyChanged(nameof(CurrentUserAccount));
            }
        }

        public ViewModelBase CurrentChildView
        {
            get
            {
                return _currentChildView;
            }

            set
            {
                _currentChildView = value;
                OnPropertyChanged(nameof(CurrentChildView));
            }
        }

        public string Caption
        {
            get
            {
                return _caption;
            }

            set
            {
                _caption = value;
                OnPropertyChanged(nameof(Caption));
            }
        }

        public IconChar Icon
        {
            get { return _icon; }
            set { _icon = value; OnPropertyChanged(nameof(Icon)); }
        }

        //--> commands

        public ICommand ShowHomeViewCommand { get; set; }
        public ICommand ShowAboutViewCommand { get; set; }

        //public HomeViewModel HomeVM { get; set; }
        //public AboutViewModel AboutVM { get; set; }

        //private object _currentView;
        //public object CurrentView
        //{
        //    get { return _currentView; }
        //    set
        //    {
        //        _currentView = value;
        //        OnPropertyChanged();
        //    }
        //}
        public MainViewModel()
        {
            userRepository = new UserRepository();
            CurrentUserAccount = new UserAccountModel();

            //HomeVM = new HomeViewModel();
            //AboutVM = new AboutViewModel();

            //CurrentView = HomeVM;

            //HomeViewCommand = new RelayCommand(o =>
            //{
            //    CurrentView = HomeVM;
            //});

            //AboutViewCommand = new RelayCommand(o =>
            //{
            //    CurrentView = AboutVM;
            //});

            //initialize commands
            ShowHomeViewCommand = new ViewModelCommand(ExecuteShowHomeViewCommand);
            ShowAboutViewCommand = new ViewModelCommand(ExecuteShowAboutViewCommand);

            //default view
            ExecuteShowHomeViewCommand(null);
            LoadCurrentUserData();

        }

        //all pages
        private void ExecuteShowAboutViewCommand(object obj)
        {
            CurrentChildView = new AboutViewModel();
            Caption = "About";
        }

        private void ExecuteShowHomeViewCommand(object obj)
        {
            CurrentChildView = new HomeViewModel();
            Caption = "Home";
        }

        private void LoadCurrentUserData()
        {
            var user = userRepository.GetByUsername(Thread.CurrentPrincipal.Identity.Name);
            if (user != null)
            {
                CurrentUserAccount.Username = user.Username;
                CurrentUserAccount.DisplayName = $"Hello, {user.Name} {user.LastName}";
                CurrentUserAccount.ProfilePicture = null;
            }
            else
            {
                CurrentUserAccount.DisplayName = "Invalid user";
                //Hide child views.
            }
        }
    }
}
