using Customer.Models.DTOs;
using Customer.Models.Entities;
using Customer.Repositories;

namespace Customer.Services
{
    public class CustomerService : ICustomerService
    {

        private readonly ICustomerRepository _repository;
        private readonly HttpClient _http;


        public CustomerService(ICustomerRepository repository, HttpClient http)
        {
            _repository = repository;
            _http = http;
        }



        public async Task CreateAsync(CustomerCreateDto dto)
        {
            var userResp = await _http.GetAsync($"http://localhost:5080/api/users/{dto.UserId}");
            if (!userResp.IsSuccessStatusCode)
                throw new Exception("İstifadəçi tapılmadı");

            var existing = await _repository.GetByUserIdAsync(dto.UserId);
            if (existing != null)
                throw new Exception("Bu istifadəçi üçün artıq customer mövcuddur");

            var entity = new CustomerEntity
            {
                UserId = dto.UserId,
                Name = dto.Name,
                Surname = dto.Surname,
                BirthDate = dto.BirthDate,
                PhoneNumber = dto.PhoneNumber,
                Balance = 50
            };

            await _repository.AddAsync(entity);
        }

        public Task DeleteAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<CustomerResponseDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CustomerResponseDto> GetByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
