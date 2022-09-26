using Booking.Infrastructure.Context;
using Booking.Infrastructure.Repository.Abstraction;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Infrastructure.Repository.Implementation
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(T input)
        {
            await _context.Set<T>().AddAsync(input);
        }
        public async Task<IEnumerable<T>> GetCollcetionsAsync(Expression<Func<T, bool>> expression = null)
        {
            return expression == null ? await _context.Set<T>().ToListAsync() : await _context.Set<T>().Where(expression).ToListAsync();
        }

        public IQueryable<T> GetQuery(Expression<Func<T, bool>> expression = null)
        {
            return expression == null ? _context.Set<T>() : _context.Set<T>().Where(expression);
        }

        public void Update(T input)
        {
            _context.Set<T>().Update(input);
        }
        public void Delete(T input)
        {
            _context.Set<T>().Remove(input);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
