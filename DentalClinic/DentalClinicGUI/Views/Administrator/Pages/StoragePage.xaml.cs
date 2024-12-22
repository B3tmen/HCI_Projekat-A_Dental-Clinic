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
    /// Interaction logic for StoragePage.xaml
    /// </summary>
    public partial class StoragePage : Page
    {
        public StoragePage()
        {
            InitializeComponent();

            DataContext = new StorageViewModel(new AdminNavigationService());
        }

        private async void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is ToggleButton toggleButton && toggleButton.Tag is Medicine medicine)
            {
                MessageBoxResult answer = MessageBoxResult.No;
                if (medicine.IsUsable)
                {
                    answer = MessageBoxShower.ShowQuestionBox(LanguageService.GetString("Question_MedicineUnusableStatus"), LanguageService.GetString("PressYes"));
                    if (answer == MessageBoxResult.Yes)
                    {
                        medicine.IsUsable = !medicine.IsUsable;

                        IMedicineDao dao = new MedicineDaoImpl();
                        int updated = await dao.UpdateAsync(medicine);
                        if (updated > 0)
                        {
                            MessageBoxShower.ShowSuccessBox(LanguageService.GetString("Success_MedicineUnusableStatus"), LanguageService.GetString("PressOK"));
                        }
                    }
                    else
                    {
                        toggleButton.IsChecked = true;
                    }
                }
                else
                {
                    answer = MessageBoxShower.ShowQuestionBox(LanguageService.GetString("Question_MedicineUsableStatus"), LanguageService.GetString("PressYes"));
                    if (answer == MessageBoxResult.Yes)
                    {
                        medicine.IsUsable = !medicine.IsUsable;

                        IMedicineDao dao = new MedicineDaoImpl();
                        int updated = await dao.UpdateAsync(medicine);
                        if (updated > 0)
                        {
                            MessageBoxShower.ShowSuccessBox(LanguageService.GetString("Success_MedicineUsableStatus"), LanguageService.GetString("PressOK"));
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
