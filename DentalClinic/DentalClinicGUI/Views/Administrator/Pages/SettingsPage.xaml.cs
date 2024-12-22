using DentalClinicGUI.Util;
using MaterialDesignThemes.Wpf;
using Models.Dao.Implementations;
using Models.Dao.Interfaces;
using Models.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using ViewModels.Administrator;
using ViewModels.Services;

namespace DentalClinicGUI.Views.Administrator.Pages
{
    /// <summary>
    /// Interaction logic for SettingsPage.xaml
    /// </summary>
    public partial class SettingsPage : Page
    {
        public SettingsPage()
        {
            InitializeComponent();

            DataContext = new SettingsViewModel();
        }

        private async void LanguageComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedLanguage = (sender as ComboBox)?.SelectedItem;
            if (selectedLanguage != null)
            {
                if(selectedLanguage is Models.Model.Language lang)
                {
                    Models.Model.Administrator admin = ((SettingsViewModel) DataContext).Admin;
                    IAdministratorDao dao = new AdministratorDaoImpl();

                    bool inserted = await dao.ChangeLanguage(admin.UserId, lang);
                    if (inserted)
                    {
                        string name = ResolveLanguage(lang.LanguageProperty.ToString());
                        AppLanguage.ChangeLanguage(new Uri($"Dictionaries/Languages/{name}.xaml", UriKind.Relative));

                        if(lang.LanguageProperty.ToString() == "English")
                        {
                            LanguageService.SetLanguage("en");
                        }
                        else if (lang.LanguageProperty.ToString() == "Serbian")
                        {
                            LanguageService.SetLanguage("sr");
                        }
                    }
                }
            }
        }

        private async void ThemeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedTheme = (sender as ComboBox)?.SelectedItem;
            if (selectedTheme != null)
            {
                if (selectedTheme is Models.Model.Theme theme)
                {
                    Models.Model.Administrator admin = ((SettingsViewModel)DataContext).Admin;
                    IAdministratorDao dao = new AdministratorDaoImpl();

                    bool inserted = await dao.ChangeTheme(admin.UserId, theme);
                    if (inserted)
                    {
                        AppTheme.ChangeTheme(new Uri($"Dictionaries/Themes/{theme.ThemeProperty.ToString()}Theme.xaml", UriKind.Relative));
                    }
                }
            }
        }

        private string ResolveLanguage(string name)
        {
            return name switch
            {
                "English" => "Language.en-us",
                "Serbian" => "Language.sr"
            };
        }

        private async void FontComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FontComboBox.SelectedItem is UserFont userFont)
            {
                string selectedFont = userFont.FontName.ToString();
                Models.Model.Administrator admin = ((SettingsViewModel)DataContext).Admin;
                IAdministratorDao dao = new AdministratorDaoImpl();

                bool inserted = await dao.ChangeFont(admin.UserId, userFont);
                if (inserted)
                {
                    AppFont.ChangeFont(selectedFont);
                }

                
            }
        }
    }
}
