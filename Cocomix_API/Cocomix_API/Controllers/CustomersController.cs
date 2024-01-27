using Cocomix_API.DTO;
using Cocomix_API.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cocomix_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly CustomerService _customerService;

        public CustomersController(CustomerService customerService) 
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetList() 
        {
            try
            {
                return Ok(await _customerService.GetAllCustomer());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerByID(int id) 
        {
            try
            {
                var customer = await _customerService.GetCustomerByID(id);
                return customer == null ? NotFound() : Ok(customer);
            }
            catch 
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> addCustomer(CustomerDTO customerDTO)
        {
            try
            {
                return Ok(await _customerService.AddCustomer(customerDTO));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> updateCustomer(int id ,  CustomerDTO customerDTO)
        {
            try
            {
                var customer = await _customerService.UpdateCustomer(id, customerDTO);
                return customer == null ? NotFound() : Ok(customer);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteCustomer(int id)
        {
            try
            {
                var customer = await _customerService.DeleteCustomer(id);
                return customer == null ? NotFound() : Ok(customer);
            }
            catch
            {
                return BadRequest();
            }
        }


    }
}
