using Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dao.Interfaces
{
    public interface IDoctorDao : IDao<Doctor>
    {
        Task<bool> ChangeLanguage(int id, Language language);
        Task<bool> ChangeTheme(int id, Theme theme);
        Task<bool> ChangeFont(int id, UserFont font);
    }
}
