using Models.Interfaces;
using Models.Model;
using Models.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Services
{
    public class ReceiptService
    {
        private readonly IPdfGenerator _pdfGenerator;

        public ReceiptService(IPdfGenerator pdfGenerator)
        {
            _pdfGenerator = pdfGenerator;
        }

        public void GenerateReceipt(List<ReceiptDetailsDto> receiptData)
        {
            //_pdfGenerator.GenerateInvoice(receiptData, "../../../invoice.pdf");
        }
    }
}
