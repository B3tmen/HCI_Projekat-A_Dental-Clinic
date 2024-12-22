using Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Util
{
    internal class AppointmentUtil
    {
        public static AppointmentStatusEnum GetStatusByName(string status)
        {
            if(string.Equals(status, AppointmentStatusEnum.Confirmed.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                return AppointmentStatusEnum.Confirmed; 
            }
            else if (string.Equals(status, AppointmentStatusEnum.Missed.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                return AppointmentStatusEnum.Missed;
            }
            else if (string.Equals(status, AppointmentStatusEnum.Cancelled.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                return AppointmentStatusEnum.Cancelled;
            }
            else
            {
                return AppointmentStatusEnum.Finished;
            }
        }
        
    }
}
