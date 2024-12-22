using Models.Dao.Implementations;
using Models.Dao.Interfaces;
using Models.Enums;
using Models.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Navigation;
using ViewModels.Commands;
using ViewModels.Interfaces;
using ViewModels.Util;

namespace ViewModels.Doctor
{
    public class PatientsViewModel : ViewModelBase
    {
        private int                             _patientsCount;
        private INavigationService              _navigationService;
        private ObservableCollection<Patient>   _patientCollection;
        private TextSearchMechanism<Patient>    _searchMechanism;
        private Patient                         _selectedPatient;

        public PatientsViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            PatientsCollection = new();
            _searchMechanism = new TextSearchMechanism<Patient>(PatientsCollection, patient => patient.LastName);

            ShowPatientWindowCommand = new RelayCommand(execute => OnShowPatientWindow());
            ShowTreatmentWindowCommand = new RelayCommand(execute => OnShowTreatmentWindow());
            RefreshCommand = new RelayCommand(execute => OnRefreshPatients());

            LoadPatients();
        }

        public ICommand ShowPatientWindowCommand    { get; init; }
        public ICommand ShowTreatmentWindowCommand  { get; init; }
        public ICommand RefreshCommand              { get; init; }

        public int PatientsCount
        {
            get => _patientsCount;
            set
            {
                _patientsCount = value;
                OnPropertyChanged(nameof(PatientsCount));
            }
        }

        public string SearchText
        {
            get => _searchMechanism.FilterText;
            set
            {
                if(_searchMechanism.FilterText != value)
                {
                    _searchMechanism.FilterText = value;
                    OnPropertyChanged(nameof(SearchText));
                }
            }
        }

        public ObservableCollection<Patient> PatientsCollection
        {
            get => _patientCollection;
            set
            {
                _patientCollection = value;
                OnPropertyChanged(nameof(PatientsCollection));
            }
        }

        public Patient SelectedPatient 
        {
            get => _selectedPatient;
            set
            {
                if(_selectedPatient != value)
                {
                    _selectedPatient = value;
                    OnPropertyChanged(nameof(SelectedPatient));
                    OnPropertyChanged(nameof(IsItemSelected));
                }
            }
        }

        public bool IsItemSelected => SelectedPatient != null;


        private void OnShowPatientWindow()
        {
            _navigationService.NavigateToWindow("AddPatientWindow");
        }

        private void OnShowTreatmentWindow()
        {
            _navigationService.NavigateToWindow("AddTreatmentWindow", SelectedPatient);
        }

        private void OnRefreshPatients()
        {
            LoadPatients();
        }

        private async void LoadPatients()
        {
            IPatientDao dao = new PatientDaoImpl();
            List<Patient> patientList = await dao.GetAllAsync();

            PatientsCollection.Clear();
            if (patientList != null)
            {
                foreach (var item in patientList)
                {
                    PatientsCollection.Add(item);
                }
                PatientsCount = PatientsCollection.Count;
            }
        }
    }
}
