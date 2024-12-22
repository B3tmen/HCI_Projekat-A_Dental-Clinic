using DentalClinicGUI.Util;
using DentalClinicGUI.Views.Administrator;
using DentalClinicGUI.Views.Doctor;
using DentalClinicGUI.Views.Doctor.Pages;
using DentalClinicGUI.Views.Doctor.Windows;
using System.ComponentModel;
using System.Printing;
using System.Windows;
using System.Windows.Controls;
using ViewModels.Interfaces;

namespace DentalClinicGUI.Services
{
    class DoctorNavigationService : INavigationService
    {
        private static Dictionary<string, Window>   s_windows = new();
        private static Dictionary<string, Page>     s_pages = new();
        private Window                              _currentWindow;
        private Page                                _currentPage;

        static DoctorNavigationService()
        {
            SetupNavigationService();
        }

        public DoctorNavigationService() {
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
            s_windows.Add(WindowNames.DoctorMainWindow, new DoctorMainWindow());
            s_windows.Add(WindowNames.AddAppointmentWindow, new AddAppointmentWindow());
            s_windows.Add(WindowNames.AddPatientWindow, new AddPatientWindow());
            s_windows.Add(WindowNames.AddMedicineWindow, new AddMedicineWindow());
            s_windows.Add(WindowNames.AddTreatmentWindow, new AddTreatmentWindow());
            s_windows.Add(WindowNames.ReceiptWindow, new ReceiptWindow());

            //((DoctorMainWindow)s_windows[WindowNames.DoctorMainWindow]).SetUserPreferences();   // TODO: remove comment
        }
        
        private static void SetupPages()
        {
            s_pages.Add(WindowNames.DashboardPage, new DashboardPage());
            s_pages.Add(WindowNames.AppointmentsPage, new AppointmentsPage());
            s_pages.Add(WindowNames.PatientsPage, new PatientsPage());
            s_pages.Add(WindowNames.DentistsPage, new DoctorsPage());
            s_pages.Add(WindowNames.MedicinePage, new MedicinePage());
            s_pages.Add(WindowNames.PaymentPage, new PaymentPage());
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

                if (_currentWindow is DoctorMainWindow)
                {
                    Application.Current.MainWindow = _currentWindow;    // We're doing this so we can mark the main part of the app so we can shutdown all the other child windows when the user closes the main window
                }
                else if (_currentWindow is LoginWindow)     // if logging out
                {
                    Application.Current.MainWindow = _currentWindow;
                }
                else
                {
                    _currentWindow.Closing += HandleClosingWindow;      // so the window doesn't close really, and that way can be reopened - we just hide it (else an InvalidOperationException can occur)
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
