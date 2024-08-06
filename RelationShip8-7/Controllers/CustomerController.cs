using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RelationShip8_7.Models.Dto;
using RelationShip8_7.Repository;

namespace RelationShip8_7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        //GET Customer List
        [HttpGet("CustomerList")]
        public async Task<IActionResult> GetCustomers()
        {
            var customer = await _customerRepository.GetCustomersAsync();
            return Ok(customer);
        }

        [HttpGet("CustomerCars")]
        public async Task<IActionResult> GetCustomerCar()
        {
            var customer = await _customerRepository.GetCustomerCarListAsync();
            return Ok(customer);
        }

        [HttpPut]
        public async Task<IActionResult> GetCustomerCarById(int id)
        {
            var customerCar = await _customerRepository.GetCustomerCarByIdAsync(id);
            return Ok(customerCar);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewCustomerCar([FromBody] AddCustomerWithCarDto addCustomerDto)
        {
            
                await _customerRepository.AddCustomerCarAsync(addCustomerDto);
                return Ok();
        }
    }
}
