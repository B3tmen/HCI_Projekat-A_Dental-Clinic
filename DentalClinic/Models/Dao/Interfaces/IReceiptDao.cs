using Models.Model;
using Models.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dao.Interfaces
{
    public interface IReceiptDao : IDao<Receipt>
    {
        Task<List<ReceiptDetailsDto>> GetDetailsByPatientId(int patientId);
        Task<int> GetLastReceiptId();
    }
}
