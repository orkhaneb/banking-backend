using Microsoft.EntityFrameworkCore;
using User.Data;
using User.Models.Entities;

namespace User.Repositories
{
    public class UserRepository:IUserRepository
    {

        private readonly UserDbContext _context;

        public UserRepository(UserDbContext context)
        {
            _context = context;
        }

        public async Task<UserEntity> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task AddAsync(UserEntity user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }



    }
}
