using Models.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dao.Interfaces
{
    public interface IDashboardDao : IDao<DashboardDto>
    {
        Task<int> GetAppointmentsTodayAsync(int doctorId);
        Task<int> GetActiveDoctorsAsync();
        Task<int> GetFinishedAppointmentsAsync();
        Task<int> GetCancelledAppointmentsAsync();
    }
}
