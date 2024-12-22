using Google.Protobuf.WellKnownTypes;
using Models.Dao.Implementations;
using Models.Dao.Interfaces;
using Models.Enums;
using Models.Model;
using Models.Model.Dto;
using Org.BouncyCastle.Math.EC;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using ViewModels.Commands;
using ViewModels.Interfaces;
using ViewModels.Services;
using ViewModels.Util;

namespace ViewModels.Doctor
{
    public class AddAppointmentViewModel : ViewModelBase
    {
        private DateTime    _appointmentDate;
        private DateTime    _appointmentTime;
        private Patient     _selectedPatient;
        private bool        _isConfirmed;
        private bool        _isMissed;
        private bool        _isCancelled;
        private bool        _isFinished;

        private string                                  _selectedDoctorName;
        private Models.Model.Doctor                     _selectedDoctor;

        private ObservableCollection<string>            _doctorNamesCollection;
        private Dictionary<string, Models.Model.Doctor> _doctors;
        private ObservableCollection<Patient>           _patientCollection;

        public AddAppointmentViewModel() {
            InitializeEverything();

            AddAppointmentCommand = new RelayCommand(execute => OnAddAppointment());

            SetupDoctorNamesAsync();
            SetupPatientCollectionAsync();
        }


        #region Properties
        public ICommand AddAppointmentCommand { get; }

        public DateTime AppointmentDate
        {
            get => _appointmentDate;

            set
            {
                _appointmentDate = value;
                OnPropertyChanged(nameof(AppointmentDate));
            }
        }

        public DateTime AppointmentTime
        {
            get => _appointmentTime;

            set
            {
                _appointmentTime = value;
                OnPropertyChanged(nameof(AppointmentTime));
            }
        }

        public Patient SelectedPatient
        {
            get => _selectedPatient;

            set
            {
                _selectedPatient = value;
                OnPropertyChanged(nameof(SelectedPatient));
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

        public bool IsConfirmed
        {
            get => _isConfirmed;

            set
            {
                _isConfirmed = value;
                OnPropertyChanged(nameof(IsConfirmed));
            }
        }

        public bool IsMissed
        {
            get => _isMissed;

            set
            {
                _isMissed = value;
                OnPropertyChanged(nameof(IsMissed));
            }
        }

        public bool IsCancelled
        {
            get => _isCancelled;

            set
            {
                _isCancelled = value;
                OnPropertyChanged(nameof(IsCancelled));
            }
        }

        public bool IsFinished
        {
            get => _isFinished;

            set
            {
                _isFinished = value;
                OnPropertyChanged(nameof(IsFinished));
            }
        }

        public ObservableCollection<string> DoctorNamesCollection
        {
            get => _doctorNamesCollection;

            set
            {
                _doctorNamesCollection = value;
                OnPropertyChanged(nameof(DoctorNamesCollection));
            }
        }

        public string SelectedDoctorName
        {
            get => _selectedDoctorName;

            set
            {
                _selectedDoctorName = value;
                OnPropertyChanged(nameof(SelectedDoctorName));

                _doctors.TryGetValue(_selectedDoctorName, out _selectedDoctor);
            }
        }

        public Models.Model.Doctor SelectedDoctor { get => _selectedDoctor; }

        #endregion

        private void InitializeEverything()
        {
            IsConfirmed = true;
            IsMissed = false;
            IsCancelled = false;
            IsFinished = false;
            AppointmentDate = DateTime.Now;
            AppointmentTime = DateTime.Now;

            _selectedPatient = new();
            _selectedDoctor = new();
            _selectedDoctorName = string.Empty;
            _doctorNamesCollection = new();
            _doctors = new();
            _patientCollection = new();
        }

        private async void OnAddAppointment()
        {
            AppointmentStatus status = ResolveStatus();
            DateTime dateTime = new DateTime(AppointmentDate.Year, AppointmentDate.Month, AppointmentDate.Day, AppointmentTime.Hour, AppointmentTime.Minute, AppointmentTime.Second);
            DateTime now = DateTime.Now;
            if(dateTime <= now)
            {
                MessageBoxShower.ShowErrorBox(LanguageService.GetString("Error"), LanguageService.GetString("Error_AppointmentDate"));
            }
            else
            {
                MessageBoxResult answer = MessageBoxShower.ShowQuestionBox(LanguageService.GetString("Question_AddAppointment"), LanguageService.GetString("PressYes"));
                if (answer == MessageBoxResult.Yes)
                {
                    IAppointmentDao dao = new AppointmentDaoImpl();
                    Appointment appointment = new Appointment(0, SelectedPatient.PatientId, SelectedDoctor.UserId, dateTime, status);     // id not important for insert, in the database its auto-incremented anyway
                    Console.WriteLine(appointment);
                    
                    bool inserted = await dao.InsertAsync(appointment);

                    if (inserted)
                    {
                        MessageBoxShower.ShowSuccessBox(LanguageService.GetString("Success_AddAppointment"), LanguageService.GetString("PressOK"));

                        //AppointmentDto appointmentDto = new AppointmentDto()
                        //{
                        //    AppointmentId = appointment.AppointmentId, PatientId = appointment.PatientId, DoctorName = SelectedDoctor.FirstName + " " + SelectedDoctor.LastName,
                        //    FirstName = SelectedPatient.FirstName, LastName = SelectedPatient.LastName, DateOfBirth = SelectedPatient.DateOfBirth,
                        //    Gender = SelectedPatient.Gender, PhoneNumber = SelectedPatient.PhoneNumber, Email = SelectedPatient.Email, AppointmentStatus = status.Status,
                        //    ReservationTime = dateTime
                        //};
                    }
                    else
                    {
                        MessageBoxShower.ShowErrorBox(LanguageService.GetString("Error"), LanguageService.GetString("TryAgain"));
                    }
                }
            }

           
        }

        private AppointmentStatus ResolveStatus()
        {
            var status =    IsConfirmed ? AppointmentStatusEnum.Confirmed   :
                            IsMissed    ? AppointmentStatusEnum.Missed      :
                            IsCancelled ? AppointmentStatusEnum.Cancelled   :
                            AppointmentStatusEnum.Finished;

            return new AppointmentStatus(((int) status)+1, status);
        }

        private async void SetupDoctorNamesAsync()
        {
            IDoctorDao dao = new DoctorDaoImpl();
            List<Models.Model.Doctor> doctors = await dao.GetAllAsync();

            foreach (var doctor in doctors)
            {
                string doctorName = $"Dr {doctor.FirstName} {doctor.LastName}";
                _doctors.Add(doctorName, doctor);

                DoctorNamesCollection.Add(doctorName);
            }
        }

        private async void SetupPatientCollectionAsync()
        {
            IPatientDao dao = new PatientDaoImpl();
            List<Patient> patients = await dao.GetAllAsync();

            foreach (var patient in patients)
            {
                PatientsCollection.Add(patient);
            }
        }
    }
}
