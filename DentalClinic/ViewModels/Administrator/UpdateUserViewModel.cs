using Models.Dao.Implementations;
using Models.Dao.Interfaces;
using Models.Enums;
using Models.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ViewModels.Commands;
using ViewModels.Interfaces;
using ViewModels.Services;
using ViewModels.Util;

namespace ViewModels.Administrator
{
    public class UpdateUserViewModel : ViewModelBase, IParameterReceiver
    {
        private User                _user;
        private Models.Model.Doctor _doctor;
        private Gender _selectedGender;
        private bool _isDoctorSelected;


        public UpdateUserViewModel()
        {
            GenderItems = new();

            UpdateUserCommand = new RelayCommand(execute => OnUpdateUser());

            SetupGenderCollection();
        }

        public ICommand UpdateUserCommand { get; init; }

        public User User
        {
            get => _user;
            set
            {
                _user = value;
                OnPropertyChanged(nameof(User));
            }
        }

        public Models.Model.Doctor Doctor
        {
            get => _doctor;
            set
            {
                _doctor = value;
                OnPropertyChanged(nameof(Doctor));
            }
        }

        public ObservableCollection<Gender> GenderItems { get; set; }

        public bool IsDoctorSelected
        {
            get => _isDoctorSelected;
            set
            {
                _isDoctorSelected = value;
                OnPropertyChanged(nameof(IsDoctorSelected));
            }
        }


        private void SetupGenderCollection()
        {
            GenderItems.Add(Gender.Male);
            GenderItems.Add(Gender.Female);
        }

        private void ResetObjects()
        {
            if(User != null) User.ResetFields();
            if(Doctor != null) Doctor.ResetFields();

            IsDoctorSelected = false;
        }

        private async void OnUpdateUser()
        {
            if (CheckEmptyFields())
            {
                var answer = MessageBoxShower.ShowQuestionBox(LanguageService.GetString("Question_UpdateUser"), LanguageService.GetString("PressYes"));
                if(answer == MessageBoxResult.Yes)
                {
                    int updated = 0;
                    if(User is Models.Model.Doctor doctor)
                    {
                        IDoctorDao dao = new DoctorDaoImpl();
                        updated = await dao.UpdateAsync(doctor);
                    }
                    else
                    {
                        IUserDao dao = new UserDaoImpl();
                        updated = await dao.UpdateAsync(User);
                    }

                    if (updated > 0)
                    {
                        MessageBoxShower.ShowSuccessBox(LanguageService.GetString("Success_UpdateUser"), LanguageService.GetString("PressOK"));
                    }
                }
            }
        }

        public void OnReceiveParameter(object parameter)
        {
            ResetObjects(); // because of static reading of windows, the values of old objects remain

            if(parameter != null && parameter is User user)
            {
                User = user.DeepCopy();     // we don't want to change the original objects sent as parameters and mutate the data of the table row, that is, no 'side-effects'

                if(user is Models.Model.Doctor doctor)
                {
                    Doctor = (Models.Model.Doctor) doctor.DeepCopy();
                    IsDoctorSelected = true;
                }
            }
        }

        private bool CheckEmptyFields()
        {
            bool check = true;

            if (string.IsNullOrEmpty(User.Username) || string.IsNullOrEmpty(User.Password) || string.IsNullOrEmpty(User.FirstName) || string.IsNullOrEmpty(User.LastName) ||
               string.IsNullOrEmpty(User.Email))
            {

                MessageBoxShower.ShowErrorBox(LanguageService.GetString("Error_UserEmptyFields"), LanguageService.GetString("TryAgain"));
                check = false;

            }
            if (IsDoctorSelected)
            {
                if (string.IsNullOrEmpty(Doctor.Specialization) || string.IsNullOrEmpty(Doctor.PhoneNumber) || Doctor.Salary == 0)
                {
                    MessageBoxShower.ShowErrorBox(LanguageService.GetString("Error_DoctorEmptyFields"), LanguageService.GetString("TryAgain"));
                    check = false;
                }
            }

            return check;
        }
    }
}
