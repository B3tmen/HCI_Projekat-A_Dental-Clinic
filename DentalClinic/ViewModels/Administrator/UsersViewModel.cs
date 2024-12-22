using Models.Dao.Implementations;
using Models.Dao.Interfaces;
using Models.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using ViewModels.Commands;
using ViewModels.Interfaces;
using ViewModels.Services;
using ViewModels.Util;


namespace ViewModels.Administrator
{
    public class UsersViewModel : ViewModelBase
    {
        private INavigationService          _navigationService;
        private ObservableCollection<User>  _usersCollection;
        private TextSearchMechanism<User>   _searchMechanism;


        public UsersViewModel(INavigationService navigationService) 
        {
            _navigationService = navigationService;
            _usersCollection = new();
            _searchMechanism = new(UsersCollection, user => user.LastName);

            ShowAddUserCommand = new RelayCommand(execute => OnShowAddUser());
            ShowUpdateUserCommand = new RelayCommand(OnShowUpdateUser);
            RefreshCommand = new RelayCommand(execute => OnRefreshUsers());

            //ToggleActiveStatusCommand = new RelayCommand(OnToggleStatus); 

            LoadUsersCollection(); 
        }

        //public ICommand ToggleActiveStatusCommand { get; init; }
        public ICommand ShowAddUserCommand      { get; init; }
        public ICommand ShowUpdateUserCommand   { get; init; }
        public ICommand RefreshCommand          { get; init; }


        public ObservableCollection<User> UsersCollection
        {
            get => _usersCollection;
            set
            {
                _usersCollection = value;
                OnPropertyChanged(nameof(UsersCollection));
            }
        }

        public string SearchText
        {
            get => _searchMechanism.FilterText;
            set
            {
                if (_searchMechanism.FilterText != value)
                {
                    _searchMechanism.FilterText = value;
                    OnPropertyChanged(nameof(SearchText));
                }
            }
        }

        private void OnShowAddUser()
        {
            _navigationService.NavigateToWindow("AddUserWindow");
        }

        private void OnShowUpdateUser(object parameter)
        {
            if(parameter != null)
            {
                _navigationService.NavigateToWindow("UpdateUserWindow", parameter);
            }
            
        }

        private void OnRefreshUsers()
        {
            LoadUsersCollection();
        }

        //private void OnToggleStatus(object parameter)
        //{

        //    if (_toggleButton != null && parameter is User user)
        //    {
        //        MessageBoxResult answer = MessageBoxResult.No;
        //        if (user.IsActive)
        //        {
        //            answer = MessageBoxShower.ShowQuestionBox(LanguageService.GetString("Question_DeactivateStatus"), LanguageService.GetString("PressYes"));
        //            if (answer == MessageBoxResult.Yes)
        //            {
        //                user.IsActive = !user.IsActive;
        //            }
        //            else
        //            {
        //                _toggleButton.IsChecked = true;
        //            }
        //        }
        //        else
        //        {
        //            answer = MessageBoxShower.ShowQuestionBox(LanguageService.GetString("Question_ActivateStatus"), LanguageService.GetString("PressYes"));
        //            if (answer == MessageBoxResult.Yes)
        //            {
        //                user.IsActive = !user.IsActive;
        //            }
        //            else
        //            {
        //                _toggleButton.IsChecked = false;
        //            }
        //        }
        //    }
        //}

        private async void LoadUsersCollection()
        {
            IUserDao dao = new UserDaoImpl();
            List<User> userList = await dao.GetAllAsync();

            UsersCollection.Clear();
            if (userList != null)
            {
                foreach (var item in userList)
                {
                    UsersCollection.Add(item);
                }
            }
        }
    }
}
