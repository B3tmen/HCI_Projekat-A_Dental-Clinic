using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Model.Dto
{
    public class ReceiptDetailsDto
    {
        public string   NameOfTreatment         { get; set; }
        public decimal  Price                   { get; set; }
        public int      TreatedTeethQuantity    { get; set; }   
        public decimal  Subtotal                { get; set; }
        //public decimal  Total                   { get; set; }
    }
}
