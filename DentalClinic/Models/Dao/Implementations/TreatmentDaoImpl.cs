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
    public class TreatmentDaoImpl : ITreatmentDao
    {
        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Treatment>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Treatment> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> InsertAsync(Treatment entity)
        {
            string query = "CALL usp_AddTreatment(@name, @description, @price, @medicineId, @treatedTeeth)";
            try
            {
                using MySqlConnection conn = new DatabaseConnection().Connection;
                await conn.OpenAsync();

                using MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", entity.Name);
                cmd.Parameters.AddWithValue("@description", entity.Description);
                cmd.Parameters.AddWithValue("@price", entity.Price);
                cmd.Parameters.AddWithValue("@medicineId", entity.MedicineId);
                cmd.Parameters.AddWithValue("@treatedTeeth", entity.TreatedTeeth);

                object result = await cmd.ExecuteScalarAsync();
                if (result != null)
                {
                    entity.TreatmentId = Convert.ToInt32(result);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }
        }

        public Task<int> UpdateAsync(Treatment entity)
        {
            throw new NotImplementedException();
        }
    }
}
