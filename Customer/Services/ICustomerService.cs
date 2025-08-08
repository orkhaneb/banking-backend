using Customer.Models.DTOs;

namespace Customer.Services
{
    public interface ICustomerService
    {
        Task CreateAsync(CustomerCreateDto dto);
        Task UpdateAsync(int id, CustomerUpdateDto dto);
        Task<CustomerResponseDto> GetByIdAsync(int Id);
        Task<List<CustomerResponseDto>> GetAllAsync();
        Task DeleteAsync(int Id);
    }
}
