using Google.Protobuf.Compiler;
using Models.Dao.Interfaces;
using Models.Database;
using Models.Enums;
using Models.Model;
using Models.Util;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dao.Implementations
{
    public class PatientDaoImpl : IPatientDao
    {
        async Task<bool> IDao<Patient>.InsertAsync(Patient entity)
        {
            string query = "CALL usp_AddPatient(@firstName, @lastName, @dateOfBirth, @gender, @phoneNumber, @email)";
            try
            {
                using MySqlConnection conn = new DatabaseConnection().Connection;
                await conn.OpenAsync();

                using MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@firstName", entity.FirstName);
                cmd.Parameters.AddWithValue("@lastName", entity.LastName);
                cmd.Parameters.AddWithValue("@dateOfBirth", entity.DateOfBirth.Date);
                cmd.Parameters.AddWithValue("@gender", entity.Gender.ToString());
                cmd.Parameters.AddWithValue("@phoneNumber", entity.PhoneNumber);
                cmd.Parameters.AddWithValue("@email", entity.Email);

                await cmd.ExecuteNonQueryAsync();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }
        }

        public async Task<Patient> GetAsync(int id)
        {
            string query = "CALL usp_GetPatientById(@id)";

            try
            {
                using MySqlConnection conn = new DatabaseConnection().Connection;
                await conn.OpenAsync();

                using MySqlCommand command = new MySqlCommand(query, conn);
                command.Parameters.AddWithValue("@id", id);

                using MySqlDataReader reader = (MySqlDataReader) await command.ExecuteReaderAsync();
                if (await reader.ReadAsync())
                {
                    int patientId = reader.GetInt32("patient_id");
                    string firstName = reader.GetString("first_name");
                    string lastName = reader.GetString("last_name");
                    DateTime dateOfBirth = reader.GetDateTime("date_of_birth");
                    string gender = reader.GetString("gender");
                    string phoneNumber = reader.GetString("phone_number");
                    string email = reader.GetString("email");

                    return new Patient(patientId, firstName, lastName, dateOfBirth, GenderUtil.GetByName(gender), phoneNumber, email);
                }
                else
                {
                    return null;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<List<Patient>> GetAllAsync()
        {
            List<Patient> patients = new();
            string query = "SELECT * FROM patient";

            try
            {
                using MySqlConnection conn = new DatabaseConnection().Connection;
                await conn.OpenAsync();

                using MySqlCommand command = new MySqlCommand(query, conn);
                using MySqlDataReader reader = (MySqlDataReader) await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    int patientId = reader.GetInt32("patient_id");
                    string firstName = reader.GetString("first_name");
                    string lastName = reader.GetString("last_name");
                    DateTime dateOfBirth = reader.GetDateTime("date_of_birth");
                    string gender = reader.GetString("gender");
                    string phoneNumber = reader.GetString("phone_number");
                    string email = reader.GetString("email");

                    bool isMale = string.Equals(gender, Gender.Male.ToString(), StringComparison.OrdinalIgnoreCase);

                    Patient patient = new(patientId, firstName, lastName, dateOfBirth, isMale ? Gender.Male : Gender.Female, phoneNumber, email);
                    patients.Add(patient);
                }
            }
            catch (MySqlException ex)
            {
                return null;
            }

            return patients;
        }

        public Task<int> UpdateAsync(Patient entity)
        {
            throw new NotImplementedException();
        }

        Task<int> IDao<Patient>.DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
