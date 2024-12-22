using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Model
{
    public class Treatment
    {
        private int     _treatmentId;
        private string  _name;
        private string  _description;
        private decimal _price;
        private int     _medicineId;
        private string  _treatedTeeth;


        public Treatment() {
            TreatmentId = 0;
            Name = string.Empty;
            Description = string.Empty;
            TreatedTeeth = string.Empty;
        }

        public Treatment(int treatmentId, string name, string description, decimal price, int medicineId, string treatedTeeth)
        {
            TreatmentId = treatmentId;
            Name = name;
            Description = description;
            Price = price;
            MedicineId = medicineId;
            TreatedTeeth = treatedTeeth;

        }


        public int      TreatmentId     { get => _treatmentId; set => _treatmentId = value; }
        public string   Name            { get => _name; set => _name = value; }
        public string   Description     { get => _description; set => _description = value; }
        public decimal  Price           { get => _price; set => _price = value; }
        public int      MedicineId      { get => _medicineId; init => _medicineId = value; }
        public string   TreatedTeeth    { get => _treatedTeeth; set => _treatedTeeth = value; }
    }
}
