using Models.Dao.Implementations;
using Models.Dao.Interfaces;
using Models.Enums;
using Models.Model;
using Models.Model.Dto;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ViewModels.Commands;
using ViewModels.Interfaces;
using ViewModels.Util;

namespace ViewModels.Doctor
{
    public class AppointmentViewModel : ViewModelBase
    {
        private INavigationService                      _navigationService;
        private ObservableCollection<AppointmentDto>    _appointmentsCollection;
        private int                                     _appointmentsTodayCount;
        private AppointmentDto                          _selectedAppointment;
        private TextSearchMechanism<AppointmentDto>     _searchMechanism;

        public AppointmentViewModel(INavigationService navigationService) {
            _navigationService = navigationService;
            _appointmentsCollection = new();
            _selectedAppointment = new();
            _searchMechanism = new TextSearchMechanism<AppointmentDto>(AppointmentsCollection, appointment => appointment.DoctorName);

            AddAppointmentCommand = new RelayCommand(execute => OnAddAppointment());
            RefreshCommand = new RelayCommand(execute => OnRefreshAppointments());
            
            SetupAppointmentsCollection();
        }

        public ICommand AddAppointmentCommand   { get; init; }
        public ICommand RefreshCommand          { get; init; }

        public ObservableCollection<AppointmentDto> AppointmentsCollection
        {
            get => _appointmentsCollection;
            set
            {
                _appointmentsCollection = value;
                OnPropertyChanged(nameof(AppointmentsCollection));
            }
        }

        public AppointmentDto SelectedAppointment
        {
            get => _selectedAppointment;
            set
            {
                _selectedAppointment = value;
                OnPropertyChanged(nameof(SelectedAppointment));
            }
        }

        public string SearchText
        {
            get => _searchMechanism.FilterText;
            set
            {
                if (_searchMechanism.FilterText != value)
                {
                    _searchMechanism.FilterText = value;
                    OnPropertyChanged(nameof(SearchText));
                }
            }
        }

        public int AppointmentsTodayCount
        {
            get => _appointmentsTodayCount;
            set
            {
                _appointmentsTodayCount = value;
                OnPropertyChanged(nameof(AppointmentsTodayCount));
            }
        }

        
        private void OnAddAppointment() 
        {
            _navigationService.NavigateToWindow("AddAppointmentWindow");

            //MessageBoxShower.ShowQuestionBox("title", $"drName: {SelectedAppointment.DoctorName}");
        }

        private void OnRefreshAppointments()
        {
            LoadAppointmentsAsync();
            CalculateTodayAppointments();
        }

        private void SetupAppointmentsCollection()
        {
            LoadAppointmentsAsync();
            CalculateTodayAppointments();
        }


        private async void LoadAppointmentsAsync()
        {
            IAppointmentDao dao = new AppointmentDaoImpl();
            List<AppointmentDto> appointmentDtos = await dao.GetAppointments();

            AppointmentsCollection.Clear();
            foreach (var appointment in appointmentDtos)
            {
                AppointmentsCollection.Add(appointment);
            }
        }

        private void CalculateTodayAppointments()
        {
            int counter = 0;
            if(AppointmentsCollection.Count > 0)
            {
                var now = DateTime.Now;
                foreach(var appointment in AppointmentsCollection)
                {
                    if (appointment.ReservationTime.Date.Equals(now.Date) && appointment.AppointmentStatus.Equals(AppointmentStatusEnum.Confirmed))
                    {
                        counter++;
                    }
                }
            }

            AppointmentsTodayCount = counter;
        }
    }
}
