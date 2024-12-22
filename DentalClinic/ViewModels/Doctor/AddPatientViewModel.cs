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
using ViewModels.Services;
using ViewModels.Util;

namespace ViewModels.Doctor
{
    public class AddPatientViewModel : ViewModelBase
    {
        private Patient                         _patient;
        private ObservableCollection<Gender>    _genderCollection;

        public AddPatientViewModel() { 
            _patient = new();
            _genderCollection = new();

            AddPatientCommand = new RelayCommand(execute => OnAddPatient());

            SetupGenderCollection();
        }


        public ICommand AddPatientCommand { get; }

        public Patient Patient
        {
            get => _patient;
            set
            {
                _patient = value;
                OnPropertyChanged(nameof(Patient));
            }
        }

        public ObservableCollection<Gender> GenderCollection
        {
            get => _genderCollection;
            set
            {
                _genderCollection = value;
                OnPropertyChanged(nameof(GenderCollection));
            }
        }

        private void SetupGenderCollection()
        {
            _genderCollection.Add(Gender.Male);
            _genderCollection.Add(Gender.Female);
        }

        private async void OnAddPatient()
        {
            if (CheckFieldsInserted())
            {
                MessageBoxResult userBoxAnswer = MessageBoxShower.ShowQuestionBox(LanguageService.GetString("Question_AddPatient"), LanguageService.GetString("PressYes"));

                if (userBoxAnswer.Equals(MessageBoxResult.Yes))
                {
                    IPatientDao dao = new PatientDaoImpl();
                    bool inserted = await dao.InsertAsync(Patient);

                    if (inserted)
                    {
                        MessageBoxShower.ShowSuccessBox(LanguageService.GetString("Success_AddPatient"), LanguageService.GetString("PressOK"));
                    }
                    else
                    {
                        MessageBoxShower.ShowSuccessBox(LanguageService.GetString("Error"), LanguageService.GetString("TryAgain"));
                    }
                }
            }
            else
            {
                MessageBoxShower.ShowErrorBox(LanguageService.GetString("Error_EmptyFields"), LanguageService.GetString("ErrorOccured"));
            } 
        }

        // TODO: add more conditions
        private bool CheckFieldsInserted()
        {
            bool check = true;

            if(string.IsNullOrEmpty(Patient.FirstName) || string.IsNullOrEmpty(Patient.LastName) || string.IsNullOrEmpty(Patient.DateOfBirth.ToString()) || string.IsNullOrEmpty(Patient.Gender.ToString()) 
                || string.IsNullOrEmpty(Patient.PhoneNumber) || string.IsNullOrEmpty(Patient.Email))
            {
                check = false;
            }
            else if(Patient.DateOfBirth.Year <= (DateTime.Now.Year - 110) ) // whoever is reading this, I was too lazy to check if its not 01.01.0001 and some complex condition so i put this (xD)
            {
                check = false;
            }

            return check;
        }
    }
}
