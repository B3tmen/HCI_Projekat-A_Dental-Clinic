using Models.Dao.Implementations;
using Models.Dao.Interfaces;
using Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ViewModels.Commands;
using ViewModels.Interfaces;
using ViewModels.Services;
using ViewModels.Util;

namespace ViewModels.Administrator
{
    public class AdminMainViewModel : ViewModelBase, IParameterReceiver
    {
        private INavigationService          _navigationService;
        private Models.Model.Administrator  _admin;
        private string                      _adminFullName;
        private Page                        _childPage;
        private Window                      _window;

        public AdminMainViewModel(INavigationService navigationService, Window window)
        {
            _navigationService = navigationService;
            _window = window;
            UserLanguage = null;
            UserTheme = null;
            UserFont = null;

            SetupCommands();
        }


        public ICommand ShowUsersCommand    { get; private set; }
        public ICommand ShowStorageCommand  { get; private set; }
        public ICommand ShowSettingsCommand { get; private set; }
        public ICommand LogoutCommand       { get; private set; }

        public Page ChildPage
        {
            get => _childPage;
            set
            {
                _childPage = value;
                OnPropertyChanged(nameof(ChildPage));
            }
        }

        public Models.Model.Administrator Admin
        {
            get => _admin;
            set
            {
                _admin = value;
                OnPropertyChanged(nameof(Admin));
            }
        }

        public string AdminFullName
        {
            get => _adminFullName;
            set
            {
                _adminFullName = value;
                OnPropertyChanged(nameof(AdminFullName));
            }
        }

        public Theme    UserTheme       { get; private set; }
        public Language UserLanguage    { get; private set; }
        public UserFont UserFont        { get; private set; }


        private void SetupCommands()
        {
            ShowUsersCommand = new RelayCommand(execute => OnShowUsers());
            ShowStorageCommand = new RelayCommand(execute => OnShowStorage());
            ShowSettingsCommand = new RelayCommand(execute => OnShowSettings());
            LogoutCommand = new RelayCommand(execute => OnLogout());
        }

        private void OnShowUsers()
        {
            ChildPage = _navigationService.NavigateToPage("UsersPage");
        }
        private void OnShowStorage()
        {
            ChildPage = _navigationService.NavigateToPage("StoragePage");
        }
        private void OnShowSettings()
        {
            ChildPage = _navigationService.NavigateToPage("SettingsPage");
        }

        private void OnLogout()
        {
            var answer = MessageBoxShower.ShowQuestionBox(LanguageService.GetString("Question_Logout"), LanguageService.GetString("PressYes"));
            if (answer == MessageBoxResult.Yes)
            {
                _navigationService.NavigateToWindow("LoginWindow");
                _window.Hide();
            }
        }

        public void OnReceiveParameter(object parameter)
        {
            if (parameter != null)
            {
                if (parameter is Models.Model.Administrator admin)
                {
                    _admin = admin;
                    AdminFullName = _admin.FirstName + " " + _admin.LastName + ", Admin";
                    SetupUserPreferences(_admin.LanguageId, _admin.ThemeId, _admin.FontId);
                }
            }
        }

        private async void SetupUserPreferences(int languageId, int themeId, int fontId)
        {
            ILanguageDao languageDao = new LanguageDaoImpl();
            IThemeDao themeDao = new ThemeDaoImpl();
            IFontDao fontDao = new FontDaoImpl();

            Language language = await languageDao.GetAsync(languageId);
            Theme theme = await themeDao.GetAsync(themeId);
            UserFont font = await fontDao.GetAsync(fontId);

            if (language != null)
            {
                UserLanguage = language;
            }
            if (theme != null)
            {
                UserTheme = theme;
            }
            if (font != null)
            {
                UserFont = font;
            }
        }
    }
}
