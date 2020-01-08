using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using LibraCoffee.Entities;

namespace LibraCoffee.Services
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly MyDbContext _context;

        public OrderDetailRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<OrderDetail>> GetAsync()
        {
            return await _context.OrderDetails.ToListAsync();
        }
        public async Task<OrderDetail> GetAsync(int id)
        {
            return await _context.OrderDetails.FirstOrDefaultAsync(o => o.Id == id);
        }
        public async Task<bool> AddAsync(OrderDetail orderDetail)
        {
            if (orderDetail == null)
            {
                throw new ArgumentNullException(nameof(orderDetail));
            }

            await _context.OrderDetails.AddAsync(orderDetail);
            return true;
        }
        public async Task<bool> RemoveAsync(OrderDetail orderDetail)
        {
            if (orderDetail == null)
            {
                throw new ArgumentNullException(nameof(orderDetail));
            }
            if (!await _context.OrderDetails.AnyAsync(o => o.Id == orderDetail.Id))
            {
                throw new ArgumentException(nameof(orderDetail));
            }
            _context.OrderDetails.Remove(orderDetail);
            return true;
        }
        public async Task<bool> ExistAsync(int id)
        {
            return await _context.OrderDetails.AnyAsync(o => o.Id == id);
        }
        public async Task<bool> SaveAsync()
        {
            return (await _context.SaveChangesAsync()) >= 0;
        }
    }
}