using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using LibraCoffee.Entities.Models;
using LibraCoffee.Entities.Seed;

namespace LibraCoffee.Services
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly LibraCoffeeDbContext _context;

        public CustomerRepository(LibraCoffeeDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Customer>> GetAsync()
        {
            return await _context.Customers.ToListAsync();
        }
        public async Task<Customer> GetAsync(int id)
        {
            return await _context.Customers.FirstOrDefaultAsync(c => c.CustomerId == id);
        }
        public async Task<bool> AddAsync(Customer customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer));
            }

            await _context.Customers.AddAsync(customer);
            return true;
        }
        public async Task<bool> RemoveAsync(Customer customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer));
            }
            if (!await _context.Customers.AnyAsync(c => c.CustomerId == customer.CustomerId))
            {
                throw new ArgumentException(nameof(customer));
            }
            _context.Customers.Remove(customer);
            return true;
        }
        public async Task<bool> ExistAsync(int id)
        {
            return await _context.Customers.AnyAsync(c => c.CustomerId == id);
        }
        public async Task<bool> SaveAsync()
        {
            return (await _context.SaveChangesAsync()) >= 0;
        }
    }
}