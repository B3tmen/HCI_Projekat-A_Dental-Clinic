using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Models.Enums;

namespace Models.Model
{

    public class Patient
    {
        private int         _patientId;
        private string      _firstName;
        private string      _lastName;
        private DateTime    _dateOfBirth;
        private Gender      _gender;
        private string      _phoneNumber;
        private string      _email;


        public Patient()
        {

        }

        public Patient(int patientId, string firstName, string lastName, DateTime dateOfBirth, Gender gender, string phoneNumber, string email)
        {
            PatientId = patientId;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            PhoneNumber = phoneNumber;
            Email = email;
        }


        public int      PatientId { get => _patientId; init { _patientId = value; } }
        public string   FirstName { get => _firstName; set => _firstName = value; }
        public string   LastName { get => _lastName; set => _lastName = value; }
        public DateTime DateOfBirth { get => _dateOfBirth; set => _dateOfBirth = value; }
        public Gender   Gender { get => _gender; set => _gender = value; }
        public string   PhoneNumber { get => _phoneNumber; set => _phoneNumber = value; }
        public string   Email { get => _email; set => _email = value; }


        public override string ToString()
        {
            return $"Patient -> ID:{PatientId}, FName:{FirstName}, LName:{LastName}, DOB:{DateOfBirth}, Gender:{Gender}";
        }
    }
}
