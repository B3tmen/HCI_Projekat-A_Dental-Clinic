using Models.Dao.Interfaces;
using Models.Database;
using Models.Model;
using Models.Model.Dto;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dao.Implementations
{
    public class DashboardDaoImpl : IDashboardDao
    {
        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }


        public Task<List<DashboardDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }


        public Task<DashboardDto> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertAsync(DashboardDto entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(DashboardDto entity)
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetAppointmentsTodayAsync(int doctorId)
        {
            string query = "CALL usp_GetTodayAppointmentsCount(@doctorId)";
            int appointmentsTodayCount = 0;
            try
            {
                using MySqlConnection conn = new DatabaseConnection().Connection;
                await conn.OpenAsync();

                using MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@doctorId", doctorId);

                using MySqlDataReader reader = (MySqlDataReader) await cmd.ExecuteReaderAsync();
                if (await reader.ReadAsync())
                {
                    appointmentsTodayCount = reader.GetInt32("today_appointments");
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.StackTrace);
            }

            return appointmentsTodayCount;
        }

        public async Task<int> GetActiveDoctorsAsync()
        {
            string query = "CALL usp_GetActiveDoctorsCount()";
            int activeDoctorsCount = 0;
            try
            {
                using MySqlConnection conn = new DatabaseConnection().Connection;
                await conn.OpenAsync();

                using MySqlCommand cmd = new MySqlCommand(query, conn);

                using MySqlDataReader reader = (MySqlDataReader) await cmd.ExecuteReaderAsync();
                if(await reader.ReadAsync())
                {
                    activeDoctorsCount = reader.GetInt32("active_doctors_count");
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.StackTrace);
            }

            return activeDoctorsCount;
        }
        public async Task<int> GetFinishedAppointmentsAsync()
        {
            string query = "CALL usp_GetFinishedAppointmentsCount()";
            int finishedAppointmentsCount = 0;
            try
            {
                using MySqlConnection conn = new DatabaseConnection().Connection;
                await conn.OpenAsync();

                using MySqlCommand cmd = new MySqlCommand(query, conn);

                using MySqlDataReader reader = (MySqlDataReader) await cmd.ExecuteReaderAsync();
                if (await reader.ReadAsync())
                {
                    finishedAppointmentsCount = reader.GetInt32("finished_appointments");
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.StackTrace);
            }

            return finishedAppointmentsCount;
        }

        public async Task<int> GetCancelledAppointmentsAsync()
        {
            string query = "CALL usp_GetCancelledAppointmentsCount()";
            int cancelledAppointmentsCount = 0;
            try
            {
                using MySqlConnection conn = new DatabaseConnection().Connection;
                await conn.OpenAsync();

                using MySqlCommand cmd = new MySqlCommand(query, conn);

                using MySqlDataReader reader = (MySqlDataReader)await cmd.ExecuteReaderAsync();
                if (await reader.ReadAsync())
                {
                    cancelledAppointmentsCount = reader.GetInt32("cancelled_appointments");
                }

            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.StackTrace);
            }

            return cancelledAppointmentsCount;
        }

    }
}
