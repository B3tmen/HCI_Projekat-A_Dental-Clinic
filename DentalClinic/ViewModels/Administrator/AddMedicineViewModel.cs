using Models.Dao.Implementations;
using Models.Dao.Interfaces;
using Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ViewModels.Commands;
using ViewModels.Services;
using ViewModels.Util;

namespace ViewModels.Administrator
{
    public class AddMedicineViewModel : ViewModelBase
    {
        private Medicine _medicine;

        public AddMedicineViewModel()
        {
            _medicine = new Medicine();

            AddMedicineCommand = new RelayCommand(execute => OnAddMedicineAsync());
        }

        public ICommand AddMedicineCommand { get; }

        public Medicine Medicine
        {
            get => _medicine;
            set
            {
                _medicine = value;
                OnPropertyChanged(nameof(Medicine));
            }
        }


        private async void OnAddMedicineAsync()
        {
            if (CheckFieldsInserted())
            {
                MessageBoxResult userBoxAnswer = MessageBoxShower.ShowQuestionBox(LanguageService.GetString("Question_AddMedicine"), LanguageService.GetString("PressOK"));

                if (userBoxAnswer.Equals(MessageBoxResult.Yes))
                {
                    IMedicineDao dao = new MedicineDaoImpl();
                    bool inserted = await dao.InsertAsync(Medicine);

                    if (inserted)
                    {
                        MessageBoxShower.ShowSuccessBox(LanguageService.GetString("Sucess_AddMedicine"), LanguageService.GetString("PressOK"));
                    }    
                }
            }
            else
            {
                MessageBoxShower.ShowErrorBox(LanguageService.GetString("Error_EmptyFields"), LanguageService.GetString("ErrorOccured"));
            }
        }


        // TODO: fix input fields checking
        private bool CheckFieldsInserted()
        {
            bool check = false;

            if (string.IsNullOrEmpty(Medicine.Name) || string.IsNullOrEmpty(Medicine.DaysOfUse.ToString()) || string.IsNullOrEmpty(Medicine.UseTimesPerDay.ToString()) || string.IsNullOrEmpty(Medicine.ExpirationDate.ToString()) )
            {
                check = false;
            }
            else
            {
                check = true;
            }

            return check;
        }
    }
}
