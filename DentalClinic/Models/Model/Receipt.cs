using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Model
{
    public class Receipt
    {
        private int                 _receiptId;
        private int                 _patientId;
        private decimal             _grandTotal;
        private DateTime            _dateIssued;
        private List<ReceiptItem>   _receiptItems;


        public Receipt() {
            DateIssued = DateTime.Now;
            ReceiptItems = new();
        }

        public Receipt(int receiptId, int patientId, decimal grandTotal, DateTime dateIssued)
        {
            ReceiptId = receiptId;
            PatientId = patientId;
            GrandTotal = grandTotal;
            DateIssued = dateIssued;
            ReceiptItems = new();
        }


        public int                  ReceiptId { get => _receiptId; set { _receiptId = value; } }
        public int                  PatientId { get => _patientId; set => _patientId = value; }
        public decimal              GrandTotal { get => _grandTotal; set => _grandTotal = value; }
        public DateTime             DateIssued { get => _dateIssued; set => _dateIssued = value; }
        public List<ReceiptItem>    ReceiptItems { get => _receiptItems; set => _receiptItems = value; }
    }
}
