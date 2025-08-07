using Customer.Data;
using Customer.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Customer.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {

        private readonly CustomerDbContext _context;

        public CustomerRepository(CustomerDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(CustomerEntity customer)
        {
             _context.Customers.AddAsync(customer);
             await _context.SaveChangesAsync(); 

        }

        public async Task<List<CustomerEntity>> GetAllAsync()
        {
            return await _context.Customers.Where(x=> !x.IsDeleted).ToListAsync();

        }

        public async Task<CustomerEntity> GetByIdAsync(int id)
        {
            return await _context.Customers.FirstOrDefaultAsync(x=>x.Id==id && !x.IsDeleted);
        }

        public async Task<CustomerEntity> GetByUserIdAsync(int userId)
        {
            return await _context.Customers.FirstOrDefaultAsync(x => x.UserId == userId && !x.IsDeleted);
        }

    }
}
