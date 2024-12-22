using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Model.Dto
{
    public class DashboardDto
    {
        public int AppointmentsTodayCount       { get; set; }  
        public int ActiveDoctorsCount           { get; set; }
        public int FinishedAppointmentsCount    { get; set; }
        public int CancelledAppointmentsCount   { get; set; }
    }
}
