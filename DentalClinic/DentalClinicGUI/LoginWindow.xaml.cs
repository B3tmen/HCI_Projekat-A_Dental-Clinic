using DentalClinicGUI.Services;
using System.Windows;
using ViewModels;
using ViewModels.Interfaces;

namespace DentalClinicGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();

            Dictionary<string, INavigationService> navigationServices = new();
            navigationServices.Add("AdminNavigationService", new AdminNavigationService());
            navigationServices.Add("DoctorNavigationService", new DoctorNavigationService());

            var loginVM = new LoginViewModel(navigationServices, this);
            DataContext = loginVM;
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
        }
    }
}