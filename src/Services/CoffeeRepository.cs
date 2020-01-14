using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using LibraCoffee.Entities.Models;
using LibraCoffee.Entities.Seed;

namespace LibraCoffee.Services
{
    public class CoffeeRepository : ICoffeeRepository
    {
        private readonly LibraCoffeeDbContext _context;

        public CoffeeRepository(LibraCoffeeDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Coffee>> GetAsync()
        {
            return await _context.Coffees.ToListAsync();
        }
        public async Task<Coffee> GetAsync(int id)
        {
            return await _context.Coffees.FirstOrDefaultAsync(c => c.CoffeeId == id);
        }
        public async Task<bool> AddAsync(Coffee coffee)
        {
            if (coffee == null)
            {
                throw new ArgumentNullException(nameof(coffee));
            }

            await _context.Coffees.AddAsync(coffee);
            return true;
        }
        public async Task<bool> RemoveAsync(Coffee coffee)
        {
            if (coffee == null)
            {
                throw new ArgumentNullException(nameof(coffee));
            }
            if (!await _context.Coffees.AnyAsync(c => c.CoffeeId == coffee.CoffeeId))
            {
                throw new ArgumentException(nameof(coffee));
            }
            _context.Coffees.Remove(coffee);
            return true;
        }
        public async Task<bool> ExistAsync(int id)
        {
            return await _context.Coffees.AnyAsync(c => c.CoffeeId == id);
        }
        public async Task<bool> SaveAsync()
        {
            return (await _context.SaveChangesAsync()) >= 0;
        }
    }
}