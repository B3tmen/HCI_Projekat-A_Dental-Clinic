using DentalClinicGUI.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Shapes;
using ViewModels.Doctor;

namespace DentalClinicGUI.Views.Doctor.Pages
{
    /// <summary>
    /// Interaction logic for PatientsPage.xaml
    /// </summary>
    public partial class PatientsPage : Page
    {
        public PatientsPage()
        {
            InitializeComponent();

            //Stopwatch stopwatch = new Stopwatch();

            //stopwatch.Start();
            DataContext = new PatientsViewModel(new DoctorNavigationService());
            //stopwatch.Stop();

            //MessageBox.Show($"db time: {stopwatch.ElapsedMilliseconds}" );
        }
    }
}
