using Customer.Models.DTOs;
using Customer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Customer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _service;

        public CustomerController(ICustomerService customerService)
        {
            _service = customerService;
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CustomerCreateDto dto)
        {
            await _service.CreateAsync(dto);
            return Ok("Müştəri yaradıldı");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CustomerUpdateDto dto)
        {
            await _service.UpdateAsync(id, dto);
            return Ok("Müştəri yeniləndi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int Id)
        {
            var customer = await _service.GetByIdAsync(Id);
            if (customer == null) return NotFound("Müştəri tapılmadı.");

            return Ok(customer);
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var customers = await _service.GetAllAsync();
            return Ok(customers);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return Ok("Silindi");
        }



    }
}
