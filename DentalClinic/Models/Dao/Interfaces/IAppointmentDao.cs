using Models.Model;
using Models.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dao.Interfaces
{
    public interface IAppointmentDao : IDao<Appointment>
    {
        public Task<List<AppointmentDto>> GetAppointments();
        public Task<int> GetLastAppointmentIdAsync();
    }
}
