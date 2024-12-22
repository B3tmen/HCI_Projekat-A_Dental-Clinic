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
    public class LanguageDaoImpl : ILanguageDao
    {
        private LanguageEnum ResolveLanguage(string name)
        {
            var language = name switch
            {
                "English" => LanguageEnum.English,
                "Serbian" => LanguageEnum.Serbian
            };

            return language;
        }


        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Language>> GetAllAsync()
        {
            List<Language> languageList = new();
            string query = "SELECT * FROM user_language";

            try
            {
                using MySqlConnection conn = new DatabaseConnection().Connection;
                await conn.OpenAsync();

                using MySqlCommand command = new MySqlCommand(query, conn);
                using MySqlDataReader reader = (MySqlDataReader)await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    int id = reader.GetInt32("language_id");
                    string name = reader.GetString("name");

                    Language lang = new Language(id, ResolveLanguage(name));
                    languageList.Add(lang);
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

            return languageList;
        }

        public async Task<Language> GetAsync(int id)
        {
            string query = "CALL usp_GetLanguageById(@languageId)";

            Language language = null;
            try
            {
                using var conn = new DatabaseConnection().Connection;
                await conn.OpenAsync();
                using var command = new MySqlCommand(query, conn);

                command.Parameters.AddWithValue("@languageId", id);

                using var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    language = new Language
                    {
                        Id = reader.GetInt32("language_id"),
                        LanguageProperty = ResolveLanguage(reader.GetString("name"))
                    };
                }

            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return language;
        }

        public async Task<bool> InsertAsync(Language entity)
        {
            string query = "CALL usp_AddLanguage(@name)";
            try
            {
                using MySqlConnection conn = new DatabaseConnection().Connection;
                await conn.OpenAsync();
                Console.WriteLine(query);

                using MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", entity.LanguageProperty.ToString());

                await cmd.ExecuteNonQueryAsync();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }
        }

        public Task<int> UpdateAsync(Language entity)
        {
            throw new NotImplementedException();
        }
    }
}
