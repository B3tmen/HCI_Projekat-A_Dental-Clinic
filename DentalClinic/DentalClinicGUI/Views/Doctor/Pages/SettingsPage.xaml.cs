using DentalClinicGUI.Util;
using Models.Dao.Implementations;
using Models.Dao.Interfaces;
using Models.Enums;
using Models.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ViewModels.Doctor;
using ViewModels.Services;
using ViewModels.Util;

namespace DentalClinicGUI.Views.Doctor.Pages
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
                    Models.Model.Doctor doctor = ((SettingsViewModel) DataContext).Doctor;
                    IDoctorDao dao = new DoctorDaoImpl();

                    bool inserted = await dao.ChangeLanguage(doctor.UserId, lang);
                    if (inserted)
                    {
                        string name = ResolveLanguage(lang.LanguageProperty.ToString());
                        AppLanguage.ChangeLanguage(new Uri($"Dictionaries/Languages/{name}.xaml", UriKind.Relative));

                        if(lang.LanguageProperty == LanguageEnum.English)
                        {
                            LanguageService.SetLanguage("en");
                        }
                        else if (lang.LanguageProperty == LanguageEnum.Serbian)
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
                    Models.Model.Doctor doctor = ((SettingsViewModel)DataContext).Doctor;
                    IDoctorDao dao = new DoctorDaoImpl();

                    bool inserted = await dao.ChangeTheme(doctor.UserId, theme);
                    if (inserted)
                    {
                        AppTheme.ChangeTheme(new Uri($"Dictionaries/Themes/{theme.ThemeProperty.ToString()}Theme.xaml", UriKind.Relative));
                    }
                }
            }
        }
        private async void FontComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FontComboBox.SelectedItem is UserFont userFont)
            {
                string selectedFont = userFont.FontName.ToString();
                Models.Model.Doctor doctor = ((SettingsViewModel)DataContext).Doctor;
                IAdministratorDao dao = new AdministratorDaoImpl();

                bool inserted = await dao.ChangeFont(doctor.UserId, userFont);
                if (inserted)
                {
                    AppFont.ChangeFont(selectedFont);
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

    }
}
