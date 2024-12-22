using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Model
{
    public class ReceiptItem
    {
        private int     _receiptId;
        private int     _treatmentId;
        private decimal _price;
        private int     _quantity;
        private decimal _subTotal;

        public ReceiptItem(int receiptId, int treatmentId, decimal price, int quantity, decimal subTotal)
        {
            ReceiptId = receiptId;
            TreatmentId = treatmentId;
            Price = price;
            Quantity = quantity;
            SubTotal = subTotal;
        }

        public int      ReceiptId { get => _receiptId; init { _receiptId = value; } }
        public int      TreatmentId { get => _treatmentId; init { _treatmentId = value; } }
        public decimal  Price { get => _price; set => _price = value; }
        public int      Quantity { get => _quantity; set => _quantity = value; }
        public decimal  SubTotal { get => _subTotal; set => _subTotal = value; }
    }
}
