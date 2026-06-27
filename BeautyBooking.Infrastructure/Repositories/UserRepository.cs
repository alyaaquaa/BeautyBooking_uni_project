using BeautyBooking.Domain.Contracts;
using BeautyBooking.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BeautyBooking.Infrastructure
{
    public class UserRepository : IUserRepository
    {
        private readonly BeautyBookingDbContext _context;

        public UserRepository(BeautyBookingDbContext context)
        {
            _context = context;
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users
                .Include(x => x.Client)
                .Include(x => x.Employee)
                .FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }
    }
}