using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Model
{
    public class Medicine
    {
        private int         _medicineId;
        private string      _name;
        private int         _daysOfUse;
        private int         _useTimesPerDay;
        private DateTime    _expirationDate;
        private bool        _isUsable;

        public Medicine()
        {

        }

        public Medicine(int medicineId, string name, int daysOfUse, int useTimesPerDay, DateTime expirationDate, bool isUsable)
        {
            MedicineId = medicineId;
            Name = name;
            DaysOfUse = daysOfUse;
            UseTimesPerDay = useTimesPerDay;
            ExpirationDate = expirationDate;
            IsUsable = isUsable;
        }

        public Medicine(Medicine other)
        {
            MedicineId = other.MedicineId;
            Name = other.Name;
            DaysOfUse = other.DaysOfUse;
            UseTimesPerDay = other.UseTimesPerDay;  
            ExpirationDate = other.ExpirationDate;
            IsUsable = other.IsUsable;
        }


        public int      MedicineId      { get => _medicineId; init {  _medicineId = value; } }
        public string   Name            { get => _name; set => _name = value; }
        public int      DaysOfUse       { get => _daysOfUse; set => _daysOfUse = value; }
        public int      UseTimesPerDay  { get => _useTimesPerDay; set => _useTimesPerDay = value; }
        public DateTime ExpirationDate  { get => _expirationDate; set => _expirationDate = value; }
        public bool     IsUsable        { get => _isUsable; set => _isUsable = value; }

        public Medicine DeepCopy()
        {
            return new Medicine(this);
        }
    }
}
