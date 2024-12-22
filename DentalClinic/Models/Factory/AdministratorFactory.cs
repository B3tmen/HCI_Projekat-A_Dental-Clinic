using Models.Interfaces;
using Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Factory
{
    internal class AdministratorFactory : IUserFactory
    {
        public User CreateUser(Dictionary<string, object> parameters)
        {
            return new Administrator(
                userId:     (int)parameters["userId"],
                username:   (string)parameters["username"],
                password:   (string)parameters["passwordHash"],
                firstName:  (string)parameters["firstName"],
                lastName:   (string)parameters["lastName"],
                email:      (string)parameters["email"],
                isActive:   (bool)parameters["isActive"],
                languageId: (int)parameters["languageId"],
                themeId:    (int)parameters["themeId"],
                fontId:     (int)parameters["fontId"]
            );
        }
    }
}
