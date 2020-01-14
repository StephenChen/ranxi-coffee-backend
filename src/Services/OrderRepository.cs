using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using LibraCoffee.Entities.Models;
using LibraCoffee.Entities.Seed;

namespace LibraCoffee.Services
{
    public class OrderRepository : IOrderRepository
    {
        private readonly LibraCoffeeDbContext _context;
        
        public OrderRepository(LibraCoffeeDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Order>> GetAsync()
        {
            return await _context.Orders.Include(o => o.Customer).ToListAsync();
        }
        public async Task<Order> GetAsync(int id)
        {
            return await _context.Orders.Include(o => o.Customer).FirstOrDefaultAsync(o => o.OrderId == id);
        }
        public async Task<Order> GetAsync(string orderName)
        {
            if (string.IsNullOrEmpty(orderName))
            {
                throw new ArgumentNullException(nameof(orderName));
            }

            return await _context.Orders.Include(o => o.Customer).FirstOrDefaultAsync(o => o.OrderName == orderName);
        }
        public async Task<bool> AddAsync(Order order)
        {
            if (order == null)
            {
                throw new ArgumentNullException(nameof(order));
            }

            await _context.Orders.AddAsync(order);
            return true;
        }
        public async Task<bool> RemoveAsync(Order order)
        {
            if (order == null)
            {
                throw new ArgumentNullException(nameof(order));
            }
            if (!await _context.Orders.AnyAsync(o => o.OrderId == order.OrderId))
            {
                throw new ArgumentException(nameof(order));
            }
            try
            {
                _context.Orders.Remove(order);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public async Task<bool> ExistAsync(int id)
        {
            return await _context.Orders.AnyAsync(o => o.OrderId == id);
        }
        public async Task<bool> ExistAsync(string orderName)
        {
            if (string.IsNullOrEmpty(orderName))
            {
                throw new ArgumentNullException(nameof(orderName));
            }

            return await _context.Orders.AnyAsync(o => o.OrderName == orderName);
        }
        public async Task<bool> SaveAsync()
        {
            return (await _context.SaveChangesAsync()) >= 0;
        }
    }
}