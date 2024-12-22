using Models.Dao.Implementations;
using Models.Dao.Interfaces;
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

namespace ViewModels.Doctor
{
    public class PaymentViewModel : ViewModelBase
    {
        private Patient                         _patient;
        private readonly INavigationService     _navigationService;
        private ObservableCollection<Patient>   _patientPaymentsCollection;

        public PaymentViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            _patientPaymentsCollection = new();

            ShowReceiptWindowCommand = new RelayCommand(execute => OnShowReceiptWindow());

            SetupPatientPaymentsAsync();
        }


        public ICommand ShowReceiptWindowCommand { get; init; }

        public Patient SelectedPatient
        {
            get => _patient;
            set
            {
                _patient = value;
                OnPropertyChanged(nameof(SelectedPatient));
            }
        }

        public ObservableCollection<Patient> PatientPaymentsCollection
        {
            get => _patientPaymentsCollection;
            set
            {
                _patientPaymentsCollection = value;
                OnPropertyChanged(nameof(PatientPaymentsCollection));
            }
        }


        private void OnShowReceiptWindow()
        {
            MessageBox.Show($"id: {SelectedPatient.PatientId}");
            _navigationService.NavigateToWindow("ReceiptWindow", SelectedPatient);
        }

        private async void SetupPatientPaymentsAsync()
        {
            IPatientDao dao = new PatientDaoImpl();
            List<Patient> patients = await dao.GetAllAsync();

            foreach(var patient in patients)
            {
                PatientPaymentsCollection.Add(patient);
            }
        }
    }
}
