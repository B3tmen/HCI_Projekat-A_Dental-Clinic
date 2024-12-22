using Models.Dao.Implementations;
using Models.Dao.Interfaces;
using Models.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using ViewModels.Interfaces;
using ViewModels.Util;

namespace ViewModels.Administrator
{
    public class SettingsViewModel : ViewModelBase, IParameterReceiver
    {
        private Models.Model.Administrator  _admin;
        private Theme                       _selectedTheme;
        private Language                    _selectedLanguage;
        private UserFont                    _selectedFont;

        public SettingsViewModel() 
        { 
            ThemeItems = new();
            LanguageItems = new();
            FontItems = new();

            SetupItems();
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

        public Theme SelectedTheme     
        {
            get => _selectedTheme;
            set
            {
                _selectedTheme = value;
                OnPropertyChanged(nameof(SelectedTheme));   
            }
        }

        public Language SelectedLanguage
        {
            get => _selectedLanguage;
            set
            {
                _selectedLanguage = value;
                OnPropertyChanged(nameof(SelectedLanguage));
            }
        }

        public ObservableCollection<Theme>      ThemeItems      { get; set; }
        public ObservableCollection<Language>   LanguageItems   { get; set; }
        public ObservableCollection<UserFont>   FontItems       { get; set; }


        private async void SetupItems()
        {
            ILanguageDao langDao = new LanguageDaoImpl();
            IThemeDao themeDao = new ThemeDaoImpl();
            IFontDao fontDao = new FontDaoImpl();

            List<Language> languages = await langDao.GetAllAsync();
            List<Theme> themes = await themeDao.GetAllAsync();
            List<UserFont> fonts = await fontDao.GetAllAsync();

            foreach (var lang in languages)
            {
                LanguageItems.Add(lang);
            }
            foreach (var theme in themes)
            {
                ThemeItems.Add(theme);
            }
            foreach (var font in fonts)
            {
                FontItems.Add(font);
            }
        }

        public void OnReceiveParameter(object parameter)
        {
            if(parameter is Models.Model.Administrator admin)
            {
                Admin = admin;
                //_doctor = new Models.Model.Doctor() { Username = "user3000" };
            }
        }

        
    }
}
