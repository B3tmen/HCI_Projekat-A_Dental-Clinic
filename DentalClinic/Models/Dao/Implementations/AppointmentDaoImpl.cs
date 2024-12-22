using Models.Dao.Interfaces;
using Models.Database;
using Models.Model;
using Models.Model.Dto;
using Models.Util;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dao.Implementations
{
    public class AppointmentDaoImpl : IAppointmentDao
    {
        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Appointment>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Appointment> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> InsertAsync(Appointment entity)
        {
            bool inserted = false;
            string query = "CALL usp_AddAppointment(@patientId, @doctorId, @dateTime, @appointmentStatusId)";
            try
            {
                using MySqlConnection conn = new DatabaseConnection().Connection;
                await conn.OpenAsync();

                using MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@patientId", entity.PatientId);
                cmd.Parameters.AddWithValue("@doctorId", entity.DoctorId);
                cmd.Parameters.AddWithValue("@dateTime", entity.DateTime);
                cmd.Parameters.AddWithValue("@appointmentStatusId", entity.Status.StatusId);

                int affected = await cmd.ExecuteNonQueryAsync();
                inserted = true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.StackTrace);
                inserted = false;
            }

            return inserted;
        }

        public Task<int> UpdateAsync(Appointment entity)
        {
            throw new NotImplementedException();
        }

        public async Task<List<AppointmentDto>> GetAppointments()
        {
            List<AppointmentDto> appointments = new();
            string query = "SELECT * FROM vw_appointments";

            try
            {
                using MySqlConnection conn = new DatabaseConnection().Connection;
                await conn.OpenAsync();

                using MySqlCommand cmd = new MySqlCommand(query, conn);
                using MySqlDataReader reader = (MySqlDataReader)await cmd.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    int appointmentId = reader.GetInt32("appointment_id");
                    int patientId = reader.GetInt32("patient_id");
                    string doctorName = reader.GetString("doctor_name");
                    string firstName = reader.GetString("first_name");
                    string lastName = reader.GetString("last_name");
                    DateTime dob = reader.GetDateTime("date_of_birth");
                    string gender = reader.GetString("gender");
                    string phoneNumber = reader.GetString("phone_number");
                    string email = reader.GetString("email");
                    DateTime reservationTime = reader.GetDateTime("reservation_time");
                    string status = reader.GetString("status");

                    AppointmentDto appointment = new AppointmentDto
                    {
                        AppointmentId = appointmentId,
                        PatientId = patientId,
                        DoctorName = doctorName,
                        FirstName = firstName,
                        LastName = lastName,
                        DateOfBirth = dob,
                        Gender = GenderUtil.GetByName(gender),
                        PhoneNumber = phoneNumber,
                        Email = email,
                        ReservationTime = reservationTime,
                        AppointmentStatus = AppointmentUtil.GetStatusByName(status)
                    };
                    appointments.Add(appointment);
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

            return appointments;
        }

        public async Task<int> GetLastAppointmentIdAsync()
        {
            string query = "CALL usp_GetLastAppointmentId()";
            int lastId = 0;
            try
            {
                using MySqlConnection conn = new DatabaseConnection().Connection;
                await conn.OpenAsync();

                using MySqlCommand cmd = new MySqlCommand(query, conn);
                using MySqlDataReader reader = (MySqlDataReader)await cmd.ExecuteReaderAsync();

                if (await reader.ReadAsync())
                {
                    lastId = reader.GetInt32("last_appointment_id");
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.StackTrace);
            }

            return lastId;
        }
    }
}
