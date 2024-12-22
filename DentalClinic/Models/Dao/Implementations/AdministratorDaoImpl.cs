using Models.Dao.Interfaces;
using Models.Database;
using Models.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dao.Implementations
{
    public class AdministratorDaoImpl : IAdministratorDao
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

                await cmd.ExecuteNonQueryAsync();
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

        public Task<List<Administrator>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Administrator> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertAsync(Administrator entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(Administrator entity)
        {
            throw new NotImplementedException();
        }
    }
}
