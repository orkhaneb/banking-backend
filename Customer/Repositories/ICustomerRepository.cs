using Customer.Models.Entities;

namespace Customer.Repositories
{
    public interface ICustomerRepository
    {
        Task AddAsync(CustomerEntity customer);
        Task<CustomerEntity> GetByIdAsync(int id);
        Task<List<CustomerEntity>> GetAllAsync();
        Task<CustomerEntity> GetByUserIdAsync(int userId);
    }
}
