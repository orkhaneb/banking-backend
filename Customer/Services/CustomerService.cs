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

        public async Task UpdateAsync(int Id, CustomerUpdateDto dto)
        {
            var customer = await _repository.GetByIdAsync(Id);
            if (customer == null)  throw new Exception("Müştəri tapılmadı.");

            customer.Name = dto.Name;
            customer.Surname= dto.Surname;
            customer.PhoneNumber= dto.PhoneNumber;
            customer.BirthDate=dto.BirthDate;

            await _repository.UpdateAsync(customer);


        }

        public async Task<List<CustomerResponseDto>> GetAllAsync()
        {
            var customers = await _repository.GetAllAsync();
            return customers.Select(x=> new CustomerResponseDto {

                Id= x.Id,
                Name = x.Name,
                Surname= x.Surname,
                BirthDate= x.BirthDate,
                PhoneNumber= x.PhoneNumber,
                Balance= x.Balance
            }).ToList();
        }

        public async Task<CustomerResponseDto> GetByIdAsync(int Id)
        {
            var customer = await _repository.GetByIdAsync(Id);
            if (customer == null || customer.IsDeleted) return null;

            return new CustomerResponseDto
            {
                Id = customer.Id,
                Name = customer.Name,
                Surname = customer.Surname,
                BirthDate = customer.BirthDate,
                PhoneNumber = customer.PhoneNumber,
                Balance = customer.Balance
            };
        }

        public async Task DeleteAsync(int Id)
        {
            var customer = await _repository.GetByIdAsync(Id);
            if (customer != null)
            {
                customer.IsDeleted = true;
                await _repository.AddAsync(customer); 
            }
        }

    }
}
