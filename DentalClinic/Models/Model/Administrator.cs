using Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Model
{
    public class Administrator : User
    {
        public Administrator() : base() {
            Role = UserRole.Administrator;
        }

        public Administrator(int userId, string username, string password, string firstName, string lastName, string email, bool isActive, int languageId, int themeId, int fontId) :
            base(userId, username, password, firstName, lastName, email, UserRole.Administrator, isActive, languageId, themeId, fontId)
        {
        }
    }
}
