using Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Model
{
    public class AppointmentStatus
    {
        private int                     _statusId;
        private AppointmentStatusEnum   _status;

        public AppointmentStatus()
        {

        }

        public AppointmentStatus(int statusId, AppointmentStatusEnum status)
        {
            StatusId = statusId;
            Status = status;
        }

        public int StatusId { get => _statusId; init { _statusId = value; } }
        public AppointmentStatusEnum Status { get => _status; init { _status = value; } }
    }
}
