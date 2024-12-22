using DentalClinicGUI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using ViewModels.Doctor;

namespace DentalClinicGUI.Views.Doctor.Pages
{
    /// <summary>
    /// Interaction logic for AppointmentsPage.xaml
    /// </summary>
    public partial class AppointmentsPage : Page
    {
        public AppointmentsPage()
        {
            InitializeComponent();

            DataContext = new AppointmentViewModel(new DoctorNavigationService());
        }
    }
}
