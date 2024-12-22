using Models.Enums;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Model
{
    public class Doctor : User
    {
        private string  _specialization;
        private string  _phoneNumber;
        private Gender  _gender;
        private decimal _salary;

        public Doctor() : base() {
            Role = UserRole.Doctor;
        }

        public Doctor(int userId, string username, string password, string firstName, string lastName, string email, bool isActive, int languageId, int themeId, int fontId, string specialization, string phoneNumber, Gender gender, decimal salary) :
            base(userId, username, password, firstName, lastName, email, UserRole.Doctor, isActive, languageId, themeId, fontId) 
        {
            Specialization = specialization;
            PhoneNumber = phoneNumber;
            Gender = gender;
            Salary = salary;
        }

        public Doctor(Doctor other) : base(other)
        {
            Specialization = other.Specialization;
            PhoneNumber = other.PhoneNumber;
            Gender = other.Gender;
            Salary = other.Salary;
        }


        public string   Specialization  { get => _specialization; set { _specialization = value; } }
        public string   PhoneNumber     { get => _phoneNumber; set => _phoneNumber = value; }
        public Gender   Gender          { get => _gender; set => _gender = value; }
        public decimal  Salary          { get => _salary; set => _salary = value; }


        public override string ToString()
        {
            return base.ToString() + $"Specialization: {Specialization}, Phone: {PhoneNumber}, Gender: {Gender}, Salary: {Salary}";
        }

        public override User DeepCopy()
        {
            return new Doctor(this);
        }

        public override void ResetFields()
        {
            base.ResetFields();
            Specialization = string.Empty;
            PhoneNumber = string.Empty;
            Salary = 0;
        }
    }
}
