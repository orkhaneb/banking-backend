using Microsoft.EntityFrameworkCore;
using User.Models.Entities;

namespace User.Data
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
        }

        public DbSet<UserEntity> Users { get; set; }
        

    }
}
