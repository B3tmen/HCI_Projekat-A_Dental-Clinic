using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dao.Interfaces
{
    public interface IDao<TEntity>
    {
        Task<bool> InsertAsync(TEntity entity);

        Task<TEntity> GetAsync(int id);

        Task<List<TEntity>> GetAllAsync();

        Task<int> UpdateAsync(TEntity entity);

        Task<int> DeleteAsync(int id);
    }
}
