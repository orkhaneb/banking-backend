using Customer.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Customer.Data
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options):base(options)
        {
        }

        public DbSet<CustomerEntity> Customers { get; set; }
    }

   

}
