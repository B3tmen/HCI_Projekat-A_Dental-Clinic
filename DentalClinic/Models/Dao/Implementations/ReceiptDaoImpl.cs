using Models.Dao.Interfaces;
using Models.Database;
using Models.Enums;
using Models.Model;
using Models.Model.Dto;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dao.Implementations
{
    public class ReceiptDaoImpl : IReceiptDao
    {
        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Receipt>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Receipt> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> InsertAsync(Receipt entity)
        {
            string query = "CALL usp_AddReceipt(@patientId, @dateIssued, @grandTotal)";
            try
            {
                using MySqlConnection conn = new DatabaseConnection().Connection;
                await conn.OpenAsync();

                using MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@patientId", entity.PatientId);
                cmd.Parameters.AddWithValue("@dateIssued", entity.DateIssued);
                cmd.Parameters.AddWithValue("@grandTotal", entity.GrandTotal);

                object result = await cmd.ExecuteScalarAsync();
                if(result != null)
                {
                    entity.ReceiptId = Convert.ToInt32(result);
                    return true;
                }
                else
                {
                    return false;
                }
            } catch(MySqlException ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }

        }

        public Task<int> UpdateAsync(Receipt entity)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ReceiptDetailsDto>> GetDetailsByPatientId(int patientId)
        {
            List<ReceiptDetailsDto> details = new();
            string query = "SELECT * FROM vw_receipt_details WHERE patient_id = @patientId";

            try
            {
                using MySqlConnection conn = new DatabaseConnection().Connection;
                await conn.OpenAsync();

                using MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@patientId", patientId);

                using MySqlDataReader reader = (MySqlDataReader) await cmd.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    string nameOfTreatment = reader.GetString("treatment_name");
                    decimal price = reader.GetDecimal("price");
                    int treatedTeethQty = reader.GetInt32("number_of_treated_teeth");
                    decimal subtotal = reader.GetDecimal("subtotal");

                    ReceiptDetailsDto detail = new ReceiptDetailsDto 
                    {
                        NameOfTreatment = nameOfTreatment,
                        Price = price,
                        TreatedTeethQuantity = treatedTeethQty,
                        Subtotal = subtotal
                    };

                    details.Add(detail);
                }

            } catch (MySqlException ex)
            {
                Console.WriteLine(ex.StackTrace);
            }

            return details;
        }

        public async Task<int> GetLastReceiptId()
        {
            string query = "CALL usp_GetLastReceiptId()";
            int lastId = 0;
            try
            {
                using MySqlConnection conn = new DatabaseConnection().Connection;
                await conn.OpenAsync();

                using MySqlCommand cmd = new MySqlCommand(query, conn);
                using MySqlDataReader reader = (MySqlDataReader) await cmd.ExecuteReaderAsync();

                if (await reader.ReadAsync())
                {
                    lastId = reader.GetInt32("last_receipt_id");
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.StackTrace);
            }

            return lastId;
        }
    }
}
