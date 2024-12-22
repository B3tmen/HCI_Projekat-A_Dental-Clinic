using Models.Dao.Implementations;
using Models.Dao.Interfaces;
using Models.Database;
using Models.Model.Dto;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViewModels.Interfaces;

namespace ViewModels.Doctor
{
    public class DashboardViewModel : ViewModelBase, IParameterReceiver
    {
        private int _doctorId;

        private int _appointmentsToday;
        private int _activeDoctors;
        private int _completedAppointments;
        private int _cancelledAppointments;

        public DashboardViewModel() {
        }

        public int AppointmentsToday {
            get => _appointmentsToday;

            set
            {
                _appointmentsToday = value;
                OnPropertyChanged(nameof(AppointmentsToday));
            }
        }
        public int ActiveDoctors {  
            get => _activeDoctors; 

            set
            {
                _activeDoctors = value;
                OnPropertyChanged(nameof(ActiveDoctors));
            }
        }
        public int CompletedAppointments {  
            get => _completedAppointments; 

            set
            {
                _completedAppointments = value;
                OnPropertyChanged(nameof(CompletedAppointments));
            }
        } 
        public int CancelledAppointments {  
            get => _cancelledAppointments; 

            set
            {
                _cancelledAppointments = value;
                OnPropertyChanged(nameof(CancelledAppointments));
            }
        }


        private async void SetupProperties()
        {
            IDashboardDao dao = new DashboardDaoImpl();
            
            AppointmentsToday = await dao.GetAppointmentsTodayAsync(_doctorId);
            ActiveDoctors = await dao.GetActiveDoctorsAsync();
            CompletedAppointments = await dao.GetFinishedAppointmentsAsync();
            CancelledAppointments = await dao.GetCancelledAppointmentsAsync();

        }

        public void OnReceiveParameter(object parameter)
        {
            if(parameter != null && parameter is Models.Model.Doctor doctor)
            {
                _doctorId = doctor.UserId;
            }

            SetupProperties();
        }
    }
}
