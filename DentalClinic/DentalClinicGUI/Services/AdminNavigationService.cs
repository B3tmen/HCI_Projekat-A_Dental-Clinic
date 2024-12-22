using DentalClinicGUI.Util;
using DentalClinicGUI.Views.Administrator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Interfaces;
using System.Windows;
using System.Windows.Controls;
using DentalClinicGUI.Views.Administrator.Pages;
using DentalClinicGUI.Views.Administrator.Windows;
using System.Globalization;
using System.Windows.Markup;
using DentalClinicGUI.Views.Doctor;

namespace DentalClinicGUI.Services
{
    class AdminNavigationService : INavigationService
    {
        private static Dictionary<string, Window>   s_windows = new();
        private static Dictionary<string, Page>     s_pages = new();
        
        private Window _currentWindow;
        private Page _currentPage;

        static AdminNavigationService()
        {
            SetupNavigationService();
        }

        public AdminNavigationService()
        {
            _currentWindow = new Window();
            _currentPage = new Page();
        }

        public static void SetupNavigationService()
        {
            SetupWindows();
            SetupPages();
        }


        private static void SetupWindows()
        {
            s_windows.Add(WindowNames.LoginWindow, new LoginWindow());
            s_windows.Add(WindowNames.AdminMainWindow, new AdminMainWindow());
            s_windows.Add(WindowNames.AddUserWindow, new AddUserWindow());
            s_windows.Add(WindowNames.UpdateUserWindow, new UpdateUserWindow());
            s_windows.Add(WindowNames.AddMedicineWindow, new AddMedicineWindow());
            s_windows.Add(WindowNames.UpdateMedicineWindow, new UpdateMedicineWindow());
        }

        private static void SetupPages()
        {
            s_pages.Add(WindowNames.UsersPage, new UsersPage());
            s_pages.Add(WindowNames.StoragePage, new StoragePage());
            s_pages.Add(WindowNames.SettingsPage, new SettingsPage());
        }

        private void HandleClosingWindow(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            _currentWindow.Hide();
        }

        public void NavigateToWindow(string windowName, object parameter = null)
        {
            if (s_windows.TryGetValue(windowName, out _currentWindow))
            {
                if (_currentWindow.DataContext is IParameterReceiver receiver)
                {
                    receiver.OnReceiveParameter(parameter);
                }

                if (_currentWindow is AdminMainWindow)
                {
                    Application.Current.MainWindow = _currentWindow;    // We're doing this so we can mark the main part of the app so we can shutdown all the other child windows when the user closes the main window
                }
                else if (_currentWindow is LoginWindow)     // if logging out
                {
                    Application.Current.MainWindow = _currentWindow;
                }
                else
                {
                    _currentWindow.Closing += HandleClosingWindow;      // so the window doesn't close actually, and that way can be reopened - we just hide it (else an InvalidOperationException can occur)
                }

                _currentWindow.Show();
            }
            else
            {
                throw new ArgumentException("Invalid window name");
            }
        }

        public Page NavigateToPage(string pageName, object parameter = null)
        {
            if (s_pages.TryGetValue(pageName, out _currentPage))
            {
                if (_currentPage.DataContext is IParameterReceiver receiver)
                {
                    receiver.OnReceiveParameter(parameter);
                }

                return _currentPage;
            }
            else
            {
                throw new ArgumentException("Invalid page name");
            }

        }
    }
}
