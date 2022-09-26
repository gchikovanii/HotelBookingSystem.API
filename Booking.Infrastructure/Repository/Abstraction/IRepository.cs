using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Infrastructure.Repository.Abstraction
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetCollcetionsAsync(Expression<Func<T, bool>> expression = null);
        IQueryable<T> GetQuery(Expression<Func<T, bool>> expression = null);
        Task CreateAsync(T input);
        void Update(T input);
        void Delete(T input);
        Task<bool> SaveChangesAsync();
    }
}
