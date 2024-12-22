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
    public class ThemeDaoImpl : IThemeDao
    {

        private ThemeEnum ResolveTheme(string name)
        {
            var theme = name switch
            {
                "Light" => ThemeEnum.Light,
                "Dark" => ThemeEnum.Dark,
                "Blue" => ThemeEnum.Blue
            };

            return theme;
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Theme>> GetAllAsync()
        {
            List<Theme> themeList = new();
            string query = "SELECT * FROM user_theme";

            try
            {
                using MySqlConnection conn = new DatabaseConnection().Connection;
                await conn.OpenAsync();

                using MySqlCommand command = new MySqlCommand(query, conn);
                using MySqlDataReader reader = (MySqlDataReader)await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    int id = reader.GetInt32("theme_id");
                    string name = reader.GetString("name");

                    Theme theme = new Theme(id, ResolveTheme(name));
                    themeList.Add(theme);
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

            return themeList;
        }

        public async Task<Theme> GetAsync(int id)
        {
            string query = "CALL usp_GetThemeById(@themeId)";

            Theme theme = null;
            try
            {
                using var conn = new DatabaseConnection().Connection;
                await conn.OpenAsync();
                using var command = new MySqlCommand(query, conn);

                command.Parameters.AddWithValue("@themeId", id);

                using var reader = command.ExecuteReader();
                
                if (reader.Read())
                {
                    theme = new Theme
                    {
                        Id = reader.GetInt32("theme_id"),
                        ThemeProperty = ResolveTheme(reader.GetString("name"))
                    };
                }
                
            }
            catch(MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return theme;
        }

        public async Task<bool> InsertAsync(Theme entity)
        {
            string query = "CALL usp_AddTheme(@name)";
            try
            {
                using MySqlConnection conn = new DatabaseConnection().Connection;
                await conn.OpenAsync();

                using MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", entity.ThemeProperty.ToString());

                await cmd.ExecuteNonQueryAsync();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }
        }

        public Task<int> UpdateAsync(Theme entity)
        {
            throw new NotImplementedException();
        }


    }
}
