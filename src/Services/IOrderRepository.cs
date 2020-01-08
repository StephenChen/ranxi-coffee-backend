using System.Threading.Tasks;
using System.Collections.Generic;
using LibraCoffee.Entities;

namespace LibraCoffee.Services
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        Task<Order> GetAsync(string orderName);
        Task<bool> ExistAsync(string orderName);
    }
}