using Models.Dao.Interfaces;
using Models.Database;
using Models.Enums;
using Models.Factory;
using Models.Model;
using Models.Model.Dto;
using Models.Util;
using MySql.Data.MySqlClient;
using Mysqlx.Datatypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dao.Implementations
{
    public class UserDaoImpl : IUserDao
    {
        private UserRole ResolveRole(string name)
        {

            return name switch
            {
                "administrator" => UserRole.Administrator,
                "doctor" => UserRole.Doctor
            };
        }

        private Gender ResolveGender(string name)
        {
            bool isMale = string.Equals(name, Gender.Male.ToString(), StringComparison.OrdinalIgnoreCase);
            return isMale ? Gender.Male : Gender.Female;
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<User>> GetAllAsync()
        {
            List<User> users = new();
            User user = null;
            string query = "SELECT * FROM vw_all_users";

            try
            {
                using MySqlConnection conn = new DatabaseConnection().Connection;
                await conn.OpenAsync();

                using MySqlCommand command = new MySqlCommand(query, conn);
                using MySqlDataReader reader = (MySqlDataReader) await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    int userId = reader.GetInt32("user_id");
                    string username = reader.GetString("username");
                    string passwordHash = reader.GetString("password_hash");
                    string firstName = reader.GetString("first_name");
                    string lastName = reader.GetString("last_name");
                    string email = reader.GetString("email");
                    string role = reader.GetString("role");
                    bool isActive = reader.GetBoolean("is_active");
                    int languageId = !reader.IsDBNull("fk_language_id") ? reader.GetInt32("fk_language_id") : 0;
                    int themeId = !reader.IsDBNull("fk_theme_id") ? reader.GetInt32("fk_theme_id") : 0;
                    int fontId = !reader.IsDBNull("fk_font_id") ? reader.GetInt32("fk_font_id") : 0;

                    string specialization = !reader.IsDBNull("specialization") ? reader.GetString("specialization") : string.Empty;
                    string phoneNumber = !reader.IsDBNull("phone_number") ? reader.GetString("phone_number") : string.Empty;
                    Gender gender = !reader.IsDBNull("gender") ? ResolveGender(reader.GetString("gender")) : Gender.Male;
                    decimal salary = !reader.IsDBNull("salary") ? reader.GetDecimal("salary") : 0;

                    Dictionary<string, object> data = new() {
                        { "userId", userId },
                        { "username", username },
                        { "passwordHash", passwordHash },
                        { "firstName", firstName },
                        { "lastName", lastName },
                        { "email", email },
                        { "isActive", isActive },
                        { "languageId", languageId },
                        { "themeId", themeId },
                        { "fontId", fontId },

                        { "specialization", specialization },
                        { "phoneNumber", phoneNumber },
                        { "gender", gender },
                        { "salary", salary },
                    };

                    user = UserFactoryRegistry.CreateUser(ResolveRole(role), data);
                    users.Add(user);
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

            return users;
        }

        public Task<User> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetByUsernameAndPassword(UserLoginDto userLoginDto)
        {
            string query = "CALL usp_GetUserByUsernameAndPassword(@username, @password)";

            try
            {
                using MySqlConnection conn = new DatabaseConnection().Connection;
                await conn.OpenAsync();

                using MySqlCommand command = new MySqlCommand(query, conn);
                command.Parameters.AddWithValue("@username", userLoginDto.Username);
                command.Parameters.AddWithValue("@password", userLoginDto.Password);

                using MySqlDataReader reader = (MySqlDataReader)await command.ExecuteReaderAsync();
                if (await reader.ReadAsync())
                {
                    int userId = reader.GetInt32("user_id");
                    string firstName = reader.GetString("first_name");
                    string lastName = reader.GetString("last_name");
                    string email = reader.GetString("email");
                    string role = reader.GetString("role");
                    bool isActive = reader.GetBoolean("is_active");
                    int languageId = !reader.IsDBNull("fk_language_id") ? reader.GetInt32("fk_language_id") : 0;
                    int themeId = !reader.IsDBNull("fk_theme_id") ? reader.GetInt32("fk_theme_id") : 0;
                    int fontId = !reader.IsDBNull("fk_font_id") ? reader.GetInt32("fk_font_id") : 0;

                    string specialization = !reader.IsDBNull("specialization") ? reader.GetString("specialization") : string.Empty;
                    string phoneNumber = !reader.IsDBNull("phone_number") ? reader.GetString("phone_number") : string.Empty;
                    Gender gender = !reader.IsDBNull("gender") ? ResolveGender(reader.GetString("gender")) : Gender.Male;
                    decimal salary = !reader.IsDBNull("salary") ? reader.GetDecimal("salary") : 0;

                    Dictionary<string, object> data = new() {
                        { "userId", userId },
                        { "username", userLoginDto.Username },
                        { "passwordHash", userLoginDto.Password },
                        { "firstName", firstName },
                        { "lastName", lastName },
                        { "email", email },
                        { "isActive", isActive },
                        { "languageId", languageId },
                        { "themeId", themeId },
                        { "fontId", fontId }, 

                        { "specialization", specialization },
                        { "phoneNumber", phoneNumber },
                        { "gender", gender },
                        { "salary", salary },
                    };

                    return UserFactoryRegistry.CreateUser(ResolveRole(role), data);
                }
                else
                {
                    return null;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.StackTrace);
                return null;
            }
        }


        public async Task<bool> InsertAsync(User entity)
        {
            bool inserted = false;
            string query = "";
            string passwordHash = TextHasher.GetSHA256Hash(entity.Password);

            try
            {
                using MySqlConnection conn = new DatabaseConnection().Connection;
                await conn.OpenAsync();
                MySqlCommand cmd = new MySqlCommand();

                if (entity is Doctor doctor)
                {
                    query = "CALL usp_AddDoctor(@username, @passwordHash, @firstName, @lastName, @email, @isActive, @specialization, @phoneNumber, @gender, @salary)";

                    cmd = new MySqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@username", doctor.Username);
                    cmd.Parameters.AddWithValue("@passwordHash", passwordHash);
                    cmd.Parameters.AddWithValue("@firstName", doctor.FirstName);
                    cmd.Parameters.AddWithValue("@lastName", doctor.LastName);
                    cmd.Parameters.AddWithValue("@email", doctor.Email);
                    cmd.Parameters.AddWithValue("@isActive", doctor.IsActive);
                    cmd.Parameters.AddWithValue("@specialization", doctor.Specialization);
                    cmd.Parameters.AddWithValue("@phoneNumber", doctor.PhoneNumber);
                    cmd.Parameters.AddWithValue("@gender", doctor.Gender.ToString());
                    cmd.Parameters.AddWithValue("@salary", doctor.Salary);

                    
                }
                else if (entity is Administrator admin)
                {
                    query = "CALL usp_AddAdministrator(@username, @passwordHash, @firstName, @lastName, @email, @isActive)";

                    cmd = new MySqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@username", admin.Username);
                    cmd.Parameters.AddWithValue("@passwordHash", passwordHash);
                    cmd.Parameters.AddWithValue("@firstName", admin.FirstName);
                    cmd.Parameters.AddWithValue("@lastName", admin.LastName);
                    cmd.Parameters.AddWithValue("@email", admin.Email);
                    cmd.Parameters.AddWithValue("@isActive", admin.IsActive);
                }

                await cmd.ExecuteScalarAsync();
                inserted = true;
                cmd.Dispose();
            } catch(MySqlException e)
            {
                inserted = false;
                Console.WriteLine(e.StackTrace);
            }

            return inserted;
        }

        public async Task<int> UpdateAsync(User entity)
        {
            int updated = 0;
            string query = "CALL usp_UpdateUser(@userId, @username, @password, @firstName, @lastName, @email, @isActive)";
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
