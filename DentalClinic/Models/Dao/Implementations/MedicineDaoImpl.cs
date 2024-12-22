using Models.Dao.Interfaces;
using Models.Database;
using Models.Enums;
using Models.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dao.Implementations
{
    public class MedicineDaoImpl : IMedicineDao
    {
        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Medicine>> GetAllAsync()
        {
            List<Medicine> medicineList = new();
            string query = "SELECT * FROM medicine";

            try
            {
                using MySqlConnection conn = new DatabaseConnection().Connection;
                await conn.OpenAsync();

                using MySqlCommand command = new MySqlCommand(query, conn);
                using MySqlDataReader reader = (MySqlDataReader) await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    int medicineId = reader.GetInt32("medicine_id");
                    string name = reader.GetString("name");
                    int daysOfUse = reader.GetInt32("days_of_use");
                    int useTimesPerDay = reader.GetInt32("use_times_per_day");
                    DateTime expirationDate = reader.GetDateTime("expiration_date");
                    bool isUsable = reader.GetBoolean("is_usable");

                    Medicine medicine = new Medicine(medicineId, name, daysOfUse, useTimesPerDay, expirationDate, isUsable);
                    medicineList.Add(medicine);
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

            return medicineList;
        }

        public Task<Medicine> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> InsertAsync(Medicine entity)
        {
            string query = "CALL usp_AddMedicine(@name, @daysOfUse, @useTimesPerDay, @expirationDate)";
            try
            {
                using MySqlConnection conn = new DatabaseConnection().Connection;
                await conn.OpenAsync();

                using MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", entity.Name);
                cmd.Parameters.AddWithValue("@daysOfUse", entity.DaysOfUse);
                cmd.Parameters.AddWithValue("@useTimesPerDay", entity.UseTimesPerDay);
                cmd.Parameters.AddWithValue("@expirationDate", entity.ExpirationDate);

                await cmd.ExecuteNonQueryAsync();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }
        }

        public async Task<int> UpdateAsync(Medicine entity)
        {
            string query = "CALL usp_UpdateMedicine(@medicineId, @name, @daysOfUse, @useTimesPerDay, @expirationDate, @isUsable)";
            int updated = 0;
            try
            {
                using MySqlConnection conn = new DatabaseConnection().Connection;
                await conn.OpenAsync();

                using MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@medicineId", entity.MedicineId);
                cmd.Parameters.AddWithValue("@name", entity.Name);
                cmd.Parameters.AddWithValue("@daysOfUse", entity.DaysOfUse);
                cmd.Parameters.AddWithValue("@useTimesPerDay", entity.UseTimesPerDay);
                cmd.Parameters.AddWithValue("@expirationDate", entity.ExpirationDate);
                cmd.Parameters.AddWithValue("@isUsable", entity.IsUsable);

                updated = await cmd.ExecuteNonQueryAsync();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.StackTrace);
            }


            return updated;
        }
    }
}
