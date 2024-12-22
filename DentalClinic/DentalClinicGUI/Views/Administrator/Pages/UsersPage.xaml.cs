using DentalClinicGUI.Services;
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
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ViewModels.Administrator;
using ViewModels.Services;
using ViewModels.Util;

namespace DentalClinicGUI.Views.Administrator.Pages
{
    /// <summary>
    /// Interaction logic for UsersPage.xaml
    /// </summary>
    public partial class UsersPage : Page
    {
        public UsersPage()
        {
            InitializeComponent();

            DataContext = new UsersViewModel(new AdminNavigationService());
        }

        // TODO: <Toggling status> Fix this / Find out about any alternative so it works with MVVM instead of being in code-behind
        private async void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is ToggleButton toggleButton && toggleButton.Tag is User user)
            {
                MessageBoxResult answer = MessageBoxResult.No;
                if (user.IsActive)
                {
                    answer = MessageBoxShower.ShowQuestionBox(LanguageService.GetString("Question_DeactivateStatus"), LanguageService.GetString("PressYes"));
                    if (answer == MessageBoxResult.Yes)
                    {
                        user.IsActive = !user.IsActive;
                        
                        IUserDao dao = new UserDaoImpl();
                        int updated = await dao.UpdateAsync(user);
                        if(updated > 0)
                        {
                            MessageBoxShower.ShowSuccessBox(LanguageService.GetString("Success_DeactivateStatus"), LanguageService.GetString("PressOK"));
                        }
                    }
                    else
                    {
                        toggleButton.IsChecked = true;
                    }
                }
                else
                {
                    answer = MessageBoxShower.ShowQuestionBox(LanguageService.GetString("Question_ActivateStatus"), LanguageService.GetString("PressYes"));
                    if (answer == MessageBoxResult.Yes)
                    {
                        user.IsActive = !user.IsActive;
                        
                        IUserDao dao = new UserDaoImpl();
                        int updated = await dao.UpdateAsync(user);
                        if (updated > 0)
                        {
                            MessageBoxShower.ShowSuccessBox(LanguageService.GetString("Success_ActivateStatus"), LanguageService.GetString("PressOK"));
                        }
                    }
                    else
                    {
                        toggleButton.IsChecked = false;
                    }
                }
            }
        }
    }
}
