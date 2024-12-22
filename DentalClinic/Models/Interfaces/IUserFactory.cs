using Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Interfaces
{
    internal interface IUserFactory
    {
        User CreateUser(Dictionary<string, object> parameters);
    }
}
