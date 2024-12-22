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
    public class FontDaoImpl : IFontDao
    {
        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<UserFont>> GetAllAsync()
        {
            List<UserFont> fontList = new();
            string query = "SELECT * FROM user_font";

            try
            {
                using MySqlConnection conn = new DatabaseConnection().Connection;
                await conn.OpenAsync();

                using MySqlCommand command = new MySqlCommand(query, conn);
                using MySqlDataReader reader = (MySqlDataReader) await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    int id = reader.GetInt32("font_id");
                    string name = reader.GetString("name");

                    UserFont theme = new UserFont(id, name);
                    fontList.Add(theme);
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

            return fontList;
        }

        public async Task<UserFont> GetAsync(int id)
        {
            string query = "CALL usp_GetFontById(@fontId)";

            UserFont font = null;
            try
            {
                using var conn = new DatabaseConnection().Connection;
                await conn.OpenAsync();
                using var command = new MySqlCommand(query, conn);

                command.Parameters.AddWithValue("@fontId", id);

                var reader = command.ExecuteReader();
                Console.WriteLine("1");
                if (reader.Read())
                {
                    Console.WriteLine("2");
                    int fontId = reader.GetInt32("font_id");
                    string fontName = reader.GetString("name");

                    font = new UserFont(fontId, fontName);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return font;
        }

        public async Task<bool> InsertAsync(UserFont entity)
        {
            string query = "CALL usp_AddFont(@name)";
            try
            {
                using MySqlConnection conn = new DatabaseConnection().Connection;
                await conn.OpenAsync();

                using MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", entity.FontName.ToString());

                await cmd.ExecuteNonQueryAsync();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }
        }

        public Task<int> UpdateAsync(UserFont entity)
        {
            throw new NotImplementedException();
        }
    }
}