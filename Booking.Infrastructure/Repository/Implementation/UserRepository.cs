using Booking.Domain.Entities.UserAggregate;
using Booking.Infrastructure.Context;
using Booking.Infrastructure.Repository.Abstraction;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Infrastructure.Repository.Implementation
{
    public class UserRepository : Repository<AppUser>, IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task CreateWishList(int userId, int hotelId)
        {
            var user = await _context.Set<AppUser>().Include(i => i.Hotels).FirstOrDefaultAsync(i => i.Id == userId);
            var hotel = await _context.Hotels.FirstOrDefaultAsync(i => i.Id == hotelId);

            if(!user.Hotels.Any(i => i.Id == hotelId))
                user.Hotels.Add(hotel);
        }

        public async Task<AppUser> GetById(int id)
        {
            var user = await _context.Set<AppUser>().Include(i => i.Hotels).SingleOrDefaultAsync(i => i.Id == id);
            return user;
        }
    }
}
