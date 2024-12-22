using System;
using System.Collections.Generic;
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
using ViewModels.Administrator;

namespace DentalClinicGUI.Views.Administrator.Windows
{
    /// <summary>
    /// Interaction logic for UpdateUserWindow.xaml
    /// </summary>
    public partial class UpdateUserWindow : Window
    {
        public UpdateUserWindow()
        {
            InitializeComponent();

            DataContext = new UpdateUserViewModel();
        }
    }
}
