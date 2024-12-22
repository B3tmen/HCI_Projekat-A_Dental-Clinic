using Models.Dao.Implementations;
using Models.Dao.Interfaces;
using Models.Exceptions;
using Models.Model;
using Models.Util;
using System.Windows;
using System.Windows.Input;
using ViewModels.Commands;
using ViewModels.Interfaces;
using ViewModels.Services;
using ViewModels.Util;

namespace ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private Dictionary<string, INavigationService> _navigationServices;
        private INavigationService _navigationService;
        private string _username;
        private string _password;


        public LoginViewModel(Dictionary<string, INavigationService> navigationServices, Window loginWindow)
        {
            _navigationServices = navigationServices;
            LoginWindow = loginWindow;
            Username = string.Empty;
            Password = string.Empty;

            LoginUserCommand = new RelayCommand(execute => OnCheckLogin());
        }

        public ICommand LoginUserCommand { get; }
        private Window LoginWindow { get; init; }


        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }


        private async void OnCheckLogin()
        {

            if (Username != null && Username == string.Empty)
            {
                MessageBoxShower.ShowErrorBox(LanguageService.GetString("Error_UsernameEmpty"), LanguageService.GetString("EnterUsername"));
            }
            if (Username != null && Password == string.Empty)
            {
                MessageBoxShower.ShowErrorBox(LanguageService.GetString("Error_PasswordEmpty"), LanguageService.GetString("EnterPassword"));
            }

            if (Username != null && Username != string.Empty && Password != null && Password != string.Empty)
            {
                string passwordHash = TextHasher.GetSHA256Hash(Password);
                IUserDao userDao = new UserDaoImpl();
                User user = await userDao.GetByUsernameAndPassword(new Models.Model.Dto.UserLoginDto { Username = Username, Password = passwordHash });
                try
                {
                    if (user != null)
                    {
                        MessageBoxShower.ShowSuccessBox(LanguageService.GetString("Success_Login"), LanguageService.GetString("PressOK"));

                        if (user is Models.Model.Administrator admin)
                        {
                            if (_navigationServices.TryGetValue("AdminNavigationService", out _navigationService))
                            {
                                _navigationService.NavigateToWindow("AdminMainWindow", admin);
                            }
                        }
                        else if (user is Models.Model.Doctor doctor)
                        {
                            if (_navigationServices.TryGetValue("DoctorNavigationService", out _navigationService))
                            {
                                _navigationService.NavigateToWindow("DoctorMainWindow", doctor);
                            }
                        }

                        LoginWindow.Close();
                    }
                    else
                    {
                        throw new UserNotAuthenticatedException();
                    }

                }
                catch (UserNotAuthenticatedException ex)
                {
                    MessageBoxShower.ShowErrorBox(LanguageService.GetString("Error_WrongCredentials"), LanguageService.GetString("CheckUsername&Password"));
                    Console.WriteLine(ex.StackTrace);
                }
            }
        }

        private bool CanExecuteLogin(object parameter)
        {
            return !string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password);
        }
    }
}
