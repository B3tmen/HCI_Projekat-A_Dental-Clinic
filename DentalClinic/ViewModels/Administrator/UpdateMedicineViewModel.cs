using Models.Dao.Implementations;
using Models.Dao.Interfaces;
using Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using ViewModels.Services;
using ViewModels.Util;
using ViewModels.Commands;
using ViewModels.Interfaces;

namespace ViewModels.Administrator
{
    public class UpdateMedicineViewModel : ViewModelBase, IParameterReceiver
    {
        private Medicine _medicine;

        public UpdateMedicineViewModel()
        {
            _medicine = new Medicine();

            UpdateMedicineCommand = new RelayCommand(execute => OnUpdateMedicineAsync());
        }

        public ICommand UpdateMedicineCommand { get; }

        public Medicine Medicine
        {
            get => _medicine;
            set
            {
                _medicine = value;
                OnPropertyChanged(nameof(Medicine));
            }
        }


        private async void OnUpdateMedicineAsync()
        {
            if (CheckFieldsInserted())
            {
                MessageBoxResult userBoxAnswer = MessageBoxShower.ShowQuestionBox(LanguageService.GetString("Question_UpdateMedicine"), LanguageService.GetString("PressYes"));

                if (userBoxAnswer.Equals(MessageBoxResult.Yes))
                {
                    IMedicineDao dao = new MedicineDaoImpl();
                    int updated = await dao.UpdateAsync(Medicine);

                    if (updated > 0)
                    {
                        MessageBoxShower.ShowSuccessBox(LanguageService.GetString("Success_UpdateMedicine"), LanguageService.GetString("PressOK"));
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

            if (string.IsNullOrEmpty(Medicine.Name) || string.IsNullOrEmpty(Medicine.DaysOfUse.ToString()) || string.IsNullOrEmpty(Medicine.UseTimesPerDay.ToString()) || string.IsNullOrEmpty(Medicine.ExpirationDate.ToString()))
            {
                check = false;
            }
            else
            {
                check = true;
            }

            return check;
        }

        public void OnReceiveParameter(object parameter)
        {
            if(parameter != null && parameter is Medicine medicine)
            {
                Medicine = medicine.DeepCopy();
            }
        }
    }
}
