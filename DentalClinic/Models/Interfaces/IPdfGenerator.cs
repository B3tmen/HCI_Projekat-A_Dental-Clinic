 using Models.Model;
using Models.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Interfaces
{
    public interface IPdfGenerator
    {
        void GenerateInvoice(List<ReceiptDetailsDto> receiptData, object wpfWindow, string filePath);
    }
}
