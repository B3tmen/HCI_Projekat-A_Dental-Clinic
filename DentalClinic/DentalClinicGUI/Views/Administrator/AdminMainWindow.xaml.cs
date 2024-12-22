using DentalClinicGUI.Services;
using DentalClinicGUI.Util;
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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ViewModels.Administrator;
using ViewModels.Doctor;

namespace DentalClinicGUI.Views.Administrator
{
    /// <summary>
    /// Interaction logic for AdminMainWindow.xaml
    /// </summary>
    public partial class AdminMainWindow : Window
    {
        public AdminMainWindow()
        {
            InitializeComponent();

            DataContext = new AdminMainViewModel(new AdminNavigationService(), this);

            SetUserPreferences();
        }

        public void SetUserPreferences()
        {
            AdminMainViewModel vm = (AdminMainViewModel)DataContext;

            Thread tPreferences = new Thread(() => {
                int count = 0, timeout = 0;
                int sleepTime = 500;
                while (true)
                {
                    Thread.Sleep(sleepTime);
                    timeout += sleepTime;

                    Language lang = vm.UserLanguage;
                    Theme theme = vm.UserTheme;
                    UserFont font = vm.UserFont;

                    if (lang != null)
                    {
                        string name = ResolveLanguage(lang.LanguageProperty.ToString());
                        AppLanguage.ChangeLanguage(new Uri($"Dictionaries/Languages/{name}.xaml", UriKind.Relative));
                        count++;
                    }
                    if (theme != null)
                    {
                        AppTheme.ChangeTheme(new Uri($"Dictionaries/Themes/{theme.ThemeProperty.ToString()}Theme.xaml", UriKind.Relative));
                        count++;
                    }
                    if (font != null)
                    {
                        AppFont.ChangeFont(font.FontName);
                        count++;
                    }

                    if (count > 0 && count <= 3)
                    {
                        break;
                    }
                    if (timeout == sleepTime * 60)  // stop the loop after certain time has passed - user had no set preferences
                    {
                        break;
                    }
                }
            });
            tPreferences.Start();
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
