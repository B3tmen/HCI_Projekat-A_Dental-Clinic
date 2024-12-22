using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Model
{
    public class Appointment
    {
        private int                 _appointmentId;
        private int                 _patientId;
        private int                 _doctorId;
        private DateTime            _dateTime;
        private AppointmentStatus   _status;


        public Appointment() { }

        public Appointment(int appointmentId, int patientId, int doctorId, DateTime date, AppointmentStatus status)
        {
            AppointmentId = appointmentId;
            PatientId = patientId;
            DoctorId = doctorId;
            DateTime = date;
            Status = status;
        }


        public int AppointmentId { get => _appointmentId; init { _appointmentId = value; } }
        public int PatientId { get => _patientId; set => _patientId = value; }
        public int DoctorId { get => _doctorId; set => _doctorId = value; }
        public DateTime DateTime { get => _dateTime; set => _dateTime = value; }
        public AppointmentStatus Status { get => _status; set => _status = value; }

        public override string ToString()
        {
            return $"AppointmentId: {AppointmentId}, patientId: {PatientId}, doctorId: {DoctorId}, dateTime: {DateTime}, status: {Status.Status.ToString()}";
        }
    }
}
