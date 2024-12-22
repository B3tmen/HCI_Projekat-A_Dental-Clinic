using Models.Dao.Interfaces;
using Models.Database;
using Models.Enums;
using Models.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dao.Implementations
{
    public class DoctorDaoImpl : IDoctorDao
    {
        public async Task<bool> ChangeFont(int id, UserFont font)
        {
            string query = "CALL usp_UpdateUserFont(@userId, @fontId)";
            try
            {
                using MySqlConnection conn = new DatabaseConnection().Connection;
                await conn.OpenAsync();

                using MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@userId", id);
                cmd.Parameters.AddWithValue("@fontId", font.Id);

                int updated = await cmd.ExecuteNonQueryAsync();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }
        }

        public async Task<bool> ChangeLanguage(int id, Language language)
        {
            string query = "CALL usp_UpdateUserLanguage(@userId, @languageId)";
            try
            {
                using MySqlConnection conn = new DatabaseConnection().Connection;
                await conn.OpenAsync();

                using MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@userId", id);
                cmd.Parameters.AddWithValue("@languageId", language.Id);

                await cmd.ExecuteNonQueryAsync();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }
        }

        public async Task<bool> ChangeTheme(int id, Theme theme)
        {
            string query = "CALL usp_UpdateUserTheme(@userId, @themeId)";
            try
            {
                using MySqlConnection conn = new DatabaseConnection().Connection;
                await conn.OpenAsync();

                using MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@userId", id);
                cmd.Parameters.AddWithValue("@themeId", theme.Id);

                await cmd.ExecuteNonQueryAsync();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Doctor>> GetAllAsync()
        {
            List<Doctor> doctors = new();
            string query = "SELECT * FROM vw_doctors";

            try
            {
                using MySqlConnection conn = new DatabaseConnection().Connection;
                await conn.OpenAsync();

                using MySqlCommand command = new MySqlCommand(query, conn);
                using MySqlDataReader reader = (MySqlDataReader) await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    int doctorId = reader.GetInt32("doctor_id");
                    string username = reader.GetString("username");
                    string passwordHash = reader.GetString("password_hash");
                    string firstName = reader.GetString("first_name");
                    string lastName = reader.GetString("last_name");
                    string email = reader.GetString("email");
                    bool isActive = reader.GetBoolean("is_active");
                    int languageId = !reader.IsDBNull("fk_language_id") ? reader.GetInt32("fk_language_id") : 0;
                    int themeId = !reader.IsDBNull("fk_theme_id") ? reader.GetInt32("fk_theme_id") : 0;
                    int fontId = !reader.IsDBNull("fk_font_id") ? reader.GetInt32("fk_font_id") : 0;

                    string specialization = reader.GetString("specialization");
                    string phoneNumber = reader.GetString("phone_number");
                    string gender = reader.GetString("gender");
                    decimal salary = reader.GetDecimal("salary");

                    bool isMale = string.Equals(gender, Gender.Male.ToString(), StringComparison.OrdinalIgnoreCase);

                    Doctor doctor = new(doctorId, username, passwordHash, firstName, lastName, email, isActive, languageId, themeId, fontId, specialization, phoneNumber, isMale ? Gender.Male : Gender.Female, salary);   // TODO: maybe better construction with theme/language IDs?

                    doctors.Add(doctor);
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

            return doctors;
        }

        public Task<Doctor> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertAsync(Doctor entity)
        {
            throw new NotImplementedException();
        }

        public async Task<int> UpdateAsync(Doctor entity)
        {
            int updated = 0;
            string query = "CALL usp_UpdateDoctor(@userId, @username, @password, @firstName, @lastName, @email, @isActive, @specialization, @phoneNumber, @gender, @salary)";
            try
            {
                using MySqlConnection conn = new DatabaseConnection().Connection;
                await conn.OpenAsync();

                using MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@userId", entity.UserId);
                cmd.Parameters.AddWithValue("@username", entity.Username);
                cmd.Parameters.AddWithValue("@password", entity.Password);
                cmd.Parameters.AddWithValue("@firstName", entity.FirstName);
                cmd.Parameters.AddWithValue("@lastName", entity.LastName);
                cmd.Parameters.AddWithValue("@email", entity.Email);
                cmd.Parameters.AddWithValue("@isActive", entity.IsActive);
                cmd.Parameters.AddWithValue("@specialization", entity.Specialization);
                cmd.Parameters.AddWithValue("@phoneNumber", entity.PhoneNumber);
                cmd.Parameters.AddWithValue("@gender", entity.Gender);
                cmd.Parameters.AddWithValue("@salary", entity.Salary);

                updated = await cmd.ExecuteNonQueryAsync();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.StackTrace);
            }

            return updated;
        }
    }
}
