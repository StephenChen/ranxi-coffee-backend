using System.Threading.Tasks;
using System.Collections.Generic;

namespace LibraCoffee.MicroServices.Repository
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAsync();
        Task<TEntity> GetAsync(int id);
        Task<bool> AddAsync(TEntity model);
        Task<bool> RemoveAsync(TEntity model);
        Task<bool> ExistAsync(int id);
        Task<bool> SaveAsync();
    }
}