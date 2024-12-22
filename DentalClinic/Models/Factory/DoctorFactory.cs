using Models.Interfaces;
using Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Factory
{
    internal class DoctorFactory : IUserFactory
    {
        public User CreateUser(Dictionary<string, object> parameters)
        {
            return new Doctor(
                userId:         (int)parameters["userId"],
                username:       (string)parameters["username"],
                password:       (string)parameters["passwordHash"],
                firstName:      (string)parameters["firstName"],
                lastName:       (string)parameters["lastName"],
                email:          (string)parameters["email"],
                isActive:       (bool)parameters["isActive"],
                languageId:     (int)parameters["languageId"],
                themeId:        (int)parameters["themeId"],
                fontId:         (int)parameters["fontId"],
                specialization: (string)parameters["specialization"],
                phoneNumber:    (string)parameters["phoneNumber"],
                gender:         (Enums.Gender)parameters["gender"],
                salary:         (decimal)parameters["salary"]
            );


            /*REFERENCE
             From Doctor.cs

             public Doctor(int userId, string username, string password, string firstName, string lastName, string email, bool isActive, int languageId, int themeId, string specialization, string phoneNumber, Gender gender, decimal salary) :
            base(userId, username, password, firstName, lastName, email, UserRole.Doctor, isActive, languageId, themeId) 
        {
            Specialization = specialization;
            PhoneNumber = phoneNumber;
            Gender = gender;
            Salary = salary;
        }
             
             
             */
        }
    }
}
