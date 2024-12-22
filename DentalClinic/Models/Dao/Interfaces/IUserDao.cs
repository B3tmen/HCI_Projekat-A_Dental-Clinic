using Models.Model;
using Models.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dao.Interfaces
{
    public interface IUserDao : IDao<User>
    {
        Task<User> GetByUsernameAndPassword(UserLoginDto userLoginDto);
    }
}
