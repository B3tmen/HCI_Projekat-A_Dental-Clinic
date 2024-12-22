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
    public class ReceiptItemDaoImpl : IReceiptItemDao
    {
        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ReceiptItem>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ReceiptItem> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> InsertAsync(ReceiptItem entity)
        {
            string query = "CALL usp_AddReceiptItem(@receiptId, @treatmentId, @price, @quantity)";
            try
            {
                using MySqlConnection conn = new DatabaseConnection().Connection;
                await conn.OpenAsync();

                using MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@receiptId", entity.ReceiptId);
                cmd.Parameters.AddWithValue("@treatmentId", entity.TreatmentId);
                cmd.Parameters.AddWithValue("@price", entity.Price);
                cmd.Parameters.AddWithValue("@quantity", entity.Quantity);

                await cmd.ExecuteNonQueryAsync();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }
        }

        public Task<int> UpdateAsync(ReceiptItem entity)
        {
            throw new NotImplementedException();
        }
    }
}
