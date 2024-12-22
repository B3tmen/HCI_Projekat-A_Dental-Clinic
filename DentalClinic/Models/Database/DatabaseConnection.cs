using Models.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Models.Database
{

    public class DatabaseConnection
    {
        private static ConfigReader s_configReader = ConfigReader.Instance;
        private readonly MySqlConnection _connection;


        public DatabaseConnection()
        {
            try
            {
                _connection = new MySqlConnection(s_configReader.ConnectionString);

                Console.WriteLine("Database connection established");
            }
            catch (MySqlException e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }

        public MySqlConnection Connection => _connection;

        // Dispose to release the database connection
        public void Dispose()
        {
            if (Connection != null && Connection.State != System.Data.ConnectionState.Closed)
            {
                Connection.Close();
                Console.WriteLine("Database connection closed");
            }
        }
    }
}
