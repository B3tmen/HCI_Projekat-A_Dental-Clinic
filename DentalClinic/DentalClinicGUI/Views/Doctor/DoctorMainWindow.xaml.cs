using DentalClinicGUI.Services;
using DentalClinicGUI.Util;
using Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using ViewModels.Doctor;
using ViewModels.Util;

namespace DentalClinicGUI.Views.Doctor
{
    /// <summary>
    /// Interaction logic for DoctorMainWindow.xaml
    /// </summary>
    public partial class DoctorMainWindow : Window
    {

        public DoctorMainWindow()
        {
            InitializeComponent();

            DataContext = new DoctorMainViewModel(new DoctorNavigationService(), this);

            SetUserPreferences();
        }

        public void SetUserPreferences()
        {
            DoctorMainViewModel vm = (DoctorMainViewModel) DataContext;

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

                    if(lang != null)
                    {
                        string name = ResolveLanguage(lang.LanguageProperty.ToString());
                        AppLanguage.ChangeLanguage(new Uri($"Dictionaries/Languages/{name}.xaml", UriKind.Relative));
                        count++;
                    }
                    if(theme != null)
                    {
                        AppTheme.ChangeTheme(new Uri($"Dictionaries/Themes/{theme.ThemeProperty.ToString()}Theme.xaml", UriKind.Relative));
                        count++;
                    }
                    if(font != null)
                    {
                        AppFont.ChangeFont(font.FontName);
                        count++;
                    }

                    if(count > 0 && count <= 3)
                    {
                        break;
                    }
                    if(timeout == sleepTime*60)  // stop the loop after certain time has passed - user had no set preferences
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

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            //Application.Current.Shutdown();
        }
    }
}
